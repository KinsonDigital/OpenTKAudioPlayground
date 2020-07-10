using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace OpenTKAudioPlayground
{
    public struct WavHeader
    {
        public byte[] riffID; // "riff"
        public uint size;  // File Size
        public byte[] wavID;  // "WAVE"
        public byte[] fmtID;  // "fmt "
        public uint fmtSize; // Number of bytes in chunk
        public ushort format; // Format
        public ushort channels; // Number of channels
        public uint sampleRate; // Sampling rate
        public uint bytePerSec; // Data rate
        public ushort blockSize; // Block size
        public ushort bit;  // Number of quantization bits
        public byte[] dataID; // "data"
        public uint dataSize; // Number of bytes of waveform data
    }

    // Read and write Wave file
    // Support 16bit format only
    // The read data will be stored in List<short>
    public class WaveFileLoader
    {
        private WavHeader _headerData = new WavHeader();
        private List<short> _lDataList = new List<short>();
        private List<short> _rDataList = new List<short>();

        public WaveFileLoader()
        {
        }


        public short[] Data => _lDataList.ToArray();

        public void LoadData(string fileName)
        {
            //?? Note sure why we are saving the data in 2 arrays
            _lDataList = new List<short>();
            _rDataList = new List<short>();

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                try
                {
                    _headerData.riffID = br.ReadBytes(4);
                    _headerData.size = br.ReadUInt32();
                    _headerData.wavID = br.ReadBytes(4);
                    _headerData.fmtID = br.ReadBytes(4);
                    _headerData.fmtSize = br.ReadUInt32();
                    _headerData.format = br.ReadUInt16();
                    _headerData.channels = br.ReadUInt16();
                    _headerData.sampleRate = br.ReadUInt32();
                    _headerData.bytePerSec = br.ReadUInt32();
                    _headerData.blockSize = br.ReadUInt16();
                    _headerData.bit = br.ReadUInt16();
                    _headerData.dataID = br.ReadBytes(4);
                    _headerData.dataSize = br.ReadUInt32();

                    for (int i = 0; i < _headerData.dataSize / _headerData.blockSize; i++)
                    {
                        _lDataList.Add((short)br.ReadUInt16());
                        _rDataList.Add((short)br.ReadUInt16());
                    }
                }
                finally
                {
                    if (br != null)
                    {
                        br.Close();
                    }
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }

            return;
        }

        public void WriteData(string fileName)
        {
            List<short> lNewDataList = _lDataList;
            List<short> rNewDataList = _rDataList;

            _headerData.dataSize = (uint)Math.Max(lNewDataList.Count, rNewDataList.Count) * 4;

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                try
                {
                    bw.Write(_headerData.riffID);
                    bw.Write(_headerData.size);
                    bw.Write(_headerData.wavID);
                    bw.Write(_headerData.fmtID);
                    bw.Write(_headerData.fmtSize);
                    bw.Write(_headerData.format);
                    bw.Write(_headerData.channels);
                    bw.Write(_headerData.sampleRate);
                    bw.Write(_headerData.bytePerSec);
                    bw.Write(_headerData.blockSize);
                    bw.Write(_headerData.bit);
                    bw.Write(_headerData.dataID);
                    bw.Write(_headerData.dataSize);

                    for (int i = 0; i < _headerData.dataSize / _headerData.blockSize; i++)
                    {
                        if (i < lNewDataList.Count)
                        {
                            bw.Write((ushort)lNewDataList[i]);
                        }
                        else
                        {
                            bw.Write(0);
                        }

                        if (i < rNewDataList.Count)
                        {
                            bw.Write((ushort)rNewDataList[i]);
                        }
                        else
                        {
                            bw.Write(0);
                        }
                    }
                }
                finally
                {
                    if (bw != null)
                    {
                        bw.Close();
                    }
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
        }
    }
}
