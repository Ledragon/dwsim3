﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptEditorControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScriptEditorControl))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.textBoxTooltip = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbLinkedEvent = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbLinkedObject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkLink = New System.Windows.Forms.CheckBox()
        Me.txtScript = New Alsing.Windows.Forms.SyntaxBoxControl()
        Me.listBoxAutoComplete = New GListBox()
        Me.treeViewItems = New System.Windows.Forms.TreeView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.textBoxTooltip, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtScript, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.listBoxAutoComplete, 0, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'textBoxTooltip
        '
        Me.textBoxTooltip.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.textBoxTooltip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.textBoxTooltip, "textBoxTooltip")
        Me.textBoxTooltip.Name = "textBoxTooltip"
        Me.textBoxTooltip.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cbLinkedEvent)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbLinkedObject)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.chkLink)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'cbLinkedEvent
        '
        Me.cbLinkedEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLinkedEvent.FormattingEnabled = True
        resources.ApplyResources(Me.cbLinkedEvent, "cbLinkedEvent")
        Me.cbLinkedEvent.Name = "cbLinkedEvent"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cbLinkedObject
        '
        Me.cbLinkedObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLinkedObject.FormattingEnabled = True
        resources.ApplyResources(Me.cbLinkedObject, "cbLinkedObject")
        Me.cbLinkedObject.Name = "cbLinkedObject"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'chkLink
        '
        resources.ApplyResources(Me.chkLink, "chkLink")
        Me.chkLink.Name = "chkLink"
        Me.chkLink.UseVisualStyleBackColor = True
        '
        'txtScript
        '
        Me.txtScript.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight
        Me.txtScript.AllowBreakPoints = False
        Me.txtScript.AutoListPosition = Nothing
        Me.txtScript.AutoListSelectedText = "a123"
        Me.txtScript.AutoListVisible = False
        Me.txtScript.BackColor = System.Drawing.Color.White
        Me.txtScript.BorderStyle = Alsing.Windows.Forms.BorderStyle.None
        Me.txtScript.CopyAsRTF = True
        resources.ApplyResources(Me.txtScript, "txtScript")
        Me.txtScript.FontName = "Courier new"
        Me.txtScript.HighLightActiveLine = True
        Me.txtScript.InfoTipCount = 1
        Me.txtScript.InfoTipPosition = Nothing
        Me.txtScript.InfoTipSelectedIndex = 1
        Me.txtScript.InfoTipVisible = False
        Me.txtScript.LockCursorUpdate = False
        Me.txtScript.Name = "txtScript"
        Me.txtScript.ParseOnPaste = True
        Me.txtScript.ShowGutterMargin = False
        Me.txtScript.ShowScopeIndicator = False
        Me.txtScript.ShowTabGuides = True
        Me.txtScript.SmoothScroll = True
        Me.txtScript.SplitviewH = -4
        Me.txtScript.SplitviewV = -4
        Me.txtScript.TabGuideColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.txtScript.WhitespaceColor = System.Drawing.SystemColors.ControlDark
        '
        'listBoxAutoComplete
        '
        Me.listBoxAutoComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listBoxAutoComplete.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listBoxAutoComplete.FormattingEnabled = True
        Me.listBoxAutoComplete.ImageList = Nothing
        resources.ApplyResources(Me.listBoxAutoComplete, "listBoxAutoComplete")
        Me.listBoxAutoComplete.Name = "listBoxAutoComplete"
        '
        'treeViewItems
        '
        Me.treeViewItems.LineColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.treeViewItems, "treeViewItems")
        Me.treeViewItems.Name = "treeViewItems"
        '
        'ScriptEditorControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ScriptEditorControl"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents txtScript As Alsing.Windows.Forms.SyntaxBoxControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbLinkedEvent As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbLinkedObject As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkLink As System.Windows.Forms.CheckBox
    Public WithEvents treeViewItems As System.Windows.Forms.TreeView
    Friend WithEvents listBoxAutoComplete As GListBox
    Private WithEvents textBoxTooltip As System.Windows.Forms.TextBox

End Class
