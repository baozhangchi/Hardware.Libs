#region FileHeader

// FileName: Partition.cs
// ProjectName: Hardware.LocalInformation
// CreateTime: 2022-11-18 16:11
// UpdateTime: 2022-11-18 16:11
// Updator: zhangchi

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using CZGL.SystemInfo;

namespace Hardware.LocalInformation
{
    public class Partition
    {
        private static readonly string[] HardDiskFileSystems = new[] { "ext3", "ext4", "NTFS", "exFAT", "fat32" };

        public List<PartitionInfo> GetPartitionInfos()
        {
            var disks = DiskInfo.GetDisks()
                .Where(x => x.DriveType == DriveType.Fixed && HardDiskFileSystems.Contains(x.FileSystem)).ToList();
            return disks.Select(x => new PartitionInfo
            {
                Label = x.DriveInfo.VolumeLabel,
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
        /// 
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