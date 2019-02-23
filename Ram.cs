using System.Collections.Generic;
using System.Management;

namespace SVN.Wmi
{
    public static class Ram
    {
        public static IEnumerable<(long used, long total)> Info
        {
            get
            {
                var query = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OPeratingSystem");

                foreach (var collection in query.Get())
                {
                    var free = long.Parse(collection["FreePhysicalMemory"].ToString()) * 1000;
                    var total = long.Parse(collection["TotalVisibleMemorySize"].ToString()) * 1000;
                    var used = total - free;
                    yield return (used, total);
                }
            }
        }
    }
}