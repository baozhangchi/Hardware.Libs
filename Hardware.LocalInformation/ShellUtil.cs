#region File Header

// Solution: Hardware.Libs
// Project: Hardware.LocalInformation
// FileName: ShellUtil.cs
// Create Time: 2022-11-21 10:18
// Update Time: 2022-11-21 10:21

#endregion

#region Import Namespaces

using System.Diagnostics;

#endregion

namespace Hardware.LocalInformation
{
    internal class ShellUtil
    {
        public static string Execute(string command, string args = null)
        {
#if Windows
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
#else
            var escapedArgs = command.Replace("\"", "\\\"");
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Dispose();
            return result;
#endif
        }
    }
}