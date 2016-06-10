'    Reactor Base Class
'    Copyright 2008 Daniel Wagner O. de Medeiros
'
'    This file is part of DWSIM.
'
'    DWSIM is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    DWSIM is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with DWSIM.  If not, see <http://www.gnu.org/licenses/>.

Imports Microsoft.MSDN.Samples.GraphicObjects
Imports System.Collections.Generic
Imports DWSIM.DWSIM.ClassesBasicasTermodinamica
Imports System.Linq

Namespace DWSIM.SimulationObjects.Reactors

    Public Enum OperationMode
        Isothermic = 0
        Adiabatic = 1
        OutletTemperature = 2
    End Enum

    <System.Serializable()> Public MustInherit Class Reactor

        Inherits SimulationObjects_UnitOpBaseClass

        Protected m_reactionSequence As SortedList(Of Integer, ArrayList)
        Protected m_reactions As List(Of String)
        Protected m_conversions As Dictionary(Of String, Double)
        Protected m_componentconversions As Dictionary(Of String, Double)
        Protected m_reactionSetID As String = "DefaultSet"
        Protected m_reactionSetName As String = ""
        Protected m_opmode As OperationMode = OperationMode.Adiabatic
        Protected m_dp As Nullable(Of Double)
        Protected m_dt As Nullable(Of Double)
        Protected m_DQ As Nullable(Of Double)

        Public Overrides Function LoadData(data As System.Collections.Generic.List(Of System.Xml.Linq.XElement)) As Boolean

            MyBase.LoadData(data)
            Dim ci As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture

            For Each xel2 As XElement In (From xel As XElement In data Select xel Where xel.Name = "ReactionSequence").Elements
                m_reactionSequence.Add(xel2.@Index, XMLSerializer.XMLSerializer.StringToArray(xel2.Value, ci))
            Next

            For Each xel2 As XElement In (From xel As XElement In data Select xel Where xel.Name = "Reaction").Elements
                m_reactions.Add(xel2.@ID)
            Next

            For Each xel2 As XElement In (From xel As XElement In data Select xel Where xel.Name = "ReactionConversions").Elements
                m_conversions.Add(xel2.@ID, Double.Parse(xel2.Value, ci))
            Next

            For Each xel2 As XElement In (From xel As XElement In data Select xel Where xel.Name = "CompoundConversions").Elements
                m_componentconversions.Add(xel2.@ID, Double.Parse(xel2.Value, ci))
            Next

        End Function

        Public Overrides Function SaveData() As System.Collections.Generic.List(Of System.Xml.Linq.XElement)

            Dim elements As System.Collections.Generic.List(Of System.Xml.Linq.XElement) = MyBase.SaveData()
            Dim ci As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture

            With elements
                .Add(New XElement("ReactionSequence"))
                For Each kvp As KeyValuePair(Of Integer, ArrayList) In m_reactionSequence
                    .Item(.Count - 1).Add(New XElement("Item", New XAttribute("Index", kvp.Key), XMLSerializer.XMLSerializer.ArrayToString(kvp.Value, ci)))
                Next
                .Add(New XElement("Reactions"))
                For Each s As String In m_reactions
                    .Item(.Count - 1).Add(New XElement("Reaction", New XAttribute("ID", s)))
                Next
                .Add(New XElement("ReactionConversions"))
                For Each kvp As KeyValuePair(Of String, Double) In m_conversions
                    .Item(.Count - 1).Add(New XElement("Reaction", New XAttribute("ID", kvp.Key), kvp.Value.ToString(ci)))
                Next
                .Add(New XElement("CompoundConversions"))
                For Each kvp As KeyValuePair(Of String, Double) In m_componentconversions
                    .Item(.Count - 1).Add(New XElement("Compound", New XAttribute("ID", kvp.Key), kvp.Value.ToString(ci)))
                Next
            End With

            Return elements

        End Function

        Function GetConvFactors(rxn As Reaction, ims As SimulationObjects.Streams.MaterialStream) As Dictionary(Of String, Double)

            Dim conv As New SistemasDeUnidades.Conversor

            Dim P As Double = ims.Fases(0).SPMProperties.pressure.GetValueOrDefault
            Dim T As Double = ims.Fases(0).SPMProperties.temperature.GetValueOrDefault
            Dim amounts As New Dictionary(Of String, Double)
            Dim val1, val2, val3 As Double

            For Each sb As ReactionStoichBase In rxn.Components.Values

                If Not amounts.ContainsKey(sb.CompName) Then amounts.Add(sb.CompName, 0.0#)

                Const R As Double = 8.314
                Select Case rxn.ReactionBasis
                    Case ReactionBasis.Activity
                        val1 = ims.Fases(3).Componentes(sb.CompName).ActivityCoeff.GetValueOrDefault
                        val2 = ims.Fases(3).SPMProperties.molecularWeight.GetValueOrDefault
                        val3 = ims.Fases(3).SPMProperties.density.GetValueOrDefault
                        amounts(sb.CompName) = val1 * val2 / val3
                    Case ReactionBasis.Fugacity
                        Select Case rxn.ReactionPhase
                            Case PhaseName.Vapor
                                val1 = ims.Fases(2).Componentes(sb.CompName).FugacityCoeff.GetValueOrDefault
                                amounts(sb.CompName) = val1 * R * T
                            Case PhaseName.Liquid
                                val1 = ims.Fases(3).Componentes(sb.CompName).FugacityCoeff.GetValueOrDefault
                                val2 = ims.Fases(3).SPMProperties.molecularWeight.GetValueOrDefault
                                val3 = ims.Fases(3).SPMProperties.density.GetValueOrDefault
                                amounts(sb.CompName) = val1 * val2 / val3 * P
                            Case PhaseName.Mixture
                                val1 = ims.Fases(0).Componentes(sb.CompName).FugacityCoeff.GetValueOrDefault
                                val2 = ims.Fases(0).SPMProperties.molecularWeight.GetValueOrDefault
                                val3 = ims.Fases(0).SPMProperties.density.GetValueOrDefault
                                amounts(sb.CompName) = val1 * val2 / val3 * P
                        End Select
                    Case ReactionBasis.MassConc
                        Select Case rxn.ReactionPhase
                            Case PhaseName.Vapor
                                val1 = ims.Fases(2).SPMProperties.molecularWeight.GetValueOrDefault
                                amounts(sb.CompName) = 1000 / val1
                            Case PhaseName.Liquid
                                val1 = ims.Fases(3).SPMProperties.molecularWeight.GetValueOrDefault
                                amounts(sb.CompName) = 1000 / val1
                            Case PhaseName.Mixture
                                val1 = ims.Fases(0).SPMProperties.molecularWeight.GetValueOrDefault
                                amounts(sb.CompName) = 1000 / val1
                        End Select
                    Case ReactionBasis.MassFrac
                        Select Case rxn.ReactionPhase
                            Case PhaseName.Vapor
                                val1 = ims.Fases(2).SPMProperties.molecularWeight.GetValueOrDefault
                                amounts(sb.CompName) = R * T / P * 1000 / val1
                            Case PhaseName.Liquid
                                val1 = ims.Fases(3).SPMProperties.molecularWeight.GetValueOrDefault
                                val2 = ims.Fases(3).SPMProperties.density.GetValueOrDefault
                                amounts(sb.CompName) = val2 * 1000 / val1
                            Case PhaseName.Mixture
                                val1 = ims.Fases(0).SPMProperties.molecularWeight.GetValueOrDefault
                                val2 = ims.Fases(0).SPMProperties.density.GetValueOrDefault
                                amounts(sb.CompName) = val2 * 1000 / val1
                        End Select
                    Case ReactionBasis.MolarConc
                        amounts(sb.CompName) = 1.0#
                    Case ReactionBasis.MolarFrac
                        Select Case rxn.ReactionPhase
                            Case PhaseName.Vapor
                                amounts(sb.CompName) = R * T / P
                            Case PhaseName.Liquid
                                val1 = ims.Fases(3).SPMProperties.molecularWeight.GetValueOrDefault
                                val2 = ims.Fases(3).SPMProperties.density.GetValueOrDefault
                                amounts(sb.CompName) = val1 / val2
                            Case PhaseName.Mixture
                                val1 = ims.Fases(0).SPMProperties.molecularWeight.GetValueOrDefault
                                val2 = ims.Fases(0).SPMProperties.density.GetValueOrDefault
                                amounts(sb.CompName) = val1 / val2
                        End Select
                    Case ReactionBasis.PartialPress
                        amounts(sb.CompName) = R * T
                End Select

                amounts(sb.CompName) = Conversor.ConverterDoSI(rxn.ConcUnit, amounts(sb.CompName))

            Next

            Return amounts

        End Function

        Sub New()
            MyBase.CreateNew()
            Me.m_reactionSequence = New SortedList(Of Integer, ArrayList)
            Me.m_reactions = New List(Of String)
            Me.m_conversions = New Dictionary(Of String, Double)
            Me.m_componentconversions = New Dictionary(Of String, Double)
        End Sub

        Public Property OutletTemperature As Double = 298.15#

        <Xml.Serialization.XmlIgnore()> Public Property ReactionsSequence() As SortedList(Of Integer, ArrayList)
            Get
                Return m_reactionSequence
            End Get
            Set(ByVal value As SortedList(Of Integer, ArrayList))
                m_reactionSequence = value
            End Set
        End Property

        <Xml.Serialization.XmlIgnore()> Public ReadOnly Property Conversions() As Dictionary(Of String, Double)
            Get
                Return Me.m_conversions
            End Get
        End Property

        <Xml.Serialization.XmlIgnore()> Public ReadOnly Property ComponentConversions() As Dictionary(Of String, Double)
            Get
                Return Me.m_componentconversions
            End Get
        End Property

        <Xml.Serialization.XmlIgnore()> Public Property Reactions() As List(Of String)
            Get
                Return m_reactions
            End Get
            Set(ByVal value As List(Of String))
                m_reactions = value
            End Set
        End Property

        Public Property ReactorOperationMode() As OperationMode
            Get
                Return Me.m_opmode
            End Get
            Set(ByVal value As OperationMode)
                Me.m_opmode = value
            End Set
        End Property

        Public Property ReactionSetID() As String
            Get
                Return Me.m_reactionSetID
            End Get
            Set(ByVal value As String)
                Me.m_reactionSetID = value
            End Set
        End Property

        Public Property ReactionSetName() As String
            Get
                Return Me.m_reactionSetName
            End Get
            Set(ByVal value As String)
                Me.m_reactionSetName = value
            End Set
        End Property

        Public Property DeltaP() As Nullable(Of Double)
            Get
                Return m_dp
            End Get
            Set(ByVal value As Nullable(Of Double))
                m_dp = value
            End Set
        End Property

        Public Property DeltaT() As Nullable(Of Double)
            Get
                Return m_dt
            End Get
            Set(ByVal value As Nullable(Of Double))
                m_dt = value
            End Set
        End Property

        Public Property DeltaQ() As Nullable(Of Double)
            Get
                Return m_DQ
            End Get
            Set(ByVal value As Nullable(Of Double))
                m_DQ = value
            End Set
        End Property

#Region "    Table Functions"

        Public Overrides Sub QTFillNodeItems()

        End Sub

        Public Overrides Sub UpdatePropertyNodes(ByVal su As SistemasDeUnidades.Unidades, ByVal nf As String)

        End Sub

#End Region

    End Class

End Namespace
