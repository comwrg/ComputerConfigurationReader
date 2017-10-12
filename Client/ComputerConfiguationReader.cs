using System;
using System.Collections.Generic;
using System.Management;

namespace Client
{
    public static class ComputerConfiguationReader
    {
        public static string GetCpuName()
        {
            var mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (var o in mos.Get())
            {
                var cpuName = o["Name"].ToString();
                return cpuName;
            }
            return String.Empty;
        }

        public static string GetBaseboard()
        {
            var mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (var o in mos.Get())
            {
                var product = o["Product"].ToString();
                var manufacturer = o["Manufacturer"].ToString();
                var baseborad = $"{manufacturer} {product}";
                return baseborad;
            }
            return String.Empty;
        }

        public static string GetBiosVersion()
        {
            var mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
            foreach (var o in mos.Get())
            {
                var boisVersion = o["Name"].ToString();
                return boisVersion;
            }
            return String.Empty;
        }

        public static List<string> GetDisplayName()
        {
            var mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DisplayConfiguration");
            List<string> list = new List<string>();
            foreach (var o in mos.Get())
            {
                var displayName = o["Caption"].ToString();
                list.Add(displayName);
            }
            return list;
        }

        public static List<string> GetMemoryInfo()
        {
            var mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
            List<string> list = new List<string>();
            foreach (var o in mos.Get())
            {
                var capacity = o["Capacity"].ToString();
                Int64 b = Int64.Parse(capacity);
                Int64 gb = b / 1024 / 1024 / 1024;

                var partNum = o["PartNumber"].ToString();
                
                list.Add($"{partNum} - {gb}GB");

            }
            return list;
        }
    }
}