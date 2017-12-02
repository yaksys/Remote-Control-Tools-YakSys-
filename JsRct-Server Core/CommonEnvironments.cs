using System;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Data;
using System.Windows.Forms;
using JurikSoft.Compression;
using System.Net;
using JurikSoft.XMLConfigImporer.JsRctServer.Version110;

namespace JurikSoft
{
    namespace Server_Core
    {

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
            }
        }

        public class CommonMethods
        {     
            public static bool IsSecondIPAddressBiggerOrEquals(IPAddress iPAddress_FirstAddress, IPAddress iPAddress_SecondAddress)
            {
                byte[] byteArray_FirstAddress = iPAddress_FirstAddress.GetAddressBytes();
                byte[] byteArray_SecondAddress = iPAddress_SecondAddress.GetAddressBytes();

                if (byteArray_SecondAddress[0] > byteArray_FirstAddress[0]) return true;

                if (byteArray_SecondAddress[0] == byteArray_FirstAddress[0])
                {
                    if (byteArray_SecondAddress[1] > byteArray_FirstAddress[1]) return true;

                    if (byteArray_SecondAddress[1] == byteArray_FirstAddress[1])
                    {
                        if (byteArray_SecondAddress[2] > byteArray_FirstAddress[2]) return true;

                        if (byteArray_SecondAddress[2] == byteArray_FirstAddress[2])
                        {
                            if (byteArray_SecondAddress[3] >= byteArray_FirstAddress[3]) return true;
                            else return false;
                        }

                        else return false;
                    }
                    else return false;
                }
                else return false;
            }


            public static string ReadStringFromStream(MemoryStream obj_MemoryStream)
            {
                byte[] byteArray_StringLength = new byte[4];

                obj_MemoryStream.Read(byteArray_StringLength, 0, 4);

                byte[] byteArray_String = new byte[BitConverter.ToInt32(byteArray_StringLength, 0)];

                obj_MemoryStream.Read(byteArray_String, 0, BitConverter.ToInt32(byteArray_StringLength, 0));

                return Encoding.Unicode.GetString(byteArray_String);
            }

            public static int ReadIntFromStream(MemoryStream obj_MemoryStream)
            {
                byte[] byteArray_Int = new byte[4];

                obj_MemoryStream.Read(byteArray_Int, 0, 4);

                return BitConverter.ToInt32(byteArray_Int, 0);
            }

            public static long ReadInt64FromStream(MemoryStream obj_MemoryStream)
            {
                byte[] byteArray_Int = new byte[8];

                obj_MemoryStream.Read(byteArray_Int, 0, 8);

                return BitConverter.ToInt64(byteArray_Int, 0);
            }

            public static byte[] ReadBytesFromStream(MemoryStream obj_MemoryStream)
            {
                byte[] byteArray_BytesLength = new byte[4];

                obj_MemoryStream.Read(byteArray_BytesLength, 0, 4);

                byte[] byteArray_Bytes = new byte[BitConverter.ToInt32(byteArray_BytesLength, 0)];

                obj_MemoryStream.Read(byteArray_Bytes, 0, BitConverter.ToInt32(byteArray_BytesLength, 0));

                return byteArray_Bytes;
            }


            public static void WriteStringToStream(MemoryStream obj_MemoryStream, string string_StringForWrite)
            {
                byte[] byteArray_StringForWrite = Encoding.Unicode.GetBytes(string_StringForWrite),
                        byteArray_StringForWriteLength = BitConverter.GetBytes(byteArray_StringForWrite.Length);

                obj_MemoryStream.Write(byteArray_StringForWriteLength, 0, byteArray_StringForWriteLength.Length);

                obj_MemoryStream.Write(byteArray_StringForWrite, 0, byteArray_StringForWrite.Length);
            }

            public static void WriteIntToStream(MemoryStream obj_MemoryStream, int int_IntForWrite)
            {
                obj_MemoryStream.Write(BitConverter.GetBytes(int_IntForWrite), 0, 4);
            }

            public static void WriteInt64ToStream(MemoryStream obj_MemoryStream, Int64 int_IntForWrite)
            {
                obj_MemoryStream.Write(BitConverter.GetBytes(int_IntForWrite), 0, 8);
            }

            public static void WriteBytesToStream(MemoryStream obj_MemoryStream, byte[] byteArray_BytesForWrite)
            {
                byte[] byteArray_BytesForWriteLength = BitConverter.GetBytes(byteArray_BytesForWrite.Length);

                obj_MemoryStream.Write(byteArray_BytesForWriteLength, 0, byteArray_BytesForWriteLength.Length);

                obj_MemoryStream.Write(byteArray_BytesForWrite, 0, byteArray_BytesForWrite.Length);
            }


            public static byte[] GetByteArrayPart(byte[] byteArray_FullBytesArray, int int_StartPosition, int int_Length)
            {
                byte[] byteArray_NewBuffer = new byte[int_Length];

                int int_PositionInNewBuffer = 0;

                for (int int_CycleCount = 0; int_CycleCount != int_Length; int_CycleCount++, int_PositionInNewBuffer++)
                {
                    byteArray_NewBuffer[int_PositionInNewBuffer] = byteArray_FullBytesArray[int_StartPosition + int_CycleCount];
                }

                return byteArray_NewBuffer;
            }

            public static bool AreBytesArraysEquals(byte[] byteArray_InitialData, byte[] byteArray_ComparedData)
            {
                if (byteArray_InitialData.Length != byteArray_ComparedData.Length) return false;

                for (int int_CycleCount = 0; int_CycleCount != byteArray_InitialData.Length; int_CycleCount++)
                {
                    if (byteArray_InitialData[int_CycleCount] != byteArray_ComparedData[int_CycleCount]) return false;
                }

                return true;
            }

            public static string SpreadToHundreds(string string_NecessaryString)
            {
                for (int int_LastDotPosition = string_NecessaryString.Length; int_LastDotPosition - 3 >= 1; int_LastDotPosition -= 3)
                {
                    string_NecessaryString = string_NecessaryString.Insert(int_LastDotPosition - 3, ", ");
                }

                return string_NecessaryString;
            }
        }
    }
}