using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace lab4
{
    [StructLayout(LayoutKind.Sequential)]
    public class MEMORYSTATUSEX
    {
        public uint dwLength;
        public uint dwMemoryLoad;
        public ulong ullTotalPhys;
        public ulong ullAvailPhys;
        public ulong ullTotalPageFile;
        public ulong ullAvailPageFile;
        public ulong ullTotalVirtual;
        public ulong ullAvailVirtual;
        public ulong ullAvailExtendedVirtual;
        public MEMORYSTATUSEX()
        {
            this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SYSTEM_INFO
    {
        public processorArchitecture processorArchitecture;
        ushort reserved;
        public uint pageSize;
        public IntPtr minimumApplicationAddress;
        public IntPtr maximumApplicationAddress;
        public IntPtr activeProcessorMask;
        public uint numberOfProcessors;
        public uint processorType;
        public uint allocationGranularity;
        public ushort processorLevel;
        public ushort processorRevision;
    }

    public enum processorArchitecture : ushort
    {
        x86 = 0,
        x64 = 9,
        arm = 5,
        arm64 = 12,
        itaniumBased = 6,
        unknown = 0xFFFF,
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SYSTEM_POWER_STATUS
    {
        public ACLineStatus ACLineStatus;
        public BatteryFlag BatteryFlag;
        public byte BatteryLifePercent;
        public byte SystemFlagStatus;
        public int BatteryLifeTime;
        public int BatteryFullLifeTime;
    }

    public enum ACLineStatus : byte
    {
        Offline = 0,
        Online = 1,
        UnknownStatus = 255,
    }

    [Flags]
    public enum BatteryFlag : byte
    {
        High = 1,
        Low = 2,
        Critical = 4,
        Charging = 8,
        NoSystemBattery = 128,
        Unknown = 255,
    }

    class Program
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

        [DllImport("kernel32.dll")]
        internal static extern void GetNativeSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        [DllImport("advapi32.dll")]
        static extern bool GetUserName(StringBuilder sb, ref Int32 length);

        [DllImport("kernel32.dll")]
        static extern bool GetComputerNameEx(int NameType, StringBuilder lpBuffer,
            ref Int32 lpnSize);

        [DllImport("kernel32.dll")]
        internal static extern bool GetSystemPowerStatus(ref SYSTEM_POWER_STATUS powerStatus);

        static uint mb‬ = 1_048_576;

        static string GetNameOfComputer()
        {
            StringBuilder name = new StringBuilder();
            name.Clear();
            Int32 length = name.Capacity;
            if (!GetComputerNameEx(3, name, ref length))
            {
                name.Capacity = length;
                GetComputerNameEx(3, name, ref length);
            }
            name.Insert(0, "Computer name\n\t");
            name.AppendLine();
            return name.ToString();
        }

        static string GetNameOfUser()
        {
            StringBuilder name = new StringBuilder();
            Int32 length = name.Capacity;
            if (!GetUserName(name, ref length))
            {
                name.Capacity = length;
                GetUserName(name, ref length);
            }
            name.AppendLine();
            name.Insert(0, "User name\n\t");
            return name.ToString();
        }

        static string GetMemoryInfo()
        {
            StringBuilder info = new StringBuilder();
            MEMORYSTATUSEX memory = new MEMORYSTATUSEX();
            GlobalMemoryStatusEx(memory);
            info.AppendLine("Memory");
            info.AppendLine("\tPhys memory available : " + memory.ullAvailPhys / mb + "/"
                + memory.ullTotalPhys / mb + "mb" + " (" + memory.dwMemoryLoad + "% load)");
            info.AppendLine("\tVirtual memory available : " + memory.ullAvailVirtual / mb + "/"
                + memory.ullTotalVirtual / mb);
            info.AppendLine("\tPage file available : " + memory.ullAvailPageFile / mb + "/"
                + memory.ullTotalPageFile / mb);
            return info.ToString();
        }

        static string GetCpuInfo()
        {
            StringBuilder info = new StringBuilder();
            SYSTEM_INFO cpu = new SYSTEM_INFO();
            GetNativeSystemInfo(ref cpu);
            info.AppendLine("CPU");
            info.AppendLine("\tProcessor architecture : " + cpu.processorArchitecture);
            info.AppendLine("\tProcessor level : " + cpu.processorLevel);
            info.AppendLine("\tNumber of logical processors : " + cpu.numberOfProcessors);
            return info.ToString();
        }

        static string GetPowerInfo()
        {
            StringBuilder info = new StringBuilder();
            SYSTEM_POWER_STATUS power = new SYSTEM_POWER_STATUS();
            GetSystemPowerStatus(ref power);
            info.AppendLine("Power");
            info.AppendLine("\tAC power status : " + power.ACLineStatus);
            info.AppendLine("\tBattery charge status : " + power.BatteryFlag);
            if (power.BatteryFlag == BatteryFlag.NoSystemBattery) return info.ToString();
            info.AppendLine("\tBattery charge remaining : " + power.BatteryLifePercent + "%");
            if (power.BatteryLifeTime != -1)
                info.AppendLine("\tBattery life time remaining : " + power.BatteryLifeTime / 60 + " min");
            if (power.BatteryFullLifeTime != -1) 
                info.AppendLine("\tFull battery life time : " + power.BatteryFullLifeTime / 60 + " min");
            return info.ToString();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(GetNameOfComputer() + GetNameOfUser() + GetMemoryInfo() +
                    GetPowerInfo() + GetCpuInfo());
                Thread.Sleep(2000);
            }
        }
    }
}
