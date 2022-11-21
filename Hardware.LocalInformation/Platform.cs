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
                OSVersion = SystemPlatformInfo.OSVersion,
                OSDescription=SystemPlatformInfo.OSDescription
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
            return $"Architecture: {OSArchitecture}\tPlatform: {OSPlatformID}\tVersion: {OSVersion}\tOSDescription: {OSDescription}";
        }
    }
}