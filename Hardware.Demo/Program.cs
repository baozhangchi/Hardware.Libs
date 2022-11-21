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

            Console.WriteLine(new Platform().GetPlatformInfo());

            Console.WriteLine(new RunTime().GetRamInfo());
            Console.ReadKey();

        }
    }
}