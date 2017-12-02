using System;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;
using System.Text;
using JurikSoft.Compression;
using System.Net;
using JurikSoft.XMLConfigImporer.JsRctServer.Version110;

public class ConmpressionEnvironment
{
    public ConmpressionEnvironment()
    {
        if (iCompressionArray_obj[1] != null) return;

        iCompressionArray_obj[1] = new JurikSoft.Compression.PrefixCodes(true);
        iCompressionArray_obj[2] = new JurikSoft.Compression.PrefixCodes(false);
        iCompressionArray_obj[3] = new JurikSoft.Compression.LZSS(8, true, true, false, 131072);
        iCompressionArray_obj[4] = new DeflateCompressionWrapper();
        iCompressionArray_obj[5] = new JurikSoft.Compression.RLE(JurikSoft.Compression.PrefixCodesCompression.NonAdaptive);

    }

    public static ICompression[] iCompressionArray_obj = new ICompression[6];

    public class DeflateCompressionWrapper : JurikSoft.Compression.ICompression
    {
        MemoryStream memoryStream_DecompressedData = new MemoryStream();
        MemoryStream memoryStream_DataToCompress = new MemoryStream();

        public byte[] Compress(byte[] DataToCompress, bool AddCheckSum)
        {
            memoryStream_DataToCompress.SetLength(0);

            DeflateStream deflateStream_obj = new DeflateStream(memoryStream_DataToCompress, CompressionMode.Compress, true);

            deflateStream_obj.Write(DataToCompress, 0, DataToCompress.Length);

            deflateStream_obj.Close();

            memoryStream_DataToCompress.SetLength(memoryStream_DataToCompress.Position);

            return memoryStream_DataToCompress.ToArray();
        }

        public byte[] Decompress(byte[] byteArray_DeflateCompressedData)
        {
            MemoryStream memoryStream_CompressedData = new MemoryStream(byteArray_DeflateCompressedData, 0, byteArray_DeflateCompressedData.Length);

            memoryStream_DecompressedData.SetLength(0);

            memoryStream_CompressedData.Position = 0;

            DeflateStream deflateStream_obj = new DeflateStream(memoryStream_CompressedData, CompressionMode.Decompress, true);

            int int_DecompressedByte = 0;

            for (; ; )
            {
                int_DecompressedByte = deflateStream_obj.ReadByte();

                if (int_DecompressedByte == -1) break;

                memoryStream_DecompressedData.WriteByte((byte)int_DecompressedByte);
            }

            deflateStream_obj.Flush();
            deflateStream_obj.Close();

            memoryStream_CompressedData.Close();

            memoryStream_DecompressedData.SetLength(memoryStream_DecompressedData.Position);

            return memoryStream_DecompressedData.ToArray();
        }

        public string SpreadToHundreds(string string_NecessaryString)
        {
            for (int int_LastDotPosition = string_NecessaryString.Length; int_LastDotPosition - 3 >= 1; int_LastDotPosition -= 3)
            {
                string_NecessaryString = string_NecessaryString.Insert(int_LastDotPosition - 3, ", ");
            }

            return string_NecessaryString;
        }
    }
}
