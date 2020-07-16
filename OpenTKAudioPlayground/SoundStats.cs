using System;
using System.Collections.Generic;
using System.Text;

namespace OpenTKAudioPlayground
{
    internal struct SoundStats <T>
    {
        public T[] BufferData;

        public int SampleRate;

        public int Channels;

        public AudioFormat Format;

        public float TotalSeconds;
    }
}
