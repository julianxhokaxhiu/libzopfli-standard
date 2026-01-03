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
    /// <summary>
    /// x86 Zopfli Compressor Hooks
    /// </summary>
    public class ZopfliCompressor
    {
        /// <summary>
        /// Compresses according to the given output format and appends the result to the output.
        /// </summary>
        /// <param name="options">Zopfli program options</param>
        /// <param name="output_type">The output format to use</param>
        /// <param name="data">Pointer to the data</param>
        /// <param name="data_size">This is the size of the memory block pointed to by data</param>
        /// <param name="data_out">Pointer to the dynamic output array to which the result is appended</param>
        /// <param name="data_out_size">This is the size of the memory block pointed to by the dynamic output array size</param>
        [DllImport("libzopfli", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ZopfliCompress(ref ZopfliOptions options, ZopfliFormat output_type, byte[] data, int data_size, ref IntPtr data_out, ref UIntPtr data_out_size);

        /// <summary>
        /// Initializes options with default values
        /// </summary>
        /// <param name="options">Zopfli program options</param>
        [DllImport("libzopfli", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ZopfliInitOptions(ref ZopfliOptions options);
    }
}
