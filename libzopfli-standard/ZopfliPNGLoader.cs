using LibZopfliStandard.Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibZopfliStandard
{
    internal static class ZopfliPNGLoader
    {
        private const string LIB_NAME = "libzopflipng";

        private static bool _loaded = false;
        private static readonly object _lock = new object();

        public static void EnsureLoaded()
        {
            if (_loaded) return;

            lock (_lock)
            {
                if (_loaded) return;

                NativeLibrary.SetDllImportResolver(typeof(ZopfliCompressor).Assembly, Resolver);
                _loaded = true;
            }
        }

        private static IntPtr Resolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName != LIB_NAME)
                return IntPtr.Zero;

            string libFileName = GetLibFileName();
            string rid = GetRuntimeIdentifier();
            string basePath = AppContext.BaseDirectory;

            string fullPath = Path.Combine(basePath, "runtimes", rid, "native", libFileName);

            if (!File.Exists(fullPath))
                throw new DllNotFoundException($"Cannot find native library: {fullPath}");

            return NativeLibrary.Load(fullPath);
        }

        private static string GetLibFileName()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return "zopflipng.dll";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return "libzopflipng.so";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return "libzopflipng.dylib";
            throw new PlatformNotSupportedException("Unsupported OS");
        }

        private static string GetRuntimeIdentifier()
        {
            var arch = RuntimeInformation.ProcessArchitecture switch
            {
                Architecture.X64 => "x64",
                Architecture.X86 => "x86",
                Architecture.Arm64 => "arm64",
                Architecture.Arm => "arm",
                _ => throw new NotSupportedException("Unsupported architecture")
            };

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return $"win-{arch}";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return $"linux-{arch}";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return $"osx-{arch}";

            throw new PlatformNotSupportedException("Unsupported OS");
        }
    }
}
