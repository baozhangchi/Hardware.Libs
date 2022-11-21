﻿#region File Header

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
        public static string Execute(string fileName, string args)
        {
#if Windows
            string output;
            var info = new ProcessStartInfo
            {
                FileName = fileName,
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