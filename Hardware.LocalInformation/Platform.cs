#region File Header

// Solution: Hardware.Libs
// Project: Hardware.LocalInformation
// FileName: Platform.cs
// Create Time: 2022-11-21 9:37
// Update Time: 2022-11-21 11:42
// Updator: Zhangchi Bao

#endregion

#region Import Namespaces

using CZGL.SystemInfo;

#endregion

namespace Hardware.LocalInformation
{
    public class Platform
    {
        public PlatformInfo GetPlatformInfo()
        {
            return new PlatformInfo
            {
                OSArchitecture = SystemPlatformInfo.OSArchitecture,
                OSPlatformID = SystemPlatformInfo.OSPlatformID,
                OSVersion = SystemPlatformInfo.OSVersion,
                OSDescription = SystemPlatformInfo.OSDescription
            };
        }
    }

    public class PlatformInfo
    {
        /// <summary>
        /// 系统架构
        /// </summary>
        public string OSArchitecture { get; set; }
        
        /// <summary>
        /// 系统平台
        /// </summary>
        public string OSPlatformID { get; set; }
        
        /// <summary>
        /// 系统斑斑
        /// </summary>
        public string OSVersion { get; set; }
        
        /// <summary>
        /// 系统描述
        /// </summary>
        public string OSDescription { get; set; }

        public override string ToString()
        {
            return $"Architecture： {OSArchitecture}\tPlatform: {OSPlatformID}\tVersion: {OSVersion}\tDescription: {OSDescription}";
        }
    }
}