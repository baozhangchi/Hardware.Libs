using CZGL.SystemInfo;

namespace Hardware.LocalInformation
{
    public class Platform
    {
        public PlatformInfo GetPlatformInfo()
        {
            return new PlatformInfo()
            {
                OSArchitecture = SystemPlatformInfo.OSArchitecture,
                OSPlatformID = SystemPlatformInfo.OSPlatformID,
                OSVersion = SystemPlatformInfo.OSVersion
            };
        }
    }

    public class PlatformInfo
    {
        public string OSArchitecture { get; set; }
        public string OSPlatformID { get; set; }
        public string OSVersion { get; set; }

        public override string ToString()
        {
            return $"Architecture�� {OSArchitecture}\tPlatform: {OSPlatformID}\tVersion: {OSVersion}";
        }
    }
}