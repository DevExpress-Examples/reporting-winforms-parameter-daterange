Namespace Reporting_Date_Range_Report_Parameters
	Partial Public Class XtraReport1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
            Me.xrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.xrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.xrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'TopMargin
            '
            Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable1})
            Me.TopMargin.Name = "TopMargin"
            '
            'xrTable1
            '
            Me.xrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 75.0!)
            Me.xrTable1.Name = "xrTable1"
            Me.xrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
            Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow1})
            Me.xrTable1.SizeF = New System.Drawing.SizeF(650.0!, 25.0!)
            '
            'xrTableRow1
            '
            Me.xrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell1, Me.xrTableCell2})
            Me.xrTableRow1.Name = "xrTableRow1"
            Me.xrTableRow1.Weight = 11.5R
            '
            'xrTableCell1
            '
            Me.xrTableCell1.Multiline = True
            Me.xrTableCell1.Name = "xrTableCell1"
            Me.xrTableCell1.Text = "Customer ID"
            Me.xrTableCell1.Weight = 0.22222222222222221R
            '
            'xrTableCell2
            '
            Me.xrTableCell2.Multiline = True
            Me.xrTableCell2.Name = "xrTableCell2"
            Me.xrTableCell2.Text = "Order Date"
            Me.xrTableCell2.Weight = 0.22222222222222221R
            '
            'BottomMargin
            '
            Me.BottomMargin.Name = "BottomMargin"
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel2, Me.xrLabel1})
            Me.Detail.HeightF = 28.125!
            Me.Detail.Name = "Detail"
            '
            'xrLabel2
            '
            Me.xrLabel2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UpdatedOrderDate]")})
            Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(325.0!, 0!)
            Me.xrLabel2.Multiline = True
            Me.xrLabel2.Name = "xrLabel2"
            Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.xrLabel2.SizeF = New System.Drawing.SizeF(325.0!, 28.125!)
            Me.xrLabel2.Text = "xrLabel2"
            Me.xrLabel2.TextFormatString = "{0:d}"
            '
            'xrLabel1
            '
            Me.xrLabel1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CustomerID]")})
            Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.xrLabel1.Multiline = True
            Me.xrLabel1.Name = "xrLabel1"
            Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.xrLabel1.SizeF = New System.Drawing.SizeF(325.0!, 28.125!)
            Me.xrLabel1.Text = "xrLabel1"
            '
            'XtraReport1
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
            Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
            Me.Version = "22.2"
            CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

#End Region

        Private TopMargin As DevExpress.XtraReports.UI.TopMarginBand
		Private BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
		Private Detail As DevExpress.XtraReports.UI.DetailBand
		Private xrTable1 As DevExpress.XtraReports.UI.XRTable
		Private xrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
		Private xrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
		Private xrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
		Private xrLabel2 As DevExpress.XtraReports.UI.XRLabel
		Private xrLabel1 As DevExpress.XtraReports.UI.XRLabel
	End Class
End Namespace
