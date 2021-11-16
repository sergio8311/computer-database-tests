using System;
using System.IO;
using System.Reflection;

namespace ComputerDatabase.Qa.Core.Helpers
{
    public static class LocationManager
    {
        private const string ScreenShotFolder = "Screenshots";
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string GetDefaultScreenshotDirectory()
        {
            var screenFolder = GetFolderUpwards(new DirectoryInfo(AssemblyDirectory), ScreenShotFolder);
            return screenFolder.FullName;
        }

        private static DirectoryInfo GetFolderUpwards(DirectoryInfo current, string folder)
        {
            var dirs = current.GetDirectories(folder);
            if (dirs.Length == 1)
            {
                return dirs[0];
            }

            if (current.Parent == null)
            {
                return null;
            }

            return GetFolderUpwards(current.Parent, folder);
        }
    }
}
