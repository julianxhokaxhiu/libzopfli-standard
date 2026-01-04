using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibZopfliStandard
{
    public enum ZopfliPNGFilterStrategy : int
    {
        kStrategyZero = 0,
        kStrategyOne = 1,
        kStrategyTwo = 2,
        kStrategyThree = 3,
        kStrategyFour = 4,
        kStrategyMinSum,
        kStrategyEntropy,
        kStrategyPredefined,
        kStrategyBruteForce,
        kNumFilterStrategies // Not a strategy but used for the size of this enum
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct ZopfliPNGOptions
    {
        // Allow altering hidden colors of fully transparent pixels
        public bool lossy_transparent;

        // Convert 16-bit per channel images to 8-bit per channel
        public bool lossy_8bit;

        // Filter strategies to try
        public ZopfliPNGFilterStrategy[] filter_strategies;
        public int num_filter_strategies;

        // Automatically choose filter strategy using less good compression
        public bool auto_filter_strategy;

        // PNG chunks to keep
        // chunks to literally copy over from the original PNG to the resulting one
        public String[] keepchunks;
        public int num_keepchunks;

        // Use Zopfli deflate compression
        public bool use_zopfli;

        // Zopfli number of iterations
        public int num_iterations;

        // Zopfli number of iterations on large images
        public int num_iterations_large;

        // 0=none, 1=first, 2=last, 3=both
        public int block_split_strategy;

        /// <summary>
        /// Initializes options used throughout the program with default values.
        /// </summary>
        public ZopfliPNGOptions()
        {
            lossy_transparent = false;
            lossy_8bit = false;
            filter_strategies = new ZopfliPNGFilterStrategy[0];
            num_filter_strategies = 0;
            auto_filter_strategy = true;
            keepchunks = new String[0];
            num_keepchunks = 0;
            use_zopfli = true;
            num_iterations = 15;
            num_iterations_large = 5;
            block_split_strategy = 1;
        }
    }
}
