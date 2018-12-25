#Region "#usings"
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Reporting
Imports DevExpress.XtraScheduler.Reporting.UI
Imports System
Imports System.Windows.Forms
#End Region ' #usings

Namespace ReportInCode
    Partial Public Class Form1
        Inherits Form

        Private storage As New SchedulerDataStorage()
        Public Sub New()
            InitializeComponent()
            DataHelper.FillStorageData(storage)
        End Sub

        Private Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReportCreate.Click
'            #Region "#createreport         "
            Dim xr As New XtraSchedulerReport()
            ' Add a Day View to the Report.
            Dim repDayView As New ReportDayView()
            xr.Views.Add(repDayView)
            ' Start modifications.
            repDayView.BeginInit()
            ' Specify the scheduler data source.
            xr.SchedulerAdapter = New SchedulerStoragePrintAdapter(storage)
            ' Create the controls
            Dim dayCells As New DayViewTimeCells()
            Dim repTimeRuler As New DayViewTimeRuler()
            Dim repDateHeaders As New HorizontalDateHeaders()
            ' Find the report's Detail band and add controls.
            xr.Bands.Add(New DetailBand())
            Dim band As Band = xr.Bands.GetBandByType(GetType(DetailBand))
            band.Controls.Add(repDateHeaders)
            band.Controls.Add(dayCells)
            band.Controls.Add(repTimeRuler)
            ' Place each day on a separate page.
            band.PageBreak = PageBreak.AfterBand
            ' Position the controls.
            repTimeRuler.Location = New System.Drawing.Point(0, 0)
            repDateHeaders.Location = New System.Drawing.Point(repTimeRuler.Width, 0)
            dayCells.Location = New System.Drawing.Point(repTimeRuler.Width, repDateHeaders.Height)
            ' Specify the View. 
            dayCells.View = repDayView
            repTimeRuler.View = repDayView
            repDateHeaders.View = repDayView
            ' Link the controls.
            dayCells.HorizontalHeaders = repDateHeaders
            repTimeRuler.TimeCells = dayCells
            ' Adjust the time ruler to fill the corner's gap.
            repTimeRuler.Corners.Top = repDateHeaders.Height
            ' Adjust the report height.
            dayCells.HeightF = 800F
            repTimeRuler.HeightF = dayCells.HeightF + repTimeRuler.Corners.Top
            ' Set the half-hour time scale.
            dayCells.TimeScale = New TimeSpan(0, 30, 0)
           ' Specify the time interval for the report.
            xr.SchedulerAdapter.TimeInterval = New TimeInterval(New Date(2010, 07, 14), New Date(2010, 07, 21))
            ' Finalize the modifications.
            repDayView.EndInit()

            ' Invoke the Report Designer and load the report for editing.
            Dim tool As New SchedulerReportDesignTool(xr)
            tool.ShowRibbonDesignerDialog()
'            #End Region ' #createreport
        End Sub
    End Class
End Namespace