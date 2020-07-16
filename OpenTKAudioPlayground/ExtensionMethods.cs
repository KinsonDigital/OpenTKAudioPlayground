using System;
using System.Collections.Generic;
using System.Text;

namespace OpenTKAudioPlayground
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Maps the given <paramref name="value"/> from one range to another.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="fromStart">The from starting range value.</param>
        /// <param name="fromStop">The from ending range value.</param>
        /// <param name="toStart">The to starting range value.</param>
        /// <param name="toStop">The to ending range value.</param>
        /// <returns>A value that has been mapped to a range between <paramref name="toStart"/> and <paramref name="toStop"/>.</returns>
        public static short MapValue(this byte value, byte fromStart, byte fromStop, short toStart, short toStop)
            => (byte)(toStart + ((toStop - (float)toStart) * ((value - (float)fromStart) / (fromStop - (float)fromStart))));
    }
}
