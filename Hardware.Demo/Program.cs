#region File Header

// Solution: Hardware.Libs
// Project: Hardware.Demo
// FileName: Program.cs
// Create Time: 2022-11-21 9:37
// Update Time: 2022-11-21 11:42
// Updator: Zhangchi Bao

#endregion

#region Import Namespaces

using System;
using Hardware.LocalInformation;

#endregion

namespace Hardware.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
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