#region File Header

// Solution: Hardware.Libs
// Project: Hardware.LocalInformation
// FileName: RunTime.cs
// Create Time: 2022-11-21 9:37
// Update Time: 2022-11-21 10:29

#endregion

#region Import Namespaces

using System;

#endregion

namespace Hardware.LocalInformation
{
    public class RunTime
    {
        public RamInfo GetRamInfo()
        {
#if Windows
            var output = ShellUtil.Execute("wmic", "OS get FreePhysicalMemory,TotalVisibleMemorySize /Value");
            var lines = output.Trim().Split("\n");
            var freeMemoryParts = lines[0].Split("=", StringSplitOptions.RemoveEmptyEntries);
            var totalMemoryParts = lines[1].Split("=", StringSplitOptions.RemoveEmptyEntries);
            var total = long.Parse(totalMemoryParts[1]);
            var free = long.Parse(freeMemoryParts[1]);
            return new RamInfo
            {
                Total = total,
                Free = free,
                Used = total - free
            };
#else
var output = ShellUtil.Bash("free -m");
                var lines = output.Split("\n");
                var memory = lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                return new
                {
                    Total = long.Parse(memory[1]),
                    Used = long.Parse(memory[2]),
                    Free = long.Parse(memory[3])
                };
#endif
        }
    }

    public class RamInfo
    {
        public long Total { get; internal set; }
        public long Free { get; internal set; }
        public long Used { get; internal set; }

        public override string ToString()
        {
            return $"Total: {Total}\tUsed: {Used}\tFree: {Free}\tPercent: {(double)Free / Total:P}";
        }
    }
}