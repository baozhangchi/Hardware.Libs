using System;
using CZGL.SystemInfo;
using CZGL.SystemInfo.Linux;

namespace Hardware.LocalInformation
{
    public class RunTime
    {
        public RamInfo GetRamInfo()
        {
#if Windows
            var total = SystemPlatformInfo.
            return new RamInfo()
            {
                Total = item.Total,
                Free = item.Free,
                Used = item.Used,
                CanUsed = item.CanUsed,
                Buffers = item.Buffers
            };
#else
            Console.WriteLine($"Get Ram on linux");
            DynamicInfo info = new DynamicInfo();
            Console.WriteLine(info == null);
            var item = info.GetMem();
            Console.WriteLine(item == null);
            return new RamInfo()
            {
                Total = item.Total,
                Free = item.Free,
                Used = item.Used,
                CanUsed = item.CanUsed,
                Buffers = item.Buffers
            };
#endif
        }

        public ProcessInfo GetProcessInfo()
        {
            DynamicInfo info = new DynamicInfo();
            var item = info.GetTasks();
            return new ProcessInfo()
            {
                Total = item.Total,
                Running = item.Running,
                Sleeping = item.Sleeping,
                Stopped = item.Stopped,
                Zombie = item.Zombie
            };
        }
    }

    public class ProcessInfo
    {
        public int Total { get; set; }
        public int Running { get; set; }
        public int Sleeping { get; set; }
        public int Stopped { get; set; }
        public int Zombie { get; set; }

        public override string ToString()
        {
            return $"Total: {Total}\tRunning: {Running}\tSleeping: {Sleeping}\tStopped: {Stopped}";
        }
    }

    public class RamInfo
    {
        public long Total { get; internal set; }
        public long Free { get; internal set; }
        public long Used { get; internal set; }
        public long CanUsed { get; internal set; }
        public long Buffers { get; internal set; }

        public override string ToString()
        {
            return $"Total: {Total}\tUsed: {Used}\tFree: {Free}\tPercent: {((double)Free / Total):P}";
        }
    }
}