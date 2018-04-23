Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Reporting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraScheduler.Reporting.UI

Namespace ReportInCode
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub


		Private Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReportCreate.Click
			Dim storage As New SchedulerStorage()
			DataHelper.FillStorageData(storage)
			Dim xr As New XtraSchedulerReport()

			' Add a Day View to the Report
			Dim repDayView As New ReportDayView()
			xr.Views.Add(repDayView)
			' Start modifications
			repDayView.BeginInit()
			' Specify the scheduler data source
			xr.SchedulerAdapter = New SchedulerStoragePrintAdapter(storage)
			' Create the controls
			Dim dayCells As New DayViewTimeCells()
			Dim repTimeRuler As New DayViewTimeRuler()
			Dim repDateHeaders As New HorizontalDateHeaders()
			' Find the report's Detail band and add controls
			xr.Bands.Add(New DetailBand())
			Dim band As Band = xr.Bands.GetBandByType(GetType(DetailBand))
			band.Controls.Add(repDateHeaders)
			band.Controls.Add(dayCells)
			band.Controls.Add(repTimeRuler)
			' Position the controls as required
			repTimeRuler.Location = New System.Drawing.Point(0, 0)
			repDateHeaders.Location = New System.Drawing.Point(repTimeRuler.Width, 0)
			dayCells.Location = New System.Drawing.Point(repTimeRuler.Width, repDateHeaders.Height)
			' Specify the View 
			dayCells.View = repDayView
			repTimeRuler.View = repDayView
			repDateHeaders.View = repDayView
			' Link the controls
			dayCells.HorizontalHeaders = repDateHeaders
			repTimeRuler.TimeCells = dayCells
			' Adjust the time ruler to fill the corner's gap
			repTimeRuler.Corners.Top = repDateHeaders.Height
			' Set the two-hour time scale
			dayCells.TimeScale = New TimeSpan(2, 0, 0)
		   ' Specify the time interval
			xr.SchedulerAdapter.TimeInterval = New TimeInterval(New DateTime(2008, 07, 14), New DateTime(2008, 07, 21))
			' Finish modifications
			repDayView.EndInit()
			' Invoke the report's Design Panel and load the report for editing.
			Dim tool As New SchedulerReportDesignTool(xr)
			tool.ShowRibbonDesignerDialog()
		End Sub


	End Class
End Namespace