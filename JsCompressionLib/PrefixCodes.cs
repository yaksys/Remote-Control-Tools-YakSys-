using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace YakSys
{
    namespace Compression
    {
        /// <summary>
        /// Represents the class of the PrefixCodes compression algorithm.
        /// </summary>
        public class PrefixCodes : ICompression
        {
            /// <summary>
            /// 
            ///Initializes a new instance of the PrefixCodes class with a model mode parameter indicates.
            /// 
            /// </summary>
            public PrefixCodes(bool UseAdaptiveCodingMethod)
            {
                this.UseAdaptiveCodingMethod = UseAdaptiveCodingMethod;

            }
            internal bool UseAdaptiveCodingMethod = false;

            #region Internal members declaration

            internal decimal[,] decimal_BytesSortedByOrder; // 256 cells of Amount(first = [x ,0]) and byte(second = [x ,1]) from decimalArray_BytesEntryFreq	
            internal short[] short_BytePositionInBytesArraySortedByOrder = new short[256]; // decimal_ByteIndexInNumbersSortedByOrder [x,0] - Byte, decimal_ByteIndexInNumbersSortedByOrder [x,1] - Index in decimal_NumbersSortedByOrder

            internal byte byte_NumberOfGroup = 0, byte_MostEffectiveSystemOfGroupsCoding = 0;
            internal short short_MultiplicationFactor = 0, short_PositiveNumbersAmount = 0;
            internal decimal decimal_BitsNeededForFirstSystemOfGroupsCoding = 0, decimal_BitsNeededForSecondSystemOfGroupsCoding = 0;

            /*
            internal ArrayList arrayList_MapOfPrefixCodes, arrayList_GroupsPosition,
                               arrayList_LengthOfIndex, arrayList_LengthOfGroups;
            */

            internal List<BitArray> arrayList_MapOfPrefixCodes;

            internal List<int> arrayList_GroupsPosition, arrayList_LengthOfIndex, arrayList_LengthOfGroups;
                

            internal BitArray bitArray_ReadedData = new BitArray(16);

            #endregion

            /// <summary> 
            /// Compress input byte array using PrefixCodes algorithm.
            /// </summary>
            /// 
            /// <returns> 
            /// An Compressed array of bytes with length > 0. 
            /// </returns>
            /// 
            /// <param name="DataToCompress">
            /// The input data to compress using PrefixCodes algorithm.
            /// </param>/ 	 
            /// 	
            /// <param name="AddCheckSum">
            /// Indicating whether add to compressed data MD5 Hash check sum.
            /// </param>
            /// 
            /// <example> This sample shows how to compress byte array.
            /// <code>
            /// //Initializes a new instance of the PrefixCodes class with a compression parameter
            /// //indicate the selected compression model is half adaptive
            /// YakSys.Compression.ICompression compressionObj = 
            /// new YakSys.Compression.PrefixCodes(false);
            /// 
            /// FileStream fileStream_DataFile = File.Open("test.dat");
            /// 
            /// byte [] byteArray_DataToCompress = new byte[fileStream_DataFile.Length],
            /// byte [] byteArray_CompressedData = null;
            /// 
            /// fileStream_DataFile.Read(byteArray_DataToCompress, 0, byteArray_DataToCompress.Length);
            /// 
            /// //Compress the data with adding MD5 hash check sum
            /// byteArray_CompressedData = compressionObj.Compress(byteArray_DataToCompress, true);
            /// 
            /// fileStream_DataFile.Close();
            /// 
            /// </code>
            /// </example>
            /// 
            public byte[] Compress(byte[] DataToCompress, bool AddCheckSum)
            {
                if (DataToCompress == null)
                    throw new CommonEnvironment.CompressedDataArrayIsNullReferenceException();

                if (DataToCompress.Length == 0)
                    throw new CommonEnvironment.CompressedDataHasZeroLengthException();

                byte[] byteArray_CompressedData = null, byteArray_HashOfDecompressedData = null;

                MemoryStream memoryStream_CompressedData = new MemoryStream();

                DataAnalyzer(DataToCompress, UseAdaptiveCodingMethod);

                if (UseAdaptiveCodingMethod) byteArray_CompressedData = CompressUsingAdaptivePrefixCodesMethod(DataToCompress);
                else byteArray_CompressedData = CompressUsingNonAdaptivePrefixCodesMethod(DataToCompress);

                memoryStream_CompressedData.Position = 45;

                #region Total Decompressed Size

                memoryStream_CompressedData.Write(BitConverter.GetBytes((UInt64)DataToCompress.Length), 0, 8);

                #endregion

                #region Write Hash Of Decompressed Data

                if (AddCheckSum)
                {
                    MD5CryptoServiceProvider md5CryptoServiceProvider_HashOfDecompressedData = null;

                    md5CryptoServiceProvider_HashOfDecompressedData = new MD5CryptoServiceProvider();

                    byteArray_HashOfDecompressedData = md5CryptoServiceProvider_HashOfDecompressedData.ComputeHash(DataToCompress, 0, DataToCompress.Length);

                    memoryStream_CompressedData.WriteByte(1);

                    memoryStream_CompressedData.Write(byteArray_HashOfDecompressedData, 0, byteArray_HashOfDecompressedData.Length);
                }
                else
                    memoryStream_CompressedData.WriteByte(0);

                #endregion

                memoryStream_CompressedData.Write(byteArray_CompressedData, 0, byteArray_CompressedData.Length);

                byteArray_CompressedData = memoryStream_CompressedData.ToArray();

                new CommonEnvironment().AddSystemInformation(ref byteArray_CompressedData, 0);

                return byteArray_CompressedData;
            }

            internal byte[] Decompress(byte[] DataToDecompress, bool VerifyCheckSum)
            {

                MemoryStream memoryStream_CompressedData = new MemoryStream(DataToDecompress);

                CommonEnvironment commonEnvironment_obj = new CommonEnvironment();

                UInt64 uInt64_StoredTotalDecompressedSize = 0, uInt64_ComputedTotalDecompressedSize;

                byte[] byteArray_DecompressedData = null,
                        byteArray_StoredHashOfDecompressedData = new byte[16],
                        byteArray_ComputedHashOfDecompressedData = new byte[16];

                byte byte_IsCheckSumExist = 0;

                uInt64_StoredTotalDecompressedSize = BitConverter.ToUInt64(memoryStream_CompressedData.ToArray(), 0);

                memoryStream_CompressedData.Position += 8;

                byte_IsCheckSumExist = (byte)memoryStream_CompressedData.ReadByte();

                if (byte_IsCheckSumExist == 1)
                {
                    memoryStream_CompressedData.Read(byteArray_StoredHashOfDecompressedData, 0, byteArray_StoredHashOfDecompressedData.Length);
                }


                DataToDecompress = new byte[memoryStream_CompressedData.Length - memoryStream_CompressedData.Position];

                memoryStream_CompressedData.Read(DataToDecompress, 0, DataToDecompress.Length);


                /* *
                 * 0 - Uncompressed
                 * 1 - Non Adaptive
                 * 2 - Adaptive
                 * 3 - 2 bytes code system
                 * */

                if (DataToDecompress[1] == 1 || DataToDecompress[1] == 3)
                {
                    byteArray_DecompressedData = DecompressUsingNonAdaptivePrefixCodesMethod(DataToDecompress);
                }
                if (DataToDecompress[1] == 2)
                {
                    byteArray_DecompressedData = DecompressUsingAdaptivePrefixCodesMethod(DataToDecompress);
                }

                uInt64_ComputedTotalDecompressedSize = (ulong)byteArray_DecompressedData.LongLength;

                if (uInt64_StoredTotalDecompressedSize != uInt64_ComputedTotalDecompressedSize)
                    throw new CommonEnvironment.WrongDecompressedSizeException();

                #region Verification to right hash

                if (byte_IsCheckSumExist == 1 && VerifyCheckSum == true)
                {
                    MD5CryptoServiceProvider md5CryptoServiceProvider_HashOfDecompressedData = new MD5CryptoServiceProvider();

                    byteArray_ComputedHashOfDecompressedData = md5CryptoServiceProvider_HashOfDecompressedData.ComputeHash(byteArray_DecompressedData, 0, (int)byteArray_DecompressedData.Length);

                    if (commonEnvironment_obj.IsBytesArraysEquals(ref byteArray_ComputedHashOfDecompressedData, ref byteArray_StoredHashOfDecompressedData) == false)
                        throw new CommonEnvironment.WrongDecompressedDataHashException();
                }

                #endregion

                return byteArray_DecompressedData;
            }


            internal void CalculateLengthsOfGroupsAndIndexers()
            {

                arrayList_GroupsPosition = new List<int>();
                arrayList_LengthOfIndex = new List<int>();
                arrayList_LengthOfGroups = new List<int>();

                int int_LastNumberOfGroup = -1, int_CurrentNumberOfGroup = 0,
                    int_CurrentLengthOfIndex = -1;

                BitArray bitArray_LastObject;

                // общий цикл для последовательной обработки всех кодов Хаффмана в массиве
                for (int int_CycleCount = 0; int_CycleCount != arrayList_MapOfPrefixCodes.Count; int_CycleCount++)
                {
                    bitArray_LastObject = (BitArray)arrayList_MapOfPrefixCodes[int_CycleCount];

                    // цикл для обработки текущего BitArray
                    foreach (bool bool_CurrentBit in bitArray_LastObject)
                    {
                        // последний код - состоящий ТОЛЬКО из единиц (true) потому длина индекса выставляется в -1
                        if (int_CurrentNumberOfGroup == bitArray_LastObject.Length - 1 && bitArray_LastObject[bitArray_LastObject.Length - 1] != false)
                        {
                            arrayList_LengthOfIndex.Add(-1);
                            arrayList_LengthOfGroups.Add(int_CurrentNumberOfGroup++);
                            arrayList_GroupsPosition.Add(int_CycleCount);
                        }

                        if (bool_CurrentBit == false)
                        {
                            if (int_LastNumberOfGroup == int_CurrentNumberOfGroup)
                            {
                                int_CurrentNumberOfGroup = 0;
                                break;
                            }

                            int_LastNumberOfGroup = int_CurrentNumberOfGroup;
                            int_CurrentLengthOfIndex = (bitArray_LastObject.Length - 1) - int_CurrentNumberOfGroup;

                            arrayList_LengthOfIndex.Add(int_CurrentLengthOfIndex);
                            arrayList_LengthOfGroups.Add(int_CurrentNumberOfGroup);
                            arrayList_GroupsPosition.Add(int_CycleCount);

                            int_CurrentNumberOfGroup = 0;

                            break;
                        }

                        int_CurrentNumberOfGroup++;
                    }
                }
            }


            internal int DataAnalyzer(byte[] byteArray_BytesToCompress, bool bool_ToUseAdaptiveCodingMethod)
            {
                decimal[] decimalArray_BytesEntryFreq = new decimal[256];

                foreach (byte byte_CurrentByte in byteArray_BytesToCompress)
                {
                    decimalArray_BytesEntryFreq[byte_CurrentByte]++;
                }

                #region Sort All Elements of decimalArray_BytesEntryFreq

                decimal[] decimal_CurrentMostBigNumber = new decimal[2]; // Current most big: Amount(first) and byte(second) in decimalArray_BytesEntryFreq
                decimal_CurrentMostBigNumber.Initialize();

                decimal_BytesSortedByOrder = new decimal[256, 2]; // 256 cells with Amount(first) and byte(second) from decimalArray_BytesEntryFreq
                decimal_BytesSortedByOrder.Initialize();

                short short_ProcessedCells = 0;

                decimal_CurrentMostBigNumber[0] = -1;

                for (short short_CycleCount = 0; short_CycleCount != 256; short_CycleCount++)
                {
                    if (decimal_CurrentMostBigNumber[0] < decimalArray_BytesEntryFreq[short_CycleCount])
                    {
                        decimal_CurrentMostBigNumber[0] = decimalArray_BytesEntryFreq[short_CycleCount]; // Сколько раз байт встречается
                        decimal_CurrentMostBigNumber[1] = short_CycleCount; // Какой байт
                    }

                    // знаем самое большее из оставшихся (!) число из последней обработанной из 256 ячеек
                    if (short_CycleCount == 255)
                    {
                        decimal_BytesSortedByOrder[short_ProcessedCells, 0] = decimal_CurrentMostBigNumber[0]; // Сколько раз байт встречается
                        decimal_BytesSortedByOrder[short_ProcessedCells, 1] = decimal_CurrentMostBigNumber[1]; // Какой байт

                        decimalArray_BytesEntryFreq[(short)decimal_CurrentMostBigNumber[1]] = decimal_CurrentMostBigNumber[0] = decimal_CurrentMostBigNumber[1] = short_CycleCount = -1;

                        short_ProcessedCells++;
                        if (short_ProcessedCells == 256) break;
                    }
                }

                #endregion

                #region Calculate Amount of Positive Bytes in decimal_NumbersSortedByOrder

                short_PositiveNumbersAmount = 0;
                for (short short_CycleCount = 0; short_CycleCount != 256; short_CycleCount++)
                {
                    if (decimal_BytesSortedByOrder[short_CycleCount, 0] == 0) break;

                    short_PositiveNumbersAmount++;
                }

                #endregion

                for (short short_CycleCount = 0; short_CycleCount != 256; short_CycleCount++)
                {
                    for (short short_SubCycleCount = 0; short_SubCycleCount != short_PositiveNumbersAmount; short_SubCycleCount++)
                    {
                        if (short_CycleCount == decimal_BytesSortedByOrder[short_SubCycleCount, 1])
                        {
                            short_BytePositionInBytesArraySortedByOrder[short_CycleCount] = short_SubCycleCount;
                            break;
                        }
                        if (short_SubCycleCount == short_PositiveNumbersAmount - 1)
                            short_BytePositionInBytesArraySortedByOrder[short_CycleCount] = -1;
                    }
                }

                #region Select Most Effective System of Groups Coding

                byte_MostEffectiveSystemOfGroupsCoding = 0;

                short_MultiplicationFactor = 0;

                decimal_BitsNeededForFirstSystemOfGroupsCoding = 0;
                decimal_BitsNeededForSecondSystemOfGroupsCoding = 0;

                GenerateClassicMapOfPrefixCodes();
                for (int int_CycleCount = 0; int_CycleCount != short_PositiveNumbersAmount; int_CycleCount++)
                {
                    short_MultiplicationFactor = (short)((BitArray)this.arrayList_MapOfPrefixCodes[int_CycleCount]).Length;

                    decimal_BitsNeededForFirstSystemOfGroupsCoding += short_MultiplicationFactor * decimal_BytesSortedByOrder[int_CycleCount, 0];
                }

                GenerateAlternateMapOfPrefixCodes();
                for (int int_CycleCount = 0; int_CycleCount != short_PositiveNumbersAmount; int_CycleCount++)
                {
                    short_MultiplicationFactor = (short)((BitArray)this.arrayList_MapOfPrefixCodes[int_CycleCount]).Length;

                    decimal_BitsNeededForSecondSystemOfGroupsCoding += short_MultiplicationFactor * decimal_BytesSortedByOrder[int_CycleCount, 0];
                }

                if (decimal_BitsNeededForFirstSystemOfGroupsCoding == decimal_BitsNeededForSecondSystemOfGroupsCoding)
                {
                    GenerateAlternateMapOfPrefixCodes();
                    byte_MostEffectiveSystemOfGroupsCoding = 0;
                    return (int)(decimal_BitsNeededForFirstSystemOfGroupsCoding / 8) + 352;
                }

                if (decimal_BitsNeededForFirstSystemOfGroupsCoding < decimal_BitsNeededForSecondSystemOfGroupsCoding)
                {
                    GenerateClassicMapOfPrefixCodes();
                    byte_MostEffectiveSystemOfGroupsCoding = 1;
                    return (int)(decimal_BitsNeededForFirstSystemOfGroupsCoding / 8) + 352;
                }

                if (decimal_BitsNeededForFirstSystemOfGroupsCoding > decimal_BitsNeededForSecondSystemOfGroupsCoding)
                {
                    GenerateAlternateMapOfPrefixCodes();
                    byte_MostEffectiveSystemOfGroupsCoding = 2;
                    return (int)(decimal_BitsNeededForSecondSystemOfGroupsCoding / 8) + 352;
                }

                return 0;

                #endregion
            }


            internal byte[] CompressUsingNonAdaptivePrefixCodesMethod(byte[] byteArray_BytesToCompress)
            {
                short short_IndexOfByteInSortedArray = 0;

                int int_CurrentBitsPosition = 0, int_CycleCount = 0;

                byte[] byteArray_CompressedBlock = null, byteArray_CompressedData = null;

                byte byte_CycleCount, byte_FirstByte;

                BitArray bitArray_CurrentPrefixCodesCode, bitArray_CompressedData = new BitArray(10000);

                /* *
                 * 0 - Uncompressed
                 * 1 - Non Adaptive
                 * 2 - Adaptive
                 * 3 - 2 bytes code system
                 * */

                MemoryStream memoryStream_CompressedData = new MemoryStream();

                memoryStream_CompressedData.Position = 1;

                if (short_PositiveNumbersAmount == 2 && byteArray_BytesToCompress.Length > 20)
                {
                    #region Compress using coding for two bytes

                    memoryStream_CompressedData.WriteByte(3);

                    memoryStream_CompressedData.WriteByte((byte)decimal_BytesSortedByOrder[0, 1]);
                    memoryStream_CompressedData.WriteByte((byte)decimal_BytesSortedByOrder[1, 1]);

                    byte_FirstByte = (byte)decimal_BytesSortedByOrder[0, 1];

                    for (int_CycleCount = 0; int_CycleCount != byteArray_BytesToCompress.Length; int_CycleCount++, int_CurrentBitsPosition++)
                    {
                        if (int_CurrentBitsPosition % 8 == 0)
                        {
                            bitArray_CompressedData.Length = int_CurrentBitsPosition;

                            byteArray_CompressedBlock = new byte[int_CurrentBitsPosition / 8];

                            bitArray_CompressedData.CopyTo(byteArray_CompressedBlock, 0);

                            memoryStream_CompressedData.Write(byteArray_CompressedBlock, 0, byteArray_CompressedBlock.Length);

                            bitArray_CompressedData = new BitArray(10000);

                            int_CurrentBitsPosition = 0;
                        }

                        if (bitArray_CompressedData.Length < int_CurrentBitsPosition + 16)
                            bitArray_CompressedData.Length += 10000;

                        if (byteArray_BytesToCompress[int_CycleCount] == byte_FirstByte)
                        {
                            bitArray_CompressedData.Set(int_CurrentBitsPosition, true);
                            continue;
                        }

                        bitArray_CompressedData.Set(int_CurrentBitsPosition, false);
                    }

                    bitArray_CompressedData.Length = int_CurrentBitsPosition;

                    new CommonEnvironment().AddUnusedsBitsCountInfo(bitArray_CompressedData, memoryStream_CompressedData);

                    byteArray_CompressedData = new byte[memoryStream_CompressedData.ToArray().Length];

                    memoryStream_CompressedData.Position = 0;

                    memoryStream_CompressedData.Read(byteArray_CompressedData, 0, byteArray_CompressedData.Length);

                    return byteArray_CompressedData;

                    #endregion
                }

                memoryStream_CompressedData.WriteByte(1);

                #region Write Number of Group Coding System

                memoryStream_CompressedData.WriteByte(byte_MostEffectiveSystemOfGroupsCoding);

                #endregion

                #region Write count of bytes

                memoryStream_CompressedData.WriteByte((byte)(short_PositiveNumbersAmount - 1));// 0 is imposible, 0 is 1 ... 255 is 256

                #endregion

                #region Write all bytes sorted by freq

                for (int_CycleCount = 0; int_CycleCount != short_PositiveNumbersAmount; int_CycleCount++)
                {
                    memoryStream_CompressedData.WriteByte((byte)decimal_BytesSortedByOrder[int_CycleCount, 1]);// 0 is imposible, 0 is 1 ... 255 is 256
                }

                #endregion

                #region Coding

                for (int_CycleCount = 0; int_CycleCount != byteArray_BytesToCompress.Length; int_CycleCount++)
                {
                    short_IndexOfByteInSortedArray = short_BytePositionInBytesArraySortedByOrder[byteArray_BytesToCompress[int_CycleCount]];

                    bitArray_CurrentPrefixCodesCode = (BitArray)(arrayList_MapOfPrefixCodes[short_IndexOfByteInSortedArray]);

                    if (bitArray_CompressedData.Length <= int_CurrentBitsPosition + bitArray_CurrentPrefixCodesCode.Length)
                        bitArray_CompressedData.Length += 100000;

                    for (byte_CycleCount = 0; byte_CycleCount != bitArray_CurrentPrefixCodesCode.Count; byte_CycleCount++)
                    {
                        bitArray_CompressedData[int_CurrentBitsPosition] = bitArray_CurrentPrefixCodesCode[byte_CycleCount];
                        int_CurrentBitsPosition++;
                    }

                    if (int_CurrentBitsPosition % 8 == 0)
                    {
                        bitArray_CompressedData.Length = int_CurrentBitsPosition;

                        byteArray_CompressedBlock = new byte[int_CurrentBitsPosition / 8];

                        bitArray_CompressedData.CopyTo(byteArray_CompressedBlock, 0);

                        memoryStream_CompressedData.Write(byteArray_CompressedBlock, 0, byteArray_CompressedBlock.Length);

                        bitArray_CompressedData = new BitArray(10000);

                        int_CurrentBitsPosition = 0;
                    }
                }

                #endregion

                bitArray_CompressedData.Length = int_CurrentBitsPosition;

                new CommonEnvironment().AddUnusedsBitsCountInfo(bitArray_CompressedData, memoryStream_CompressedData);

                byteArray_CompressedData = new byte[memoryStream_CompressedData.ToArray().Length];

                memoryStream_CompressedData.Position = 0;

                memoryStream_CompressedData.Read(byteArray_CompressedData, 0, byteArray_CompressedData.Length);

                return byteArray_CompressedData;
            }

            internal byte[] CompressUsingAdaptivePrefixCodesMethod(byte[] byteArray_BytesToCompress)
            {
                byte[] byteArray_CompressedData = null;

                BitArray bitArray_CompressedData = new BitArray(100000),
                         bitArray_CurrentPrefixCodesCode;

                int int_CurrentBitsPosition = 0;

                byte byte_CurrentByte = 0;

                short short_IndexOfByte = 0;

                byte[] byteArray_CompressedBlock = null;

                MemoryStream memoryStream_CompressedData = new MemoryStream();

                /* *
                 * 0 - Uncompressed
                 * 1 - Non Adaptive
                 * 2 - Adaptive
                 * 3 - 2 bytes code system
                 * */

                memoryStream_CompressedData.Position = 1;

                memoryStream_CompressedData.WriteByte(2); // 2 - Adaptive

                #region Write Number of Group Coding System

                memoryStream_CompressedData.WriteByte(byte_MostEffectiveSystemOfGroupsCoding);

                #endregion

                short_PositiveNumbersAmount = 256;

                ArrayList arrayList_IndexOfBytesCodes = new ArrayList(short_PositiveNumbersAmount);

                if (byte_MostEffectiveSystemOfGroupsCoding == 2 || byte_MostEffectiveSystemOfGroupsCoding == 0)
                    GenerateAlternateMapOfPrefixCodes();
                else GenerateClassicMapOfPrefixCodes();

                for (short short_CycleCount = 0; short_CycleCount != 256; short_CycleCount++)
                {
                    arrayList_IndexOfBytesCodes.Add((byte)short_CycleCount);
                }

                #region Coding

                int_CurrentBitsPosition = 0;

                for (int int_CycleCount = 0; int_CycleCount != byteArray_BytesToCompress.Length; int_CycleCount++)
                {
                    byte_CurrentByte = (byte)byteArray_BytesToCompress[int_CycleCount];

                    for (short_IndexOfByte = 0; short_IndexOfByte != short_PositiveNumbersAmount; short_IndexOfByte++)
                    {
                        if (byte_CurrentByte == (byte)arrayList_IndexOfBytesCodes[short_IndexOfByte]) break;

                        if (short_IndexOfByte == short_PositiveNumbersAmount - 1)
                        {
                            short_IndexOfByte = -1;
                            break;
                        }
                    }

                    if (short_IndexOfByte == -1) continue;

                    bitArray_CurrentPrefixCodesCode = (BitArray)arrayList_MapOfPrefixCodes[short_IndexOfByte];

                    if (bitArray_CompressedData.Length <= int_CurrentBitsPosition + bitArray_CurrentPrefixCodesCode.Length)
                        bitArray_CompressedData.Length += 100000;

                    for (int int_SubCycleCount = 0; int_SubCycleCount != bitArray_CurrentPrefixCodesCode.Length; int_SubCycleCount++)
                    {
                        bitArray_CompressedData[int_CurrentBitsPosition] = bitArray_CurrentPrefixCodesCode[int_SubCycleCount];
                        int_CurrentBitsPosition++;
                    }

                    if (short_IndexOfByte != 0)
                    {
                        arrayList_IndexOfBytesCodes.RemoveAt(short_IndexOfByte);

                        arrayList_IndexOfBytesCodes.Insert((int)short_IndexOfByte / 2, byte_CurrentByte);
                    }


                    if (int_CurrentBitsPosition % 8 == 0)
                    {
                        bitArray_CompressedData.Length = int_CurrentBitsPosition;

                        byteArray_CompressedBlock = new byte[int_CurrentBitsPosition / 8];

                        bitArray_CompressedData.CopyTo(byteArray_CompressedBlock, 0);

                        memoryStream_CompressedData.Write(byteArray_CompressedBlock, 0, byteArray_CompressedBlock.Length);

                        bitArray_CompressedData = new BitArray(10000);

                        int_CurrentBitsPosition = 0;
                    }
                }

                #endregion

                bitArray_CompressedData.Length = int_CurrentBitsPosition;

                new CommonEnvironment().AddUnusedsBitsCountInfo(bitArray_CompressedData, memoryStream_CompressedData);

                byteArray_CompressedData = new byte[memoryStream_CompressedData.ToArray().Length];

                memoryStream_CompressedData.Position = 0;

                memoryStream_CompressedData.Read(byteArray_CompressedData, 0, byteArray_CompressedData.Length);

                return byteArray_CompressedData;
            }


            internal byte[] DecompressUsingNonAdaptivePrefixCodesMethod(byte[] byteArray_BytesToDecompress)
            {
                BitArray bitArray_CompressedData = null;

                byte[] byteArray_TwoBytes = new byte[2],
                        byteArray_DecompressedData = null, byteArray_CompressedData = null;

                MemoryStream memoryStream_CompressedData = new MemoryStream(byteArray_BytesToDecompress),
                             memoryStream_DecompressedData = new MemoryStream();

                int int_CurrentBitsPosition = 0;

                byte byte_UnusedBitsCount = (byte)memoryStream_CompressedData.ReadByte(),
                     byte_AlgorithmType = (byte)memoryStream_CompressedData.ReadByte();


                /* *
                 * 0 - Uncompressed
                 * 1 - Non Adaptive
                 * 2 - Adaptive
                 * 3 - 2 bytes code system
                 * */


                #region Use Decode method for two bytes

                if (byte_AlgorithmType == 3)
                {
                    byteArray_TwoBytes[0] = (byte)memoryStream_CompressedData.ReadByte(); // First byte
                    byteArray_TwoBytes[1] = (byte)memoryStream_CompressedData.ReadByte();

                    #region Create BitArray from compressed bytes

                    byteArray_CompressedData = new byte[(memoryStream_CompressedData.Length - memoryStream_CompressedData.Position)];

                    memoryStream_CompressedData.Read(byteArray_CompressedData, 0, byteArray_CompressedData.Length);

                    bitArray_CompressedData = new BitArray(byteArray_CompressedData);

                    #endregion

                    for (int int_CycleCount = 0; int_CycleCount != bitArray_CompressedData.Length - byte_UnusedBitsCount; int_CycleCount++)
                    {
                        if (bitArray_CompressedData[int_CycleCount] == true) memoryStream_DecompressedData.WriteByte(byteArray_TwoBytes[0]);
                        else memoryStream_DecompressedData.WriteByte(byteArray_TwoBytes[1]);
                    }

                    byteArray_DecompressedData = memoryStream_DecompressedData.ToArray();

                    memoryStream_DecompressedData.Close();

                    return byteArray_DecompressedData;
                }

                #endregion


                byte byte_GroupCodingSystemNumber = (byte)memoryStream_CompressedData.ReadByte();

                short_PositiveNumbersAmount = (byte)memoryStream_CompressedData.ReadByte();

                short_PositiveNumbersAmount++;

                byte[] byteArray_AllStoredBytesSortedByFreq = new byte[short_PositiveNumbersAmount];

                memoryStream_CompressedData.Read(byteArray_AllStoredBytesSortedByFreq, 0, byteArray_AllStoredBytesSortedByFreq.Length);



                if (byte_GroupCodingSystemNumber == 2 || byte_GroupCodingSystemNumber == 0) GenerateAlternateMapOfPrefixCodes();
                else GenerateClassicMapOfPrefixCodes();

                CalculateLengthsOfGroupsAndIndexers();




                #region Create BitArray from compressed bytes

                byteArray_CompressedData = new byte[(memoryStream_CompressedData.Length - memoryStream_CompressedData.Position)];

                memoryStream_CompressedData.Read(byteArray_CompressedData, 0, byteArray_CompressedData.Length);

                bitArray_CompressedData = new BitArray(byteArray_CompressedData);

                #endregion


                int int_IndexOfByte = 0, int_CurrentBitPos = 0,
                    int_CountOfGroups = arrayList_GroupsPosition.Count - 1;

                for (; int_CurrentBitsPosition < bitArray_CompressedData.Count - byte_UnusedBitsCount; )
                {
                    #region Processing when Current Bit is 0 (false)

                    if (bitArray_CompressedData[int_CurrentBitsPosition] == false)
                    {
                        memoryStream_DecompressedData.WriteByte((byte)byteArray_AllStoredBytesSortedByFreq[0]);

                        int_CurrentBitsPosition++;

                        continue;
                    }

                    #endregion

                    int_IndexOfByte = 0;
                    byte_NumberOfGroup = 0;

                    #region Calculate Group Length

                    for (; bitArray_CompressedData[int_CurrentBitsPosition] != false; byte_NumberOfGroup++, int_CurrentBitsPosition++)
                    {
                        if (byte_NumberOfGroup == (int)arrayList_LengthOfGroups[arrayList_LengthOfGroups.Count - 1])
                        {
                            int_CurrentBitsPosition++;
                            byte_NumberOfGroup++;
                            break;
                        }
                    }

                    if (byte_NumberOfGroup == arrayList_GroupsPosition.Count) continue;

                    #endregion

                    int_IndexOfByte = (int)arrayList_GroupsPosition[byte_NumberOfGroup];

                    #region Calculate Position of PrefixCodes Code Index

                    if ((int)arrayList_LengthOfIndex[byte_NumberOfGroup] > 0)
                    {
                        int_CurrentBitsPosition++;

                        bitArray_ReadedData.Length = (int)arrayList_LengthOfIndex[byte_NumberOfGroup];

                        for (int int_CycleCount = 0; int_CycleCount != bitArray_ReadedData.Length; int_CycleCount++)
                        {
                            bitArray_ReadedData[int_CycleCount] = bitArray_CompressedData[int_CurrentBitsPosition];
                            int_CurrentBitsPosition++;
                        }

                        int_CurrentBitPos = bitArray_ReadedData.Length - 1;

                        //перевод из двоичного числа в десятичное.
                        for (int int_CycleCount = 0; int_CycleCount != bitArray_ReadedData.Length; int_CycleCount++, int_CurrentBitPos--)
                        {
                            if (bitArray_ReadedData[int_CycleCount] == true)
                                int_IndexOfByte += (int)Math.Pow(2, int_CurrentBitPos);
                        }
                    }

                    else if ((int)arrayList_LengthOfIndex[byte_NumberOfGroup] == 0) int_CurrentBitsPosition++;

                    #endregion

                    memoryStream_DecompressedData.WriteByte(byteArray_AllStoredBytesSortedByFreq[(int)int_IndexOfByte]);

                }

                byteArray_DecompressedData = memoryStream_DecompressedData.ToArray();

                memoryStream_DecompressedData.Close();

                return byteArray_DecompressedData;
            }

            internal byte[] DecompressUsingAdaptivePrefixCodesMethod(byte[] byteArray_BytesToDecompress)
            {
                BitArray bitArray_CompressedData = null;

                byte[] byteArray_CompressedData = null;

                MemoryStream memoryStream_DecompressedData = new MemoryStream(),
                             memoryStream_CompressedData = new MemoryStream(byteArray_BytesToDecompress);


                byte byte_UnusedBitsCount = (byte)memoryStream_CompressedData.ReadByte(),
                     byte_AlgorithmType = (byte)memoryStream_CompressedData.ReadByte();

                int int_CurrentBitsPosition = 0;


                /* *
                 * 0 - Uncompressed
                 * 1 - Non Adaptive
                 * 2 - Adaptive
                 * 3 - 2 bytes code system
                 * */

                // Read GroupCodingSystemNumber
                byte byte_GroupCodingSystemNumber = (byte)memoryStream_CompressedData.ReadByte();

                short_PositiveNumbersAmount = 256;

                if (byte_GroupCodingSystemNumber == 2 || byte_GroupCodingSystemNumber == 0)
                    GenerateAlternateMapOfPrefixCodes();
                else GenerateClassicMapOfPrefixCodes();

                CalculateLengthsOfGroupsAndIndexers();

                ArrayList arrayList_IndexOfBytesCodes = new ArrayList(short_PositiveNumbersAmount);

                for (short short_CycleCount = 0; short_CycleCount != 256; short_CycleCount++)
                {
                    arrayList_IndexOfBytesCodes.Add((byte)short_CycleCount);
                }

                int int_IndexOfByte = 0, int_CurrentBitPos = 0,
                    int_CountOfGroups = arrayList_GroupsPosition.Count - 1;

                byte byte_CurrentByte = 0;

                #region Create BitArray from compressed bytes

                byteArray_CompressedData = new byte[(memoryStream_CompressedData.Length - memoryStream_CompressedData.Position)];

                memoryStream_CompressedData.Read(byteArray_CompressedData, 0, byteArray_CompressedData.Length);

                bitArray_CompressedData = new BitArray(byteArray_CompressedData);

                #endregion

                #region Decoding

                for (; int_CurrentBitsPosition < bitArray_CompressedData.Count - byte_UnusedBitsCount; )
                {
                    int_IndexOfByte = 0;
                    byte_NumberOfGroup = 0;

                    #region Stable Code

                    if (bitArray_CompressedData[int_CurrentBitsPosition] == false)
                    {
                        memoryStream_DecompressedData.WriteByte((byte)arrayList_IndexOfBytesCodes[int_IndexOfByte]);

                        int_CurrentBitsPosition++;

                        continue;
                    }

                    #endregion

                    for (; bitArray_CompressedData[int_CurrentBitsPosition] != false; byte_NumberOfGroup++, int_CurrentBitsPosition++)
                    {
                        if (byte_NumberOfGroup == (int)arrayList_LengthOfGroups[arrayList_LengthOfGroups.Count - 1])
                        {
                            int_CurrentBitsPosition++;
                            byte_NumberOfGroup++;
                            break;
                        }
                    }

                    int_IndexOfByte = (int)arrayList_GroupsPosition[byte_NumberOfGroup];

                    if ((int)arrayList_LengthOfIndex[byte_NumberOfGroup] > 0)
                    {
                        int_CurrentBitsPosition++;

                        bitArray_ReadedData.Length = (int)arrayList_LengthOfIndex[byte_NumberOfGroup];

                        for (int int_CycleCount = 0; int_CycleCount != bitArray_ReadedData.Length; int_CycleCount++)
                        {
                            bitArray_ReadedData[int_CycleCount] = bitArray_CompressedData[int_CurrentBitsPosition];
                            int_CurrentBitsPosition++;
                        }

                        int_CurrentBitPos = bitArray_ReadedData.Length - 1;

                        for (int int_CycleCount = 0; int_CycleCount != bitArray_ReadedData.Length; int_CycleCount++, int_CurrentBitPos--)
                        {
                            if (bitArray_ReadedData[int_CycleCount] == true)
                                int_IndexOfByte += (int)Math.Pow(2, int_CurrentBitPos);
                        }
                    }
                    else if ((int)arrayList_LengthOfIndex[byte_NumberOfGroup] == 0) int_CurrentBitsPosition++;

                    byte_CurrentByte = (byte)arrayList_IndexOfBytesCodes[int_IndexOfByte];

                    memoryStream_DecompressedData.WriteByte(byte_CurrentByte);

                    arrayList_IndexOfBytesCodes.RemoveAt(int_IndexOfByte);

                    arrayList_IndexOfBytesCodes.Insert((int)int_IndexOfByte / 2, byte_CurrentByte);
                }

                #endregion

                byte[] byteArray_DecompressedData = memoryStream_DecompressedData.ToArray();

                memoryStream_DecompressedData.Close();

                return byteArray_DecompressedData;
            }


            internal void GenerateClassicMapOfPrefixCodes()
            {

                #region Members Declaration

                arrayList_MapOfPrefixCodes = new List<BitArray>();

                BitArray bitArray_PrefixCodesBits, bitArray_NumberInGroup;

                short short_RequiredBitsAmount = 0, short_GroupNumber = 0,
                      short_NumberLengthInGroup = 0, short_GroupsAmount = 0;

                #endregion

                if (short_PositiveNumbersAmount > 127 && short_PositiveNumbersAmount < 258) short_GroupsAmount = 8;
                if (short_PositiveNumbersAmount > 63 && short_PositiveNumbersAmount < 129) short_GroupsAmount = 7;
                if (short_PositiveNumbersAmount > 32 && short_PositiveNumbersAmount < 64) short_GroupsAmount = 6;
                if (short_PositiveNumbersAmount > 16 && short_PositiveNumbersAmount < 33) short_GroupsAmount = 5;
                if (short_PositiveNumbersAmount > 8 && short_PositiveNumbersAmount < 17) short_GroupsAmount = 4;
                if (short_PositiveNumbersAmount > 4 && short_PositiveNumbersAmount < 9) short_GroupsAmount = 3;
                if (short_PositiveNumbersAmount > 1 && short_PositiveNumbersAmount < 5) short_GroupsAmount = 2;
                if (short_PositiveNumbersAmount == 1) short_GroupsAmount = 1;
                if (short_PositiveNumbersAmount == 0) short_GroupsAmount = 0;

                // FOR for each group.
                for (short short_CycleCount = 0; short_CycleCount < short_PositiveNumbersAmount; short_GroupNumber++)
                {
                    short_NumberLengthInGroup = (short)(short_GroupNumber - 1);

                    short_RequiredBitsAmount = (short)Math.Pow(2, short_NumberLengthInGroup);
                    if (short_RequiredBitsAmount == 0)
                    {
                        short_NumberLengthInGroup = 0;
                        short_RequiredBitsAmount = 1;
                    }

                    // FOR for each element.
                    for (short short_SubCycleCount = 0; short_SubCycleCount != short_RequiredBitsAmount; short_SubCycleCount++)
                    {
                        if (short_CycleCount++ == short_PositiveNumbersAmount) break;

                        if (short_GroupNumber > short_GroupsAmount - 1)
                        {
                            short_NumberLengthInGroup = (short)(((short_GroupsAmount * 2) - 2) - short_GroupNumber);

                            if (short_NumberLengthInGroup <= 0) short_NumberLengthInGroup = 0;

                            short_RequiredBitsAmount = (short)Math.Pow(2, short_NumberLengthInGroup);
                        }

                        if (short_GroupNumber > (short_GroupsAmount * 2) - 2)
                        {
                            arrayList_MapOfPrefixCodes.Add(new BitArray(short_GroupNumber, true));
                            break;
                        }

                        bitArray_NumberInGroup = new BitArray(BitConverter.GetBytes(short_SubCycleCount));
                        bitArray_NumberInGroup.Length = short_NumberLengthInGroup;

                        bitArray_PrefixCodesBits = new BitArray(short_GroupNumber + short_NumberLengthInGroup + 1, true);
                        bitArray_PrefixCodesBits[short_GroupNumber] = false;


                        #region Устанавливаем все биты Номера В Группе в bitArray_PrefixCodesBits

                        for (short short_ThirdCycleCount = 0,
                                short_CurrentBitPos = (short)(bitArray_PrefixCodesBits.Length - 1);

                            short_CurrentBitPos != short_GroupNumber;

                            short_CurrentBitPos--,
                            short_ThirdCycleCount++)
                        {
                            bitArray_PrefixCodesBits[short_CurrentBitPos] = bitArray_NumberInGroup[short_ThirdCycleCount];
                        }

                        #endregion

                        arrayList_MapOfPrefixCodes.Add(bitArray_PrefixCodesBits);
                    }
                }


            }

            internal void GenerateAlternateMapOfPrefixCodes()
            {

                #region Members Declaration

                arrayList_MapOfPrefixCodes = new List<BitArray>();

                BitArray bitArray_PrefixCodesBits, bitArray_NumberInGroup;

                short short_RequiredBitsAmount = 0, short_GroupNumber = 0,
                    short_NumberLengthInGroup = 0, short_GroupsAmount = 0;

                #endregion

                if (short_PositiveNumbersAmount > 126) short_GroupsAmount = 7;
                if (short_PositiveNumbersAmount > 62 && short_PositiveNumbersAmount < 127) short_GroupsAmount = 6;
                if (short_PositiveNumbersAmount > 30 && short_PositiveNumbersAmount < 63) short_GroupsAmount = 5;
                if (short_PositiveNumbersAmount > 14 && short_PositiveNumbersAmount < 31) short_GroupsAmount = 4;
                if (short_PositiveNumbersAmount > 6 && short_PositiveNumbersAmount < 15) short_GroupsAmount = 3;
                if (short_PositiveNumbersAmount > 2 && short_PositiveNumbersAmount < 7) short_GroupsAmount = 2;
                if (short_PositiveNumbersAmount > 0 && short_PositiveNumbersAmount < 3) short_GroupsAmount = 1;
                if (short_PositiveNumbersAmount == 0) short_GroupsAmount = 0;


                // FOR for each element.
                for (short short_CycleCount = 0; short_CycleCount < short_PositiveNumbersAmount; short_GroupNumber++)
                {
                    short_RequiredBitsAmount = (short)Math.Pow(2, short_GroupNumber);

                    short_NumberLengthInGroup = short_GroupNumber;

                    for (short short_SubCycleCount = 0; short_SubCycleCount != short_RequiredBitsAmount; short_SubCycleCount++)
                    {
                        if (short_CycleCount++ == short_PositiveNumbersAmount) break;

                        if (short_GroupNumber > (short_GroupsAmount - 1))
                        {
                            short_NumberLengthInGroup = (short)(((short_GroupsAmount * 2) - 1) - short_GroupNumber);

                            if (short_NumberLengthInGroup <= 0) short_NumberLengthInGroup = 0;

                            short_RequiredBitsAmount = (short)Math.Pow(2, short_NumberLengthInGroup);
                        }

                        if (short_GroupNumber > ((short_GroupsAmount * 2)))
                        {
                            arrayList_MapOfPrefixCodes.Add(new BitArray(short_GroupNumber, true));
                            break;
                        }


                        bitArray_NumberInGroup = new BitArray(BitConverter.GetBytes((byte)short_SubCycleCount));


                        if (short_SubCycleCount < 2) bitArray_NumberInGroup.Length = 1;
                        if (short_SubCycleCount > 1 && short_SubCycleCount < 4) bitArray_NumberInGroup.Length = 2;
                        if (short_SubCycleCount > 3 && short_SubCycleCount < 8) bitArray_NumberInGroup.Length = 3;
                        if (short_SubCycleCount > 7 && short_SubCycleCount < 16) bitArray_NumberInGroup.Length = 4;
                        if (short_SubCycleCount > 15 && short_SubCycleCount < 32) bitArray_NumberInGroup.Length = 5;
                        if (short_SubCycleCount > 31 && short_SubCycleCount < 64) bitArray_NumberInGroup.Length = 6;
                        if (short_SubCycleCount > 63 && short_SubCycleCount < 128) bitArray_NumberInGroup.Length = 7;
                        if (short_SubCycleCount > 127 && short_SubCycleCount < 255) bitArray_NumberInGroup.Length = 8;

                        if (short_CycleCount == 0) bitArray_NumberInGroup.Length = 0;

                        bitArray_NumberInGroup.Length = short_NumberLengthInGroup;

                        bitArray_PrefixCodesBits = new BitArray(short_GroupNumber + 1 + short_NumberLengthInGroup, true);
                        bitArray_PrefixCodesBits[short_GroupNumber] = false;

                        #region Устанавливаем все биты Номера В Группе в bitArray_PrefixCodesBits

                        for (short short_ThirdCycleCount = 0, short_CurrentBitPos = (short)(bitArray_PrefixCodesBits.Length - 1)
                                ; short_CurrentBitPos != short_GroupNumber; short_CurrentBitPos--, short_ThirdCycleCount++)
                        {
                            bitArray_PrefixCodesBits[short_CurrentBitPos] = bitArray_NumberInGroup[short_ThirdCycleCount];
                        }

                        #endregion

                        arrayList_MapOfPrefixCodes.Add(bitArray_PrefixCodesBits);
                    }
                }
            }

        }
    }
}