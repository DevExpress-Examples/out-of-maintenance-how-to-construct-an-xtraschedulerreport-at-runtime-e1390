#region #usings
using DevExpress.XtraReports.UI;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Reporting;
using DevExpress.XtraScheduler.Reporting.UI;
using System;
using System.Windows.Forms;
#endregion #usings

namespace ReportInCode {
    public partial class Form1 : Form {
        SchedulerDataStorage storage = new SchedulerDataStorage();
        public Form1() {
            InitializeComponent();
            DataHelper.FillStorageData(storage);   
        }
                
        private void btnReport_Click(object sender, EventArgs e)
        {
            #region #createreport         
            XtraSchedulerReport xr = new XtraSchedulerReport();            
            // Add a Day View to the Report.
            ReportDayView repDayView = new ReportDayView();
            xr.Views.Add(repDayView);
            // Start modifications.
            repDayView.BeginInit();
            // Specify the scheduler data source.
            xr.SchedulerAdapter = new SchedulerStoragePrintAdapter(storage);
            // Create the controls
            DayViewTimeCells dayCells = new DayViewTimeCells();
            DayViewTimeRuler repTimeRuler = new DayViewTimeRuler();
            HorizontalDateHeaders repDateHeaders = new HorizontalDateHeaders();
            // Find the report's Detail band and add controls.
            xr.Bands.Add(new DetailBand());
            Band band = xr.Bands.GetBandByType(typeof(DetailBand));
            band.Controls.Add(repDateHeaders);
            band.Controls.Add(dayCells);
            band.Controls.Add(repTimeRuler);
            // Place each day on a separate page.
            band.PageBreak = PageBreak.AfterBand;
            // Position the controls.
            repTimeRuler.Location = new System.Drawing.Point(0, 0);
            repDateHeaders.Location = new System.Drawing.Point(repTimeRuler.Width, 0);
            dayCells.Location = new System.Drawing.Point(repTimeRuler.Width, repDateHeaders.Height);
            // Specify the View. 
            dayCells.View = repDayView;
            repTimeRuler.View = repDayView;
            repDateHeaders.View = repDayView;
            // Link the controls.
            dayCells.HorizontalHeaders = repDateHeaders;
            repTimeRuler.TimeCells = dayCells;
            // Adjust the time ruler to fill the corner's gap.
            repTimeRuler.Corners.Top = repDateHeaders.Height;
            // Adjust the report height.
            dayCells.HeightF = 800F;
            repTimeRuler.HeightF = dayCells.HeightF + repTimeRuler.Corners.Top;
            // Set the half-hour time scale.
            dayCells.TimeScale = new TimeSpan(0, 30, 0);
           // Specify the time interval for the report.
            xr.SchedulerAdapter.TimeInterval = new TimeInterval(new DateTime(2010, 07, 14), new DateTime(2010, 07, 21));
            // Finalize the modifications.
            repDayView.EndInit();

            // Invoke the Report Designer and load the report for editing.
            SchedulerReportDesignTool tool = new SchedulerReportDesignTool(xr);
            tool.ShowRibbonDesignerDialog();
            #endregion #createreport
        }
    }
}