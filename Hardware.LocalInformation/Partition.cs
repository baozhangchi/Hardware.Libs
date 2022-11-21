#region File Header

// Solution: Hardware.Libs
// Project: Hardware.LocalInformation
// FileName: Partition.cs
// Create Time: 2022-11-21 9:37
// Update Time: 2022-11-21 11:42
// Updator: Zhangchi Bao

#endregion

#region Import Namespaces

using System.Collections.Generic;
using System.IO;
using System.Linq;
using CZGL.SystemInfo;

#endregion

namespace Hardware.LocalInformation
{
    public class Partition
    {
        private static readonly string[] HardDiskFileSystems = { "ext3", "ext4", "NTFS", "exFAT", "fat32" };

        public List<PartitionInfo> GetPartitionInfos()
        {
            var disks = DiskInfo.GetDisks()
                .Where(x => x.DriveType == DriveType.Fixed && HardDiskFileSystems.Contains(x.FileSystem)).ToList();
            return disks.Select(x => new PartitionInfo
            {
                Label = string.IsNullOrWhiteSpace(x.DriveInfo.VolumeLabel) ? x.Name : x.DriveInfo.VolumeLabel,
                Name = x.Name,
                Format = x.FileSystem,
                Type = x.DriveType,
                FreeSpace = x.FreeSpace,
                TotalSpace = x.TotalSize
            }).ToList();
        }
    }

    public class PartitionInfo
    {
        /// <summary>
        /// </summary>
        public string Label { get; set; }

        public string Name { get; set; }
        public string Format { get; set; }
        public DriveType Type { get; set; }
        public long FreeSpace { get; set; }
        public long TotalSpace { get; set; }

        public override string ToString()
        {
            return $"Label: {Label}\tName: {Name}\tFormat: {Format}\t{FreeSpace}/{TotalSpace}";
        }
    }
}