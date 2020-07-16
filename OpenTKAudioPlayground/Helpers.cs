using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenTKAudioPlayground
{
    public static class Helpers
    {
        public static void SaveData(byte[] data, int columnCount, string fileName)
        {
            var csvData = new StringBuilder();

            var row = new List<byte>();

            int itemIndex = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (i == 0)
                {
                    row.Add(data[i]);
                }
                else
                {
                    if (itemIndex % columnCount == 0)
                    {
                        csvData.Append(RowData(row.ToArray()));
                        row.Clear();
                        row.Add(data[i]);
                    }
                    else
                    {
                        row.Add(data[i]);
                    }
                }

                itemIndex += 1;
            }

            File.WriteAllText(fileName, csvData.ToString());
        }


        private static string RowData(byte[] rowData)
        {
            var result = new StringBuilder();

            for (int i = 0; i < rowData.Length; i++)
            {
                result.Append($"{rowData[i]}{(i < rowData.Length - 1 ? "," : ",\r\n")}");
            }


            return result.ToString();
        }
    }
}
