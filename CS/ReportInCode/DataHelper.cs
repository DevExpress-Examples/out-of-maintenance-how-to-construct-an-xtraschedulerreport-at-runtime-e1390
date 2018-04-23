using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraScheduler;
using System.IO;

namespace ReportInCode {
    class DataHelper {
        public const string aptDataResourceName = "ReportInCode.Data.appointments.xml";
        public const string resDataResourceName = "ReportInCode.Data.resources.xml";
        public const string templateName = "ReportInCode.Templates.WeeklyStyle.repx";


        public static Stream GetTemplate() {
            return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(templateName);
        
        }
        
        public static void FillStorageData(SchedulerStorage storage) {
            FillStorageCollection(storage.Resources.Items, resDataResourceName);
            FillStorageCollection(storage.Appointments.Items, aptDataResourceName);
        }

        static void FillStorageCollection(AppointmentCollection c, string resourceName) {
            using(Stream stream = GetResourceStream(resourceName)) {
                c.ReadXml(stream);
                stream.Close();
            }
        }
        static void FillStorageCollection(ResourceCollection c, string resourceName) {
            using(Stream stream = GetResourceStream(resourceName)) {
                c.ReadXml(stream);
                stream.Close();
            }
        }

        static Stream GetResourceStream(string resourceName) {
            return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }




    }
}
