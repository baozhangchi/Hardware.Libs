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
        public string OSArchitecture { get; set; }
        public string OSPlatformID { get; set; }
        public string OSVersion { get; set; }

        public string OSDescription { get; set; }

        public override string ToString()
        {
            return $"Architecture£º {OSArchitecture}\tPlatform: {OSPlatformID}\tVersion: {OSVersion}\tDescription: {OSDescription}";
        }
    }
}