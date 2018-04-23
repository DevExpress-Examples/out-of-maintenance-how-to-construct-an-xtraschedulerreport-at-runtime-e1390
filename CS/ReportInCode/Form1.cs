using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Reporting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraScheduler.Reporting.UI;

namespace ReportInCode {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        
        private void btnReport_Click(object sender, EventArgs e) {
            SchedulerStorage storage = new SchedulerStorage();
            DataHelper.FillStorageData(storage);            
            XtraSchedulerReport xr = new XtraSchedulerReport();
            
            // Add a Day View to the Report
            ReportDayView repDayView = new ReportDayView();
            xr.Views.Add(repDayView);
            // Start modifications
            repDayView.BeginInit();
            // Specify the scheduler data source
            xr.SchedulerAdapter = new SchedulerStoragePrintAdapter(storage);
            // Create the controls
            DayViewTimeCells dayCells = new DayViewTimeCells();
            DayViewTimeRuler repTimeRuler = new DayViewTimeRuler();
            HorizontalDateHeaders repDateHeaders = new HorizontalDateHeaders();
            // Find the report's Detail band and add controls
            xr.Bands.Add(new DetailBand());
            Band band = xr.Bands.GetBandByType(typeof(DetailBand));
            band.Controls.Add(repDateHeaders);
            band.Controls.Add(dayCells);
            band.Controls.Add(repTimeRuler);
            // Position the controls as required
            repTimeRuler.Location = new System.Drawing.Point(0, 0);
            repDateHeaders.Location = new System.Drawing.Point(repTimeRuler.Width, 0);
            dayCells.Location = new System.Drawing.Point(repTimeRuler.Width, repDateHeaders.Height);
            // Specify the View 
            dayCells.View = repDayView;
            repTimeRuler.View = repDayView;
            repDateHeaders.View = repDayView;
            // Link the controls
            dayCells.HorizontalHeaders = repDateHeaders;
            repTimeRuler.TimeCells = dayCells;
            // Adjust the time ruler to fill the corner's gap
            repTimeRuler.Corners.Top = repDateHeaders.Height;
            // Set the two-hour time scale
            dayCells.TimeScale = new TimeSpan(2, 0, 0);
           // Specify the time interval
            xr.SchedulerAdapter.TimeInterval = new TimeInterval(new DateTime(2008, 07, 14), new DateTime(2008, 07, 21));
            // Finish modifications
            repDayView.EndInit();
            // Invoke the report's Design Panel and load the report for editing.
            SchedulerReportDesignTool tool = new SchedulerReportDesignTool(xr);
            tool.ShowRibbonDesignerDialog();
        }

    
    }
}