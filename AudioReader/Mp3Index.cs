﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AudioReader
{
    class Mp3Index
    {
        public long FilePosition { get; set; }
        public long SamplePosition { get; set; }
        public int SampleCount { get; set; }
        public int ByteCount { get; set; }
    }
}