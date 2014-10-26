﻿'    ===========================================
'    ==  Initial Version of Excel User Unit ====
'    ==  Not ready for release !!! =============
'    ===========================================

'    Excel Unit Calculation Routines 
'    Copyright 2014 Gregor Reichert
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

Imports NetOffice
Imports Excel = NetOffice.ExcelApi
Imports NetOffice.ExcelApi.Enums

Imports Microsoft.MSDN.Samples.GraphicObjects
Imports DWSIM.DWSIM.Flowsheet.FlowSheetSolver

Namespace DWSIM.SimulationObjects.UnitOps

    <System.Serializable()> Public Class ExcelUO

        Inherits SimulationObjects_UnitOpBaseClass

        Public Enum CalculationMode
            HeatAdded = 0
            OutletTemperature = 1
            EnergyStream = 2
            OutletVaporFraction = 3
        End Enum

        Protected m_dp As Nullable(Of Double)
        Protected m_dt As Nullable(Of Double)
        Protected m_DQ As Nullable(Of Double)
        Protected m_Tout As Nullable(Of Double)
        Protected m_VFout As Nullable(Of Double)
        Protected m_cmode As CalculationMode = CalculationMode.HeatAdded

        Protected m_eta As Nullable(Of Double) = 100

        Protected m_FixOnHeat As Boolean = True
        Protected m_FileName As String = ""

        Public Property Filename() As String
            Get
                Return m_FileName
            End Get
            Set(ByVal value As String)
                m_FileName = value
            End Set
        End Property

        Public Property FixOnHeat() As Boolean
            Get
                Return m_FixOnHeat
            End Get
            Set(ByVal value As Boolean)
                m_FixOnHeat = value
            End Set
        End Property

        Public Sub New(ByVal nome As String, ByVal descricao As String)
            MyBase.CreateNew()
            Me.m_ComponentName = nome
            Me.m_ComponentDescription = descricao
            Me.FillNodeItems()
            Me.QTFillNodeItems()
        End Sub

        Public Property Eficiencia() As Nullable(Of Double)
            Get
                Return m_eta
            End Get
            Set(ByVal value As Nullable(Of Double))
                m_eta = value
            End Set
        End Property

        Public Property OutletVaporFraction() As Nullable(Of Double)
            Get
                Return m_VFout
            End Get
            Set(ByVal value As Nullable(Of Double))
                m_VFout = value
            End Set
        End Property

        Public Property OutletTemperature() As Nullable(Of Double)
            Get
                Return m_Tout
            End Get
            Set(ByVal value As Nullable(Of Double))
                m_Tout = value
            End Set
        End Property

        Public Property CalcMode() As CalculationMode
            Get
                Return m_cmode
            End Get
            Set(ByVal value As CalculationMode)
                m_cmode = value
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

        Public Sub New()
            MyBase.New()
        End Sub

        Private Function ExctractFilepath(ByVal S As String) As String
            Dim P1, P2 As Integer
            P1 = InStr(1, S, "(") + 1
            P2 = InStrRev(S, "\") + 1

            Return Mid(S, P1, P2 - P1)
        End Function

        Public Overrides Function Calculate(Optional ByVal args As Object = Nothing) As Integer
            Dim form As Global.DWSIM.FormFlowsheet = Me.FlowSheet
            Dim objargs As New DWSIM.Outros.StatusChangeEventArgs
            Dim k As Integer

            Dim xcl As New Excel.Application()
            xcl.Visible = True 'uncomment for debugging

            Dim EXFN As String = ExctractFilepath(form.Text) & Filename
            Dim mybook As Excel.Workbook
            Dim AppPath = Application.StartupPath

            'Load Excel definition file
            If My.Computer.FileSystem.FileExists(EXFN) Then
                mybook = xcl.Workbooks.Open(EXFN)
            Else
                xcl.Quit()
                xcl.Dispose()
                Throw New Exception("Definition file '" & EXFN & "' :" & DWSIM.App.GetLocalString("Oarquivonoexisteoufo"))
            End If

            Dim mysheetIn As Excel.Worksheet = mybook.Sheets("Input")
            Dim mysheetOut As Excel.Worksheet = mybook.Sheets("Output")
            '=====================================================================================================

            If Not Me.GraphicObject.InputConnectors(4).IsAttached Then
                'Call function to calculate flowsheet
                With objargs
                    .Calculado = False
                    .Nome = Me.Nome
                    .Tipo = TipoObjeto.ExcelUO
                End With
                mybook.Close(saveChanges:=False)
                xcl.Quit()
                xcl.Dispose()
                CalculateFlowsheet(FlowSheet, objargs, Nothing)
                Throw New Exception(DWSIM.App.GetLocalString("Nohcorrentedeenergia2"))
            ElseIf Not Me.GraphicObject.OutputConnectors(0).IsAttached Then
                'Call function to calculate flowsheet
                With objargs
                    .Calculado = False
                    .Nome = Me.Nome
                    .Tipo = TipoObjeto.ExcelUO
                End With
                mybook.Close(saveChanges:=False)
                xcl.Quit()
                xcl.Dispose()
                CalculateFlowsheet(FlowSheet, objargs, Nothing)
                Throw New Exception(DWSIM.App.GetLocalString("Verifiqueasconexesdo"))
            ElseIf Not Me.GraphicObject.InputConnectors(0).IsAttached Then
                'Call function to calculate flowsheet
                With objargs
                    .Calculado = False
                    .Nome = Me.Nome
                    .Tipo = TipoObjeto.ExcelUO
                End With
                mybook.Close(saveChanges:=False)
                xcl.Quit()
                xcl.Dispose()
                CalculateFlowsheet(FlowSheet, objargs, Nothing)
                Throw New Exception(DWSIM.App.GetLocalString("Verifiqueasconexesdo"))
            End If

            Dim Ti, Pi, Hi, Wi, ei, ein, T2, P2, H2 As Double
            Dim es As DWSIM.SimulationObjects.Streams.EnergyStream = form.Collections.CLCS_EnergyStreamCollection(Me.GraphicObject.InputConnectors(4).AttachedConnector.AttachedFrom.Name)

            '======= read input stream data ===========================================================
            mysheetIn.Range("B5:E8").Value = "" 'delete Name, T, P, H of streams
            mysheetIn.Range("A12:E1000").Value = "" 'delete molar flows of streams

            Dim S As DWSIM.SimulationObjects.Streams.MaterialStream
            For k = 0 To 3
                If Me.GraphicObject.InputConnectors(k).IsAttached Then
                    S = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(k).AttachedConnector.AttachedFrom.Name)
                    Me.PropertyPackage.CurrentMaterialStream = S
                    Ti = S.Fases(0).SPMProperties.temperature.GetValueOrDefault.ToString
                    Pi = S.Fases(0).SPMProperties.pressure.GetValueOrDefault.ToString
                    Hi = S.Fases(0).SPMProperties.enthalpy.GetValueOrDefault.ToString
                    Wi = S.Fases(0).SPMProperties.massflow.GetValueOrDefault.ToString
                    ei = Hi * Wi
                    ein = ei

                    '======= transfer data to Excel ===========================================================
                    mysheetIn.Cells(5, 2 + k).Value = Me.GraphicObject.InputConnectors(k).AttachedConnector.AttachedFrom.Tag
                    mysheetIn.Cells(6, 2 + k).Value = Ti
                    mysheetIn.Cells(7, 2 + k).Value = Pi
                    mysheetIn.Cells(8, 2 + k).Value = Hi

                    Dim dy As Integer = 0
                    For Each comp As DWSIM.ClassesBasicasTermodinamica.Substancia In S.Fases(0).Componentes.Values

                        mysheetIn.Cells(12 + dy, 1).Value = comp.ConstantProperties.Name
                        mysheetIn.Cells(12 + dy, 2 + k).Value = comp.MolarFlow
                        dy += 1
                    Next
                Else
                    mysheetIn.Cells(6, 2 + k * 2).Value = ""
                    mysheetIn.Cells(7, 2 + k * 2).Value = ""
                    mysheetIn.Cells(8, 2 + k * 2).Value = ""
                    Dim dy As Integer = 0
                    For Each comp As DWSIM.ClassesBasicasTermodinamica.Substancia In Me.PropertyPackage.CurrentMaterialStream.Fases(0).Componentes.Values
                        mysheetIn.Cells(12 + dy, 1).Value = comp.ConstantProperties.Name
                        mysheetIn.Cells(12 + dy, 2 + k * 2).Value = ""
                        mysheetIn.Cells(12 + dy, 3 + k * 2).Value = ""
                        dy += 1
                    Next
                End If
            Next

          
            '======= read data from Excel =============================================================
            Dim Vmol As New Dictionary(Of String, Double)
            Dim i As Integer
            Dim v As Double
            Dim SMass, SMole As Double
            For k = 0 To 3 'run through all streams
                If Me.GraphicObject.OutputConnectors(k).IsAttached Then
                    Me.PropertyPackage.CurrentMaterialStream = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.OutputConnectors(k).AttachedConnector.AttachedTo.Name)

                    T2 = mysheetOut.Cells(6, 2 + k).Value
                    P2 = mysheetOut.Cells(7, 2 + k).Value

                    'Atribuir valores à corrente de matéria conectada à jusante
                    With Me.PropertyPackage.CurrentMaterialStream
                        .Fases(0).SPMProperties.temperature = T2
                        .Fases(0).SPMProperties.pressure = P2

                        Dim comp As DWSIM.ClassesBasicasTermodinamica.Substancia
                        i = 0
                        SMole = 0
                        SMass = 0
                        Vmol.Clear()
                        For Each comp In .Fases(0).Componentes.Values
                            v = mysheetOut.Cells(12 + i, 2 + k).Value
                            Vmol.Add(comp.Nome, v)
                            SMole += Vmol(comp.Nome)
                            SMass += Vmol(comp.Nome) * comp.ConstantProperties.Molar_Weight / 1000
                            i += 1
                        Next
                        For Each comp In .Fases(0).Componentes.Values
                            comp.FracaoMolar = Vmol(comp.Nome) / SMole
                            comp.FracaoMassica = Vmol(comp.Nome) * comp.ConstantProperties.Molar_Weight / SMass / 1000
                        Next
                        .Fases(0).SPMProperties.massflow = SMass

                        Dim tmp = Me.PropertyPackage.DW_CalcEquilibrio_ISOL(PropertyPackages.FlashSpec.T, PropertyPackages.FlashSpec.P, T2, P2, 0)
                        H2 = tmp(4)
                        .Fases(0).SPMProperties.enthalpy = H2
                    End With

                End If
            Next

            '======= caclculate output stream data ====================================================

            Me.DeltaT = T2 - Ti
            Me.DeltaQ = (H2 - Hi) / (Me.Eficiencia.GetValueOrDefault / 100) * Wi

            'Corrente de energia - atualizar valor da potência (kJ/s)
            With es
                .Energia = Me.DeltaQ.GetValueOrDefault
                .GraphicObject.Calculated = True
            End With

            


            '=============== clean up Excel stuff ================================================================
            mybook.Close(saveChanges:=True)
            xcl.Quit()
            xcl.Dispose()

            'Call function to calculate flowsheet
            With objargs
                .Calculado = True
                .Nome = Me.Nome
                .Tag = Me.GraphicObject.Tag
                .Tipo = TipoObjeto.ExcelUO
            End With


            '===========================================0
            form.CalculationQueue.Enqueue(objargs)

        End Function

        Public Overrides Function DeCalculate() As Integer
            Dim k As Integer
            Dim form As Global.DWSIM.FormFlowsheet = Me.FlowSheet

            For k = 0 To 3
                If Me.GraphicObject.OutputConnectors(k).IsAttached Then

                    'Zerar valores da corrente de matéria conectada a jusante
                    With form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.OutputConnectors(k).AttachedConnector.AttachedTo.Name)
                        .Fases(0).SPMProperties.temperature = Nothing
                        .Fases(0).SPMProperties.pressure = Nothing
                        .Fases(0).SPMProperties.enthalpy = Nothing
                        .Fases(0).SPMProperties.molarfraction = 1
                        .Fases(0).SPMProperties.massfraction = 1
                        Dim comp As DWSIM.ClassesBasicasTermodinamica.Substancia
                        Dim i As Integer = 0
                        For Each comp In .Fases(0).Componentes.Values
                            comp.FracaoMolar = 0
                            comp.FracaoMassica = 0
                            i += 1
                        Next
                        .Fases(0).SPMProperties.massflow = Nothing
                        .Fases(0).SPMProperties.molarflow = Nothing
                        .GraphicObject.Calculated = False
                    End With

                End If
            Next

           

            'Corrente de energia - atualizar valor da potência (kJ/s)
            If Me.GraphicObject.EnergyConnector.IsAttached Then
                With form.Collections.CLCS_EnergyStreamCollection(Me.GraphicObject.EnergyConnector.AttachedConnector.AttachedTo.Name)
                    .Energia = Nothing
                    .GraphicObject.Calculated = False
                End With
            End If

            'Call function to calculate flowsheet
            Dim objargs As New DWSIM.Outros.StatusChangeEventArgs
            With objargs
                .Calculado = False
                .Nome = Me.Nome
                .Tag = Me.GraphicObject.Tag
                .Tipo = TipoObjeto.Heater
            End With

            form.CalculationQueue.Enqueue(objargs)

        End Function

        Public Overloads Overrides Sub UpdatePropertyNodes(ByVal su As SistemasDeUnidades.Unidades, ByVal nf As String)

            Dim Conversor As New DWSIM.SistemasDeUnidades.Conversor
            If Me.NodeTableItems Is Nothing Then
                Me.NodeTableItems = New System.Collections.Generic.Dictionary(Of Integer, DWSIM.Outros.NodeItem)
                Me.FillNodeItems()
            End If

            For Each nti As Outros.NodeItem In Me.NodeTableItems.Values
                nti.Value = GetPropertyValue(nti.Text, FlowSheet.Options.SelectedUnitSystem)
                nti.Unit = GetPropertyUnit(nti.Text, FlowSheet.Options.SelectedUnitSystem)
            Next

            If Me.QTNodeTableItems Is Nothing Then
                Me.QTNodeTableItems = New System.Collections.Generic.Dictionary(Of Integer, DWSIM.Outros.NodeItem)
                Me.QTFillNodeItems()
            End If

            With Me.QTNodeTableItems

                Dim valor As String

                If Me.DeltaP.HasValue Then
                    valor = Format(Conversor.ConverterDoSI(su.spmp_deltaP, Me.DeltaP), nf)
                Else
                    valor = DWSIM.App.GetLocalString("NC")
                End If
                .Item(0).Value = valor
                .Item(0).Unit = su.spmp_deltaP

                If Me.DeltaT.HasValue Then
                    valor = Format(Conversor.ConverterDoSI(su.spmp_deltaT, Me.DeltaT), nf)
                Else
                    valor = DWSIM.App.GetLocalString("NC")
                End If
                .Item(1).Value = valor
                .Item(1).Unit = su.spmp_deltaT

                If Me.DeltaQ.HasValue Then
                    valor = Format(Conversor.ConverterDoSI(su.spmp_heatflow, Me.DeltaQ), nf)
                Else
                    valor = DWSIM.App.GetLocalString("NC")
                End If
                .Item(2).Value = valor
                .Item(2).Unit = su.spmp_heatflow

            End With

        End Sub

        Public Overrides Sub QTFillNodeItems()

            With Me.QTNodeTableItems

                .Clear()

                .Add(0, New DWSIM.Outros.NodeItem("DP", "", "", 0, 0, ""))
                .Add(1, New DWSIM.Outros.NodeItem("DT", "", "", 1, 0, ""))
                .Add(2, New DWSIM.Outros.NodeItem("Pot", "", "", 2, 0, ""))

            End With
        End Sub

        Public Overrides Sub PopulatePropertyGrid(ByRef pgrid As PropertyGridEx.PropertyGridEx, ByVal su As SistemasDeUnidades.Unidades)

            Dim Conversor As New DWSIM.SistemasDeUnidades.Conversor

            With pgrid

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True
                .Item.Clear()

                MyBase.PopulatePropertyGrid(pgrid, su)

                Dim ent1, ent2, ent3, ent4, saida1, saida2, saida3, saida4, energ As String
                If Me.GraphicObject.InputConnectors(0).IsAttached = True Then
                    ent1 = Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Tag
                Else
                    ent1 = ""
                End If
                If Me.GraphicObject.InputConnectors(1).IsAttached = True Then
                    ent2 = Me.GraphicObject.InputConnectors(1).AttachedConnector.AttachedFrom.Tag
                Else
                    ent2 = ""
                End If
                If Me.GraphicObject.InputConnectors(2).IsAttached = True Then
                    ent3 = Me.GraphicObject.InputConnectors(2).AttachedConnector.AttachedFrom.Tag
                Else
                    ent3 = ""
                End If
                If Me.GraphicObject.InputConnectors(3).IsAttached = True Then
                    ent4 = Me.GraphicObject.InputConnectors(3).AttachedConnector.AttachedFrom.Tag
                Else
                    ent4 = ""
                End If


                If Me.GraphicObject.OutputConnectors(0).IsAttached = True Then
                    saida1 = Me.GraphicObject.OutputConnectors(0).AttachedConnector.AttachedTo.Tag
                Else
                    saida1 = ""
                End If
                If Me.GraphicObject.OutputConnectors(1).IsAttached = True Then
                    saida2 = Me.GraphicObject.OutputConnectors(1).AttachedConnector.AttachedTo.Tag
                Else
                    saida2 = ""
                End If
                If Me.GraphicObject.OutputConnectors(2).IsAttached = True Then
                    saida3 = Me.GraphicObject.OutputConnectors(2).AttachedConnector.AttachedTo.Tag
                Else
                    saida3 = ""
                End If
                If Me.GraphicObject.OutputConnectors(3).IsAttached = True Then
                    saida4 = Me.GraphicObject.OutputConnectors(3).AttachedConnector.AttachedTo.Tag
                Else
                    saida4 = ""
                End If

                If Me.GraphicObject.InputConnectors(4).IsAttached = True Then
                    energ = Me.GraphicObject.InputConnectors(4).AttachedConnector.AttachedFrom.Tag
                Else
                    energ = ""
                End If

                '==== Input streams ===
                .Item.Add(DWSIM.App.GetLocalString("Correntedeentrada1"), ent1, False, DWSIM.App.GetLocalString("Conexes1"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New DWSIM.Editors.Streams.UIInputMSSelector
                End With
                .Item.Add(DWSIM.App.GetLocalString("Correntedeentrada2"), ent2, False, DWSIM.App.GetLocalString("Conexes1"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New DWSIM.Editors.Streams.UIInputMSSelector
                End With
                .Item.Add(DWSIM.App.GetLocalString("Correntedeentrada3"), ent3, False, DWSIM.App.GetLocalString("Conexes1"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New DWSIM.Editors.Streams.UIInputMSSelector
                End With
                .Item.Add(DWSIM.App.GetLocalString("Correntedeentrada4"), ent4, False, DWSIM.App.GetLocalString("Conexes1"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New DWSIM.Editors.Streams.UIInputMSSelector
                End With

                '==== Output streams ===
                .Item.Add(DWSIM.App.GetLocalString("Correntedesaida1"), saida1, False, DWSIM.App.GetLocalString("Conexes1"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New DWSIM.Editors.Streams.UIOutputMSSelector
                End With
                .Item.Add(DWSIM.App.GetLocalString("Correntedesaida2"), saida2, False, DWSIM.App.GetLocalString("Conexes1"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New DWSIM.Editors.Streams.UIOutputMSSelector
                End With
                .Item.Add(DWSIM.App.GetLocalString("Correntedesaida3"), saida3, False, DWSIM.App.GetLocalString("Conexes1"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New DWSIM.Editors.Streams.UIOutputMSSelector
                End With
                .Item.Add(DWSIM.App.GetLocalString("Correntedesaida4"), saida4, False, DWSIM.App.GetLocalString("Conexes1"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New DWSIM.Editors.Streams.UIOutputMSSelector
                End With

                .Item.Add(DWSIM.App.GetLocalString("Correntedeenergia"), energ, False, DWSIM.App.GetLocalString("Conexes1"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New DWSIM.Editors.Streams.UIInputESSelector
                End With

                Dim valor = Format(Conversor.ConverterDoSI(su.spmp_deltaP, Me.DeltaP.GetValueOrDefault), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(DWSIM.App.GetLocalString("Quedadepresso"), su.spmp_deltaP), valor, False, DWSIM.App.GetLocalString("Parmetrosdeclculo2"), DWSIM.App.GetLocalString("Quedadepressoaplicad3"), True)
                With .Item(.Item.Count - 1)
                    .Tag = New Object() {FlowSheet.Options.NumberFormat, su.spmp_deltaP, "DP"}
                    .CustomEditor = New DWSIM.Editors.Generic.UIUnitConverter
                End With


                .Item.Add(DWSIM.App.GetLocalString("HeaterCoolerCalcMode"), Me, "CalcMode", False, DWSIM.App.GetLocalString("Parmetrosdeclculo2"), "", True)

                Select Case Me.CalcMode

                    Case CalculationMode.EnergyStream

                    Case CalculationMode.HeatAdded

                        valor = Format(Conversor.ConverterDoSI(su.spmp_heatflow, Me.DeltaQ.GetValueOrDefault), FlowSheet.Options.NumberFormat)
                        .Item.Add(FT(DWSIM.App.GetLocalString("CalorFornecido"), su.spmp_heatflow), valor, False, DWSIM.App.GetLocalString("Parmetrosdeclculo2"), DWSIM.App.GetLocalString("Quantidadedecalorced"), True)
                        With .Item(.Item.Count - 1)
                            .Tag = New Object() {FlowSheet.Options.NumberFormat, su.spmp_heatflow, "E"}
                            .CustomEditor = New DWSIM.Editors.Generic.UIUnitConverter
                        End With

                    Case CalculationMode.OutletTemperature

                        valor = Format(Conversor.ConverterDoSI(su.spmp_temperature, Me.OutletTemperature.GetValueOrDefault), FlowSheet.Options.NumberFormat)
                        .Item.Add(FT(DWSIM.App.GetLocalString("HeaterCoolerOutletTemperature"), su.spmp_temperature), valor, False, DWSIM.App.GetLocalString("Parmetrosdeclculo2"), "", True)
                        With .Item(.Item.Count - 1)
                            .Tag = New Object() {FlowSheet.Options.NumberFormat, su.spmp_temperature, "T"}
                            .CustomEditor = New DWSIM.Editors.Generic.UIUnitConverter
                        End With

                    Case CalculationMode.OutletVaporFraction

                        valor = Format(Me.OutletVaporFraction.GetValueOrDefault, FlowSheet.Options.NumberFormat)
                        .Item.Add(DWSIM.App.GetLocalString("FraomolardafaseFaseV"), valor, False, DWSIM.App.GetLocalString("Parmetrosdeclculo2"), "", True)

                End Select
                .Item.Add("ExcelUOEditor", Me, "Filename", False, DWSIM.App.GetLocalString("Parmetrosdeclculo2"), "Excel file definition", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New DWSIM.Editors.ExcelUO.UIExcelUOEditor
                End With

                .Item.Add(DWSIM.App.GetLocalString("Eficincia0100"), Me, "Eficiencia", False, DWSIM.App.GetLocalString("Parmetrosdeclculo2"), DWSIM.App.GetLocalString("Eficinciadoaquecedor"), True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Nullable(Of Double))
                End With

                If Me.GraphicObject.Calculated And Not Me.CalcMode = CalculationMode.HeatAdded Then
                    valor = Format(Conversor.ConverterDoSI(su.spmp_heatflow, Me.DeltaQ.GetValueOrDefault), FlowSheet.Options.NumberFormat)
                    .Item.Add(FT(DWSIM.App.GetLocalString("CalorFornecido"), su.spmp_heatflow), valor, True, DWSIM.App.GetLocalString("Resultados3"), DWSIM.App.GetLocalString("Quantidadedecalorced"), True)
                End If

                .Item.Add(FT(DWSIM.App.GetLocalString("DeltaT2"), su.spmp_deltaT), Format(Conversor.ConverterDoSI(su.spmp_deltaT, Me.DeltaT.GetValueOrDefault), FlowSheet.Options.NumberFormat), True, DWSIM.App.GetLocalString("Resultados3"), DWSIM.App.GetLocalString("Diferenadetemperatur"), True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Nullable(Of Double))
                End With

                If Me.GraphicObject.Calculated = False Then
                    .Item.Add(DWSIM.App.GetLocalString("Mensagemdeerro"), Me, "ErrorMessage", True, DWSIM.App.GetLocalString("Miscelnea4"), DWSIM.App.GetLocalString("Mensagemretornadaqua"), True)
                    With .Item(.Item.Count - 1)
                        .DefaultType = GetType(System.String)
                    End With
                End If



            End With

        End Sub

        Public Overrides Function GetPropertyValue(ByVal prop As String, Optional ByVal su As SistemasDeUnidades.Unidades = Nothing) As Object

            If su Is Nothing Then su = New DWSIM.SistemasDeUnidades.UnidadesSI
            Dim cv As New DWSIM.SistemasDeUnidades.Conversor
            Dim value As Double = 0
            Dim propidx As Integer = CInt(prop.Split("_")(2))

            Select Case propidx

                Case 0
                    'PROP_HT_0	Pressure Drop
                    value = cv.ConverterDoSI(su.spmp_deltaP, Me.DeltaP.GetValueOrDefault)
                Case 1
                    'PROP_HT_1(Efficiency)
                    value = Me.Eficiencia.GetValueOrDefault
                Case 2
                    'PROP_HT_2	Outlet Temperature
                    value = cv.ConverterDoSI(su.spmp_temperature, Me.OutletTemperature.GetValueOrDefault)
                Case 3
                    'PROP_HT_3	Heat Added
                    value = cv.ConverterDoSI(su.spmp_heatflow, Me.DeltaQ.GetValueOrDefault)
                Case 4
                    'PROP_HT_4(Delta - T)
                    value = cv.ConverterDoSI(su.spmp_deltaT, Me.DeltaT.GetValueOrDefault)

            End Select

            Return value

        End Function

        Public Overloads Overrides Function GetProperties(ByVal proptype As SimulationObjects_BaseClass.PropertyType) As String()
            Dim i As Integer = 0
            Dim proplist As New ArrayList
            Select Case proptype
                Case PropertyType.RO
                    For i = 4 To 4
                        proplist.Add("PROP_HT_" + CStr(i))
                    Next
                Case PropertyType.RW
                    For i = 0 To 4
                        proplist.Add("PROP_HT_" + CStr(i))
                    Next
                Case PropertyType.WR
                    For i = 0 To 3
                        proplist.Add("PROP_HT_" + CStr(i))
                    Next
                Case PropertyType.ALL
                    For i = 0 To 4
                        proplist.Add("PROP_HT_" + CStr(i))
                    Next
            End Select
            Return proplist.ToArray(GetType(System.String))
            proplist = Nothing
        End Function

        Public Overrides Function SetPropertyValue(ByVal prop As String, ByVal propval As Object, Optional ByVal su As DWSIM.SistemasDeUnidades.Unidades = Nothing) As Object
            If su Is Nothing Then su = New DWSIM.SistemasDeUnidades.UnidadesSI
            Dim cv As New DWSIM.SistemasDeUnidades.Conversor
            Dim propidx As Integer = CInt(prop.Split("_")(2))

            Select Case propidx

                Case 0
                    'PROP_HT_0	Pressure Drop
                    Me.DeltaP = cv.ConverterParaSI(su.spmp_deltaP, propval)
                Case 1
                    'PROP_HT_1(Efficiency)
                    Me.Eficiencia = propval
                Case 2
                    'PROP_HT_2	Outlet Temperature
                    Me.OutletTemperature = cv.ConverterParaSI(su.spmp_temperature, propval)
                Case 3
                    'PROP_HT_3	Heat Added
                    Me.DeltaQ = cv.ConverterParaSI(su.spmp_heatflow, propval)

            End Select
            Return 1
        End Function

        Public Overrides Function GetPropertyUnit(ByVal prop As String, Optional ByVal su As SistemasDeUnidades.Unidades = Nothing) As Object
            If su Is Nothing Then su = New DWSIM.SistemasDeUnidades.UnidadesSI
            Dim cv As New DWSIM.SistemasDeUnidades.Conversor
            Dim value As String = ""
            Dim propidx As Integer = CInt(prop.Split("_")(2))

            Select Case propidx

                Case 0
                    'PROP_HT_0	Pressure Drop
                    value = su.spmp_deltaP
                Case 1
                    'PROP_HT_1(Efficiency)
                    value = ""
                Case 2
                    'PROP_HT_2	Outlet Temperature
                    value = su.spmp_temperature
                Case 3
                    'PROP_HT_3	Heat Added
                    value = su.spmp_heatflow
                Case 4
                    'PROP_HT_4(Delta - T)
                    value = su.spmp_deltaT

            End Select

            Return value
        End Function
    End Class

End Namespace