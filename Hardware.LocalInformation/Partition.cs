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
        ///     卷标
        /// </summary>
        public string Label { get; internal set; }

        /// <summary>
        ///     名称
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     格式
        /// </summary>
        public string Format { get; internal set; }

        /// <summary>
        ///     分区类型
        /// </summary>
        public DriveType Type { get; internal set; }

        /// <summary>
        ///     可用空间
        /// </summary>
        public long FreeSpace { get; internal set; }

        /// <summary>
        ///     所有空间
        /// </summary>
        public long TotalSpace { get; internal set; }

        public override string ToString()
        {
            return $"Label: {Label}\tName: {Name}\tFormat: {Format}\t{FreeSpace}/{TotalSpace}";
        }
    }
}