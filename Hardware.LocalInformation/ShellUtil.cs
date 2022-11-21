#region File Header

// Solution: Hardware.Libs
// Project: Hardware.LocalInformation
// FileName: ShellUtil.cs
// Create Time: 2022-11-21 10:18
// Update Time: 2022-11-21 11:42
// Updator: Zhangchi Bao

#endregion

#region Import Namespaces

using System.Diagnostics;

#endregion

namespace Hardware.LocalInformation
{
    internal class ShellUtil
    {
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string Execute(string command)
        {
#if Windows
            string output;
            var info = new ProcessStartInfo
            {
                FileName = command,
                RedirectStandardOutput = true
            };
#else
            var escapedArgs = command.Replace("\"", "\\\"");
            var info = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"-c \"{escapedArgs}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
#endif
            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
            }

            return output;
        }
        
#if Windows
        public static string Execute(string command, string args)
        {
            var output = string.Empty;
            var info = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                RedirectStandardOutput = true
            };
            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
            }

            return output;
        }
#endif
    }
}