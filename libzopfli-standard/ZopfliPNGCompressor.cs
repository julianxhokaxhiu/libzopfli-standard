using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibZopfliStandard.Native
{
    /// <summary>
    /// x86 Native Hooks
    /// </summary>
    public class ZopfliPNGCompressor
    {
        /// <summary>
        /// Library to recompress and optimize PNG images. Uses Zopfli as the compression backend, chooses optimal PNG color model, and tries out several PNG filter strategies.
        /// </summary>
        
        /// <returns>Returns data size on success, error code otherwise.</returns>
        [DllImport("libzopflipng", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CZopfliPNGOptimize(byte[] origpng, UIntPtr origpngSize, ref ZopfliPNGOptions pngOptions, int verbose, out IntPtr resultpng, out UIntPtr resultpngSize);

        /// <summary>
        /// Sets the default options
        /// </summary>
        /// <param name="pngOptions"></param>
        [DllImport("libzopflipng", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CZopfliPNGSetDefaults(ref ZopfliPNGOptions pngOptions);
    }
}
