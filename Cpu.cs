using System.Collections.Generic;
using System.Management;

namespace SVN.Wmi
{
    public static class Cpu
    {
        public static IEnumerable<(string name, double percent)> Info
        {
            get
            {
                var query = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");

                foreach (var collection in query.Get())
                {
                    var name = collection["Name"].ToString();
                    var percent = double.Parse(collection["PercentProcessorTime"].ToString());
                    yield return (name, percent);
                }
            }
        }
    }
}