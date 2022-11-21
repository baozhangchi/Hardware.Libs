using System;
using Hardware.LocalInformation;

namespace Hardware.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var partitionInfos
                = new Partition().GetPartitionInfos();
            foreach (var partitionInfo in partitionInfos)
            {
                Console.WriteLine(partitionInfo);
            }

            var runtime = new RunTime();
            Console.WriteLine(runtime.GetRamInfo());
            Console.WriteLine(runtime.GetProcessInfo());
        }
    }
}