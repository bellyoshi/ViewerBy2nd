using System;
using System.IO;
using System.Reflection;

namespace ViewerBy2ndLib
{
    public class VLCDirectoryGetter
    {
        public static DirectoryInfo GetVlcLibDirectory()
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            if (currentAssembly == null) return null;
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            return new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

        }
    }
}
