using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace JurikSoft
{
    namespace Compression
    {

        /// <summary>
        /// 
        /// Provides functionality to compress data using PrefixCodes, LZSS and RLE algorithms.
        /// 
        /// </summary>
        public interface ICompression
        {
            /// <summary>
            /// 
            /// Compress the data with ability to add MD5 hash check sum.
            /// 
            /// </summary>
            /// 
            /// <returns> 
            /// An Compressed array of bytes with length > 0. 
            /// </returns>
            /// 
            /// <param name="DataToCompress">
            /// The input data to compress using RLE algorithm.
            /// </param> 	 
            /// 	
            /// <param name="AddCheckSum">
            /// Indicating whether add to compressed data MD5 Hash check sum.
            /// </param>
            /// 
            /// <example> This sample shows how to compress byte array.
            /// <code>
            /// //Declare ICompression interfase and initialize it by a new instance of the 
            /// //RLE class with a compression parameter:
            /// //PrefixCodesCompression enum value that indicate use PrefixCode 
            /// //to compress single uncompressed bytes or store bytes uncompressed
            /// JurikSoft.Compression.ICompression compressionObj = 
            /// new JurikSoft.Compression.RLE(PrefixCodesCompression.NonAdaptive);
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
            byte[] Compress(byte[] DataToCompress, bool AddCheckSum);
        }

        /// <summary>
        /// 
        /// Provides the fields that represent settings for Prefix Codes compression algorithm.
        /// 
        /// </summary>		
        public enum PrefixCodesCompression
        {
            /// <summary>
            /// 
            /// Indecate that PrefixCodes compression algorithm is not used.
            /// 
            /// </summary>	
            /// 
            DoNotUse,
            /// <summary>
            /// 
            /// To use PrefixCodes compression algorithm with Adaptive model.
            /// 
            /// </summary>	
            /// 
            Adaptive,
            /// <summary>
            /// 
            /// To use PrefixCodes compression algorithm with Non-Adaptive model.
            /// 
            /// </summary>	
            ///	
            NonAdaptive
        }

        public class CommonEnvironment
        {
            internal static string string_SerialNumber, string_RegistrationName;

            #region Common Properties

            ///  <summary>
            /// 
            ///  Serial Number of your product copy sended to your Registration Name
            /// 
            ///  </summary>
            /// 		
            ///  <remarks>
            /// 
            ///  If you are not registered you will see the following message every time when you call 
            ///  CommonEnvironment.Decompress(byte [] DataToDecompress, bool VerifyCheckSum) method: 
            ///  
            ///  <para>			
            ///  "You are using the FREE COPY of JurikSoft Compression Library.			
            ///  Please register a copy of JurikSoft Compression Library at 
            ///  http://www.juriksoft.net to disable this appear message."
            ///  </para>
            /// 
            ///  You can purchase a copy of this software product at http://www.juriksoft.net.
            ///   
            ///  <para>	
            ///  One copy (serial number) entitles to use this 
            ///  software product to one software developers team.
            ///  </para>
            ///  </remarks>
            ///  
            ///  <example> This sample shows how to use Registration Information.
            ///  <code>
            /// 
            ///  JurikSoft.Compression.CommonEnvironment.RegistrationName = "Test";
            ///	 JurikSoft.Compression.CommonEnvironment.SerialNumber = "1000000000";
            /// 
            ///  </code>
            ///  </example>

            public static string SerialNumber
            {
                set
                {
                    string_SerialNumber = value;
                }

                get
                {
                    return string_SerialNumber;
                }
            }


            ///  <summary>
            /// 
            ///  Registration Name that you use when you buy JurikSoft Compression Library
            /// 
            ///  </summary>
            /// 		
            ///  <remarks>
            /// 
            ///  If you are not registered you will see the following message every time when you call 
            ///  CommonEnvironment.Decompress(byte [] DataToDecompress, bool VerifyCheckSum) method: 
            ///  
            ///  <para>			
            ///  "You are using the FREE COPY of JurikSoft Compression Library.			
            ///  Please register a copy of JurikSoft Compression Library at 
            ///  http://www.juriksoft.net to disable this appear message."
            ///  </para>
            /// 
            ///  You can purchase a copy of this software product at http://www.juriksoft.net.
            ///   
            ///  <para>	
            ///  One copy (serial number) entitles to use this 
            ///  software product to one software developers team.
            ///  </para>
            ///  </remarks>
            ///  
            ///  <example> This sample shows how to use Registration Information.
            ///  <code>
            /// 
            ///  JurikSoft.Compression.CommonEnvironment.RegistrationName = "Test";
            ///	 JurikSoft.Compression.CommonEnvironment.SerialNumber = "1000000000";
            /// 
            ///  </code>
            ///  </example>			
            public static string RegistrationName
            {

                set
                {
                    string_RegistrationName = value;
                }

                get
                {
                    return string_RegistrationName;
                }
            }


            #endregion

            internal static void CheckSN()
            {
                return;

                if (SerialNumber == null || SerialNumber.Length < 9)
                {
                    MessageBox.Show("The FREE COPY of JurikSoft Compression Library is used.\nPlease register a copy of JurikSoft Compression Library \nat http://www.juriksoft.net to disable this appear message.", "JurikSoft");
                    
                    return;
                }

                SHA256Managed SHA256Managed_Key = new SHA256Managed();

                byte[] byteArray_KeyHash = SHA256Managed_Key.ComputeHash(Encoding.Unicode.GetBytes(RegistrationName));

                string string_CurrentNubmer = null;

                for (int int_CycleCount = 0; byteArray_KeyHash.Length != int_CycleCount; int_CycleCount++)
                {
                    string_CurrentNubmer += (byteArray_KeyHash[int_CycleCount]).ToString();
                }

                if (SerialNumber == string_CurrentNubmer.Substring(0, 10))
                {
                    return;
                }
                else
                {
                    MessageBox.Show("The FREE COPY of JurikSoft Compression Library is used.\nPlease register a copy of JurikSoft Compression Library \nat http://www.juriksoft.net to disable this appear message.", "JurikSoft");
                }
            }

            #region PrefixCodes Coding Envirmoment

            internal class PrefixCodesSupportForLZSSLengths
            {
                /*
                internal ArrayList arrayList_MapOfPrefixCodes, arrayList_GroupsPositions,
                         arrayList_LengthsOfIndexes, arrayList_LengthsOfGroups;
                */

                internal List<BitArray> arrayList_MapOfPrefixCodes;

                internal List<int> arrayList_GroupsPositions, arrayList_LengthsOfIndexes, arrayList_LengthsOfGroups;
                

                BitArray bitArray_ReadedData = new BitArray(16);

                byte byte_NumberOfGroup = 0;

                int[] intArray_DecodedPrefixCodesCode = new int[2];

                internal int[] DecodedPrefixCodesCode
                {
                    get
                    {
                        return intArray_DecodedPrefixCodesCode;
                    }
                }


                #region intArray_DecodedPrefixCodesCode Overview
                /*	
				 * 	intArray_DecodedPrefixCodesCode[0] is decimal 
				 *	representation of PrefixCodesCode and 
				 *	intArray_DecodedPrefixCodesCode[1] is PrefixCodesCode
				 *	length in Bits				
				 */
                #endregion

                internal void ConvertPrefixCodesCodeToDecimal(ref BitArray bitArray_CompressedData, int int_CurrentBitPosition)
                {
                    #region Processing when Current Bit is 0 (false)

                    if (bitArray_CompressedData[int_CurrentBitPosition] == false)
                    {
                        intArray_DecodedPrefixCodesCode[0] = 0;
                        intArray_DecodedPrefixCodesCode[1] = int_CurrentBitPosition + 1;

                        return;
                    }

                    #endregion

                    int int_IndexOfByte = 0, int_CurrentBitPos = 0,
                        int_CountOfGroups = arrayList_GroupsPositions.Count - 1;

                    byte_NumberOfGroup = 0;

                    #region Calculate Group Length

                    for (; bitArray_CompressedData[int_CurrentBitPosition] != false; byte_NumberOfGroup++, int_CurrentBitPosition++)
                    {
                        if (byte_NumberOfGroup == (int)arrayList_LengthsOfGroups[arrayList_LengthsOfGroups.Count - 1])
                        {
                            int_CurrentBitPosition++;
                            byte_NumberOfGroup++;
                            break;
                        }
                    }

                    #endregion

                    int_IndexOfByte = (int)arrayList_GroupsPositions[byte_NumberOfGroup];

                    #region Calculate Position of PrefixCodes Code Index

                    if ((int)arrayList_LengthsOfIndexes[byte_NumberOfGroup] > 0)
                    {
                        int_CurrentBitPosition++;

                        bitArray_ReadedData.Length = (int)arrayList_LengthsOfIndexes[byte_NumberOfGroup];

                        for (int int_CycleCount = 0; int_CycleCount != bitArray_ReadedData.Length; int_CycleCount++)
                        {
                            bitArray_ReadedData[int_CycleCount] = bitArray_CompressedData[int_CurrentBitPosition];
                            int_CurrentBitPosition++;
                        }

                        int_CurrentBitPos = bitArray_ReadedData.Length - 1;

                        //перевод из двоичного числа в десятичное.
                        for (int int_CycleCount = 0; int_CycleCount != bitArray_ReadedData.Length; int_CycleCount++, int_CurrentBitPos--)
                        {
                            if (bitArray_ReadedData[int_CycleCount] == true)
                                int_IndexOfByte += (int)Math.Pow(2, int_CurrentBitPos);
                        }
                    }

                    else if ((int)arrayList_LengthsOfIndexes[byte_NumberOfGroup] == 0) int_CurrentBitPosition++;

                    #endregion

                    intArray_DecodedPrefixCodesCode[0] = int_IndexOfByte;
                    intArray_DecodedPrefixCodesCode[1] = int_CurrentBitPosition;
                }
                
                void CalculateLengthsOfGroupsAndIndexers()
                {
                    arrayList_GroupsPositions = new List<int>();
                    arrayList_LengthsOfIndexes = new List<int>();
                    arrayList_LengthsOfGroups = new List<int>();

                    int int_LastNumberOfGroup = -1, int_CurrentNumberOfGroup = 0,
                        int_CurrentLengthOfIndex = -1;

                    BitArray bitArray_LastObject;

                    // общий цикл для последовательной обработки всех кодов Стат. кодирования\Хаффмана(BitArray) в Листе(ArrayList)
                    for (int int_CycleCount = 0; int_CycleCount != arrayList_MapOfPrefixCodes.Count; int_CycleCount++)
                    {
                        bitArray_LastObject = (BitArray)arrayList_MapOfPrefixCodes[int_CycleCount];

                        // цикл для обработки текущего кода Стат. кодирования\Хаффмана(BitArray)
                        foreach (bool bool_CurrentBit in bitArray_LastObject)
                        {
                            // последний код - состоящий ТОЛЬКО из единиц (true) потому длина индекса выставляется в -1
                            if (int_CurrentNumberOfGroup == bitArray_LastObject.Length - 1 && bitArray_LastObject[bitArray_LastObject.Length - 1] != false)
                            {
                                arrayList_LengthsOfIndexes.Add(-1);
                                arrayList_LengthsOfGroups.Add(int_CurrentNumberOfGroup++);
                                arrayList_GroupsPositions.Add(int_CycleCount);
                            }

                            // встретили бит-разделитель 0
                            if (bool_CurrentBit == false)
                            {
                                // оптимизация по скорости: если текущей номер группы равен 
                                // по длине предыдущей то переходим на следющий код Хаффмана 
                                if (int_LastNumberOfGroup == int_CurrentNumberOfGroup)
                                {
                                    int_CurrentNumberOfGroup = 0;
                                    break;
                                }

                                int_LastNumberOfGroup = int_CurrentNumberOfGroup;
                                int_CurrentLengthOfIndex = (bitArray_LastObject.Length - 1) - int_CurrentNumberOfGroup;

                                arrayList_LengthsOfIndexes.Add(int_CurrentLengthOfIndex);
                                arrayList_LengthsOfGroups.Add(int_CurrentNumberOfGroup);
                                arrayList_GroupsPositions.Add(int_CycleCount);

                                int_CurrentNumberOfGroup = 0;

                                break;
                            }

                            int_CurrentNumberOfGroup++;

                        }
                    }
                }
                
                internal void GenerateMapOfPrefixCodes(int int_PositiveNumbersAmount)
                {
                    #region Members Declaration

                    arrayList_MapOfPrefixCodes = new List<BitArray>();

                    BitArray bitArray_PrefixCodesBits, bitArray_NumberInGroup;

                    short short_RequiredBitsAmount = 0, short_GroupNumber = 0,
                        short_NumberLengthInGroup = 0, short_GroupsAmount = 0;

                    #endregion

                    short_GroupsAmount = 7;

                    // FOR for each element.
                    for (short short_CycleCount = 0; short_CycleCount < 256; short_GroupNumber++)
                    {
                        short_RequiredBitsAmount = (short)Math.Pow(2, short_GroupNumber);

                        short_NumberLengthInGroup = short_GroupNumber;

                        for (short short_SubCycleCount = 0; short_SubCycleCount != short_RequiredBitsAmount; short_SubCycleCount++)
                        {
                            if (short_CycleCount++ == 256) break;

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

                    CalculateLengthsOfGroupsAndIndexers();
                }

            }

            internal class PrefixCodesSupportForLZSSDistancesAndLRE
            {
                /*
                internal ArrayList arrayList_MapOfPrefixCodes, arrayList_GroupsPositions,
                         arrayList_LengthsOfIndexes, arrayList_LengthsOfGroups;
                */
                internal ArrayList arrayList_MapOfPrefixCodes;//!!

                internal List<int> arrayList_GroupsPositions, arrayList_LengthsOfIndexes, arrayList_LengthsOfGroups;
                

                BitArray bitArray_ReadedData = new BitArray(16);

                byte byte_NumberOfGroup = 0;

                int[] intArray_DecodedPrefixCodesCode = new int[2];

                public int[] DecodedPrefixCodesCode
                {
                    get
                    {
                        return intArray_DecodedPrefixCodesCode;
                    }
                }


                #region intArray_DecodedPrefixCodesCode Overview
                /*	
					intArray_DecodedPrefixCodesCode[0] is decimal 
					representation of PrefixCodesCode and 
					intArray_DecodedPrefixCodesCode[1] is PrefixCodesCode
					length in Bits
				*/
                #endregion

                internal void ConvertPrefixCodesCodeToDecimal(ref BitArray bitArray_CompressedData, int int_CurrentBitPosition)
                {

                    #region Processing when Current Bit is 0 (false)

                    if (bitArray_CompressedData[int_CurrentBitPosition] == false)
                    {
                        intArray_DecodedPrefixCodesCode[0] = 0;
                        intArray_DecodedPrefixCodesCode[1] = int_CurrentBitPosition + 1;

                        return;
                    }

                    #endregion

                    int int_IndexOfByte = 0, int_CurrentBitPos = 0,
                        int_CountOfGroups = arrayList_GroupsPositions.Count - 1;

                    byte_NumberOfGroup = 0;

                    #region Calculate Group Length

                    for (; bitArray_CompressedData[int_CurrentBitPosition] != false; byte_NumberOfGroup++, int_CurrentBitPosition++)
                    {
                        if (byte_NumberOfGroup == (int)arrayList_LengthsOfGroups[arrayList_LengthsOfGroups.Count - 1])
                        {
                            int_CurrentBitPosition++;
                            byte_NumberOfGroup++;
                            break;
                        }
                    }

                    #endregion

                    int_IndexOfByte = (int)arrayList_GroupsPositions[byte_NumberOfGroup];

                    #region Calculate Position of PrefixCodes Code Index

                    if ((int)arrayList_LengthsOfIndexes[byte_NumberOfGroup] > 0)
                    {
                        int_CurrentBitPosition++;

                        bitArray_ReadedData.Length = (int)arrayList_LengthsOfIndexes[byte_NumberOfGroup];

                        for (int int_CycleCount = 0; int_CycleCount != bitArray_ReadedData.Length; int_CycleCount++)
                        {
                            bitArray_ReadedData[int_CycleCount] = bitArray_CompressedData[int_CurrentBitPosition];
                            int_CurrentBitPosition++;
                        }

                        int_CurrentBitPos = bitArray_ReadedData.Length - 1;

                        //перевод из двоичного числа в десятичное.
                        for (int int_CycleCount = 0; int_CycleCount != bitArray_ReadedData.Length; int_CycleCount++, int_CurrentBitPos--)
                        {
                            if (bitArray_ReadedData[int_CycleCount] == true)
                                int_IndexOfByte += (int)Math.Pow(2, int_CurrentBitPos);
                        }
                    }

                    else if ((int)arrayList_LengthsOfIndexes[byte_NumberOfGroup] == 0) int_CurrentBitPosition++;

                    #endregion

                    intArray_DecodedPrefixCodesCode[0] = int_IndexOfByte;
                    intArray_DecodedPrefixCodesCode[1] = int_CurrentBitPosition;
                }


                void CalculateLengthsOfGroupsAndIndexers()
                {
                    arrayList_GroupsPositions = new List<int>();
                    arrayList_LengthsOfIndexes = new List<int>();
                    arrayList_LengthsOfGroups = new List<int>();

                    int int_LastNumberOfGroup = -1, int_CurrentNumberOfGroup = 0,
                        int_CurrentLengthOfIndex = -1;

                    BitArray bitArray_LastObject;

                    // общий цикл для последовательной обработки всех кодов Хаффмана(BitArray) в Листе(ArrayList)
                    for (int int_CycleCount = 0; int_CycleCount != arrayList_MapOfPrefixCodes.Count; int_CycleCount++)
                    {
                        bitArray_LastObject = (BitArray)arrayList_MapOfPrefixCodes[int_CycleCount];

                        // цикл для обработки текущего кода Хаффмана(BitArray)
                        foreach (bool bool_CurrentBit in bitArray_LastObject)
                        {
                            // последний код - состоящий ТОЛЬКО из единиц (true) потому длина индекса выставляется в -1
                            if (int_CurrentNumberOfGroup == bitArray_LastObject.Length - 1 && bitArray_LastObject[bitArray_LastObject.Length - 1] != false)
                            {
                                arrayList_LengthsOfIndexes.Add(-1);
                                arrayList_LengthsOfGroups.Add(int_CurrentNumberOfGroup++);
                                arrayList_GroupsPositions.Add(int_CycleCount);
                            }

                            // встретили бит-разделитель 0
                            if (bool_CurrentBit == false)
                            {
                                // оптимизация по скорости: если текущей номер группы равен 
                                // по длине предыдущей то переходим на следющий код Хаффмана 
                                if (int_LastNumberOfGroup == int_CurrentNumberOfGroup)
                                {
                                    int_CurrentNumberOfGroup = 0;
                                    break;
                                }

                                int_LastNumberOfGroup = int_CurrentNumberOfGroup;
                                int_CurrentLengthOfIndex = (bitArray_LastObject.Length - 1) - int_CurrentNumberOfGroup;

                                arrayList_LengthsOfIndexes.Add(int_CurrentLengthOfIndex);
                                arrayList_LengthsOfGroups.Add(int_CurrentNumberOfGroup);
                                arrayList_GroupsPositions.Add(int_CycleCount);

                                int_CurrentNumberOfGroup = 0;

                                break;
                            }

                            int_CurrentNumberOfGroup++;

                        }
                    }
                }


                internal void GenerateMapOfPrefixCodes(int int_PositiveNumbersAmount)
                {

                    #region Members Declaration

                    arrayList_MapOfPrefixCodes = new ArrayList();//!!

                    BitArray bitArray_PrefixCodesBits, bitArray_NumberInGroup;

                    int short_RequiredBitsAmount = 0, short_GroupNumber = 0,
                        short_NumberLengthInGroup = 0, short_GroupsAmount = 0;

                    #endregion

                    short_GroupsAmount = 15;

                    // FOR for each element.
                    for (int short_CycleCount = 0; short_CycleCount < int_PositiveNumbersAmount; short_GroupNumber++)
                    {
                        short_RequiredBitsAmount = (int)Math.Pow(2, short_GroupNumber);

                        short_NumberLengthInGroup = short_GroupNumber;

                        for (int short_SubCycleCount = 0; short_SubCycleCount != short_RequiredBitsAmount; short_SubCycleCount++)
                        {
                            if (short_CycleCount++ == int_PositiveNumbersAmount) break;

                            if (short_GroupNumber > (short_GroupsAmount - 1))
                            {
                                short_NumberLengthInGroup = (((short_GroupsAmount * 2) - 1) - short_GroupNumber);

                                if (short_NumberLengthInGroup <= 0) short_NumberLengthInGroup = 0;

                                short_RequiredBitsAmount = (int)Math.Pow(2, short_NumberLengthInGroup);
                            }

                            if (short_GroupNumber > (short_GroupsAmount * 2))
                            {
                                arrayList_MapOfPrefixCodes.Add(new BitArray(short_GroupNumber, true));
                                break;
                            }

                            bitArray_NumberInGroup = new BitArray(BitConverter.GetBytes(short_SubCycleCount));

                            if (short_SubCycleCount < 2) bitArray_NumberInGroup.Length = 1;
                            if (short_SubCycleCount > 1 && short_SubCycleCount < 4) bitArray_NumberInGroup.Length = 2;
                            if (short_SubCycleCount > 3 && short_SubCycleCount < 8) bitArray_NumberInGroup.Length = 3;
                            if (short_SubCycleCount > 7 && short_SubCycleCount < 16) bitArray_NumberInGroup.Length = 4;
                            if (short_SubCycleCount > 15 && short_SubCycleCount < 32) bitArray_NumberInGroup.Length = 5;
                            if (short_SubCycleCount > 31 && short_SubCycleCount < 64) bitArray_NumberInGroup.Length = 6;
                            if (short_SubCycleCount > 63 && short_SubCycleCount < 128) bitArray_NumberInGroup.Length = 7;
                            if (short_SubCycleCount > 127 && short_SubCycleCount < 256) bitArray_NumberInGroup.Length = 8;
                            if (short_SubCycleCount > 255 && short_SubCycleCount < 512) bitArray_NumberInGroup.Length = 9;
                            if (short_SubCycleCount > 511 && short_SubCycleCount < 1024) bitArray_NumberInGroup.Length = 10;
                            if (short_SubCycleCount > 1023 && short_SubCycleCount < 2048) bitArray_NumberInGroup.Length = 11;
                            if (short_SubCycleCount > 2047 && short_SubCycleCount < 4096) bitArray_NumberInGroup.Length = 12;
                            if (short_SubCycleCount > 4095 && short_SubCycleCount < 8192) bitArray_NumberInGroup.Length = 13;
                            if (short_SubCycleCount > 8191 && short_SubCycleCount < 16384) bitArray_NumberInGroup.Length = 14;
                            if (short_SubCycleCount > 16383 && short_SubCycleCount < 32768) bitArray_NumberInGroup.Length = 15;
                            if (short_SubCycleCount > 32767) bitArray_NumberInGroup.Length = 16;

                            if (short_CycleCount == 0) bitArray_NumberInGroup.Length = 0;


                            // создание префиксного кода после расчётов 

                            bitArray_NumberInGroup.Length = short_NumberLengthInGroup;

                            bitArray_PrefixCodesBits = new BitArray(short_GroupNumber + 1 + short_NumberLengthInGroup, true);
                            bitArray_PrefixCodesBits[short_GroupNumber] = false;

                            #region Устанавливаем все биты Номера В Группе в bitArray_PrefixCodesBits

                            for (int short_ThirdCycleCount = 0, short_CurrentBitPos = bitArray_PrefixCodesBits.Length - 1
                                    ; short_CurrentBitPos != short_GroupNumber; short_CurrentBitPos--, short_ThirdCycleCount++)
                            {
                                bitArray_PrefixCodesBits[short_CurrentBitPos] = bitArray_NumberInGroup[short_ThirdCycleCount];
                            }

                            #endregion

                            arrayList_MapOfPrefixCodes.Add(bitArray_PrefixCodesBits);
                        }
                    }

                    CalculateLengthsOfGroupsAndIndexers();
                }
            }


            #endregion

            #region Some Foundamental and Simple methods

            internal byte[] AddUnusedsBitsCountInfo(BitArray bitArray_obj, MemoryStream memoryStream_CompressedData)
            {
                byte[] byteArray_CompressedBlock = null;

                decimal decimal_CompressedDataLengthInBits = bitArray_obj.Length;

                #region Calculate and Write numbers of unused bits at EOF

                short short_PrefixCodesBitsModuluss = (short)(bitArray_obj.Length % 8);

                if (short_PrefixCodesBitsModuluss > 0) decimal_CompressedDataLengthInBits += 8 - short_PrefixCodesBitsModuluss;

                #endregion

                bitArray_obj.Length = (int)decimal_CompressedDataLengthInBits;

                byteArray_CompressedBlock = new byte[(int)decimal_CompressedDataLengthInBits / 8];

                bitArray_obj.CopyTo(byteArray_CompressedBlock, 0);

                memoryStream_CompressedData.Write(byteArray_CompressedBlock, 0, byteArray_CompressedBlock.Length);

                memoryStream_CompressedData.Position = 0;

                if (short_PrefixCodesBitsModuluss > 0)
                {
                    memoryStream_CompressedData.WriteByte((byte)(8 - short_PrefixCodesBitsModuluss));
                }

                return memoryStream_CompressedData.ToArray();
            }


            internal void WriteDecimalNumberToBitArray(ref BitArray bitArray_CompressedData, int int_PositionToWrite, byte byte_SizeOfNumberInBits, int int_DecimalNumber)
            {
                for (int int_CycleCount = byte_SizeOfNumberInBits - 1; int_CycleCount != -1; int_CycleCount--)
                {
                    if ((int_DecimalNumber / 2) * 2 == int_DecimalNumber)
                    {
                        bitArray_CompressedData[int_PositionToWrite + int_CycleCount] = false;
                    }
                    else
                    {
                        bitArray_CompressedData[int_PositionToWrite + int_CycleCount] = true;
                    }

                    int_DecimalNumber = int_DecimalNumber / 2;
                }
            }


            internal int ReadDecimalNumberFromBitArray(ref BitArray bitArray_CompressedData, int int_StartPositionToRead, byte byte_SizeOfNumberInBits)
            {
                int int_CurrentBitPos = int_StartPositionToRead + (byte_SizeOfNumberInBits - 1), int_DecimalResult = 0;

                for (int int_CycleCount = 0; int_CycleCount != byte_SizeOfNumberInBits; int_CycleCount++, int_CurrentBitPos--)
                {
                    if (bitArray_CompressedData[int_CurrentBitPos] == true) int_DecimalResult += (int)Math.Pow(2, int_CycleCount);
                }

                return int_DecimalResult;
            }


            internal byte[] GetByteArrayPart(byte[] byteArray_FullBytesArray, int int_StartPosition, int int_Length)
            {
                byte[] byteArray_NewBuffer = new byte[int_Length];

                int int_PositionInNewBuffer = 0;

                for (int int_CycleCount = 0; int_CycleCount != int_Length; int_CycleCount++, int_PositionInNewBuffer++)
                {
                    byteArray_NewBuffer[int_PositionInNewBuffer] = byteArray_FullBytesArray[int_StartPosition + int_CycleCount];
                }

                return byteArray_NewBuffer;
            }


            internal bool IsBytesArraysEquals(ref byte[] byteArray_InitialData, ref byte[] byteArray_ComparedData)
            {
                if (byteArray_InitialData.Length != byteArray_ComparedData.Length) return false;

                for (int int_CycleCount = 0; int_CycleCount != byteArray_InitialData.Length; int_CycleCount++)
                {
                    if (byteArray_InitialData[int_CycleCount] != byteArray_ComparedData[int_CycleCount]) return false;
                }

                return true;
            }
            
            #endregion

            #region Common Methods

            internal bool IsDecompressionPossible(ref byte[] byteArray_MinimalVersionNeeded, ref byte[] byteArray_CurrentVersion)
            {
                if (byteArray_MinimalVersionNeeded[1] != 46 || byteArray_MinimalVersionNeeded[3] != 46) return false;

                byte byte_MinimalVersionFirstNumber = byte.Parse(Encoding.Default.GetString(byteArray_MinimalVersionNeeded, 0, 1)),
                     byte_MinimalVersionSecondNumber = byte.Parse(Encoding.Default.GetString(byteArray_MinimalVersionNeeded, 2, 1)),
                     byte_MinimalVersionThirdNumber = byte.Parse(Encoding.Default.GetString(byteArray_MinimalVersionNeeded, 4, 1));

                byte byte_CurrentVersionFirstNumber = byte.Parse(Encoding.Default.GetString(byteArray_CurrentVersion, 0, 1)),
                     byte_CurrentVersionSecondNumber = byte.Parse(Encoding.Default.GetString(byteArray_CurrentVersion, 2, 1)),
                     byte_CurrentVersionThirdNumber = byte.Parse(Encoding.Default.GetString(byteArray_CurrentVersion, 4, 1));


                string string_MinimalVersionNumber = byte_MinimalVersionFirstNumber.ToString() + byte_MinimalVersionSecondNumber.ToString() + byte_MinimalVersionThirdNumber.ToString();
                string string_CurrentVersionNumber = byte_CurrentVersionFirstNumber.ToString() + byte_CurrentVersionSecondNumber.ToString() + byte_CurrentVersionThirdNumber.ToString();

                int int_MinimalVersionNumber = int.Parse(string_MinimalVersionNumber),
                    int_CurrentVersionNumber = int.Parse(string_CurrentVersionNumber);

                if (int_MinimalVersionNumber > int_CurrentVersionNumber) return false;

                return true;
            }



            /// <returns> 
            /// An Decompressed array of bytes with length > 0. 
            /// </returns>
            /// 
            /// <summary>
            /// 
            /// Decompress input byte array that was been previously compressed by any of compression algorithm using JurikSoft Compression Library (version 1.1.0).
            /// 
            /// </summary>
            /// <example> This sample shows how to decompress byte array.
            /// <code>
            /// //Initializes a new instance of the CommonEnvironment class 
            /// JurikSoft.Compression.CommonEnvironment commonEnvironment_obj = 
            /// new JurikSoft.Compression.CommonEnvironment();
            ///  
            /// FileStream fileStream_DataFile = File.Open("compressed.dat");
            /// 
            /// byte [] byteArray_DataToCompress = new byte[fileStream_DataFile.Length],
            /// byte [] byteArray_DecompressedData = null;
            /// 
            /// fileStream_DataFile.Read(byteArray_DataToCompress, 0, byteArray_DataToCompress.Length);
            /// 
            /// //Decompress the data with verifing MD5 hash check sum
            /// byteArray_DecompressedData = commonEnvironment_obj.Decompress(byteArray_DataToCompress, true);
            /// 
            /// fileStream_DataFile.Close();
            /// 
            /// </code>
            /// </example>
            public byte[] Decompress(byte[] DataToDecompress, bool VerifyCheckSum)
            {
                CheckSN();

                if (DataToDecompress.Length < 46) throw new InvalidDataException();

                ushort ushort_AlgorithmID = 0;

                UInt64 uInt64_TotalCompressedSize = (UInt64)DataToDecompress.Length,
                       uInt64_StoredTotalCompressedSize = 0;

                MD5CryptoServiceProvider md5CryptoServiceProvider_HashOfCompressedData = null;

                UInt64 uInt64_TotalUncompressedSize = (UInt64)DataToDecompress.Length;

                byte[] byteArray_Header = Encoding.Default.GetBytes("JSCOMPLIB"),
                        byteArray_LibVersion = Encoding.Default.GetBytes("1.1.0"),
                        byteArray_HashOfCompressedData = null;

                byte[] byteArray_StoredHeader = null, byteArray_StoredLibVersion = null,
                        byteArray_StoredMinimumLibVersion = null, byteArray_StoredAlgorithmID = null,
                        byteArray_StoredTotalCompressedSize = null, byteArray_StoredHashOfCompressedData = null;

                byteArray_StoredHeader = GetByteArrayPart(DataToDecompress, 0, 9);
                byteArray_StoredLibVersion = GetByteArrayPart(DataToDecompress, 9, 5);
                byteArray_StoredMinimumLibVersion = GetByteArrayPart(DataToDecompress, 14, 5);
                byteArray_StoredAlgorithmID = GetByteArrayPart(DataToDecompress, 19, 2);
                byteArray_StoredTotalCompressedSize = GetByteArrayPart(DataToDecompress, 21, 8);
                byteArray_StoredHashOfCompressedData = GetByteArrayPart(DataToDecompress, 29, 16);

                uInt64_StoredTotalCompressedSize = BitConverter.ToUInt64(byteArray_StoredTotalCompressedSize, 0);

                if (IsBytesArraysEquals(ref byteArray_StoredHeader, ref byteArray_Header) == false) throw new InvalidDataHeaderException();
                if (IsDecompressionPossible(ref byteArray_StoredMinimumLibVersion, ref byteArray_LibVersion) == false) throw new InvalidDataException();
                if (uInt64_StoredTotalCompressedSize != uInt64_TotalCompressedSize) throw new WrongCompressedSizeException();

                for (int int_CycleCount = 29; int_CycleCount != 45; int_CycleCount++)
                {
                    DataToDecompress[int_CycleCount] = 0;
                }

                md5CryptoServiceProvider_HashOfCompressedData = new MD5CryptoServiceProvider();

                byteArray_HashOfCompressedData = md5CryptoServiceProvider_HashOfCompressedData.ComputeHash(DataToDecompress, 0, DataToDecompress.Length);

                if (IsBytesArraysEquals(ref byteArray_StoredHashOfCompressedData, ref byteArray_HashOfCompressedData) == false)
                    throw new CompressedHashesAreNotEqualException();

                ushort_AlgorithmID = BitConverter.ToUInt16(byteArray_StoredAlgorithmID, 0);

                switch (ushort_AlgorithmID)
                {
                    case 0:
                        {
                            PrefixCodes PrefixCodes_obj = new PrefixCodes(false);
                            return PrefixCodes_obj.Decompress(GetByteArrayPart(DataToDecompress, 45, DataToDecompress.Length - 45), VerifyCheckSum);
                        }

                    case 1:
                        {
                            LZSS lzss_obj = new LZSS(50, true, true, false, 128000);
                            return lzss_obj.Decompress(GetByteArrayPart(DataToDecompress, 45, DataToDecompress.Length - 45), VerifyCheckSum);
                        }

                    case 2:
                        {
                            RLE rle_obj = new RLE(PrefixCodesCompression.NonAdaptive);
                            return rle_obj.Decompress(GetByteArrayPart(DataToDecompress, 45, DataToDecompress.Length - 45), VerifyCheckSum);
                        }
                }

                return null;
            }

            internal byte[] AddSystemInformation(ref byte[] byteArray_ProcessedData, ushort ushort_AlgorithmID)
            {
                int int_CurrentPositionInData = 0, int_CycleCount = 0;

                MD5CryptoServiceProvider md5CryptoServiceProvider_HashOfCompressedData = null;

                byte[] byteArray_Header = null, byteArray_LibVersion = null,
                        byteArray_MinimumLibVersion = null, byteArray_AlgorithmID = null,
                        byteArray_TotalCompressedSize = null, byteArray_HashOfCompressedData = null;

                byteArray_Header = Encoding.Default.GetBytes("JSCOMPLIB"); // 9 bytes
                byteArray_LibVersion = Encoding.Default.GetBytes("1.1.0"); // 5 bytes
                byteArray_MinimumLibVersion = Encoding.Default.GetBytes("1.1.0"); // 5 bytes
                byteArray_AlgorithmID = BitConverter.GetBytes(ushort_AlgorithmID); // 2 bytes
                byteArray_TotalCompressedSize = BitConverter.GetBytes((UInt64)(byteArray_ProcessedData.Length)); // 8 bytes

                for (int_CycleCount = 0; int_CycleCount != byteArray_Header.Length; int_CycleCount++)
                {
                    byteArray_ProcessedData[int_CycleCount] = byteArray_Header[int_CycleCount];
                }
                int_CurrentPositionInData += int_CycleCount;

                for (int_CycleCount = 0; int_CycleCount != byteArray_LibVersion.Length; int_CycleCount++)
                {
                    byteArray_ProcessedData[int_CycleCount + int_CurrentPositionInData] = byteArray_LibVersion[int_CycleCount];
                }
                int_CurrentPositionInData += int_CycleCount;

                for (int_CycleCount = 0; int_CycleCount != byteArray_MinimumLibVersion.Length; int_CycleCount++)
                {
                    byteArray_ProcessedData[int_CycleCount + int_CurrentPositionInData] = byteArray_MinimumLibVersion[int_CycleCount];
                }
                int_CurrentPositionInData += int_CycleCount;

                for (int_CycleCount = 0; int_CycleCount != byteArray_AlgorithmID.Length; int_CycleCount++)
                {
                    byteArray_ProcessedData[int_CycleCount + int_CurrentPositionInData] = byteArray_AlgorithmID[int_CycleCount];
                }
                int_CurrentPositionInData += int_CycleCount;

                for (int_CycleCount = 0; int_CycleCount != byteArray_TotalCompressedSize.Length; int_CycleCount++)
                {
                    byteArray_ProcessedData[int_CycleCount + int_CurrentPositionInData] = byteArray_TotalCompressedSize[int_CycleCount];
                }
                int_CurrentPositionInData += int_CycleCount;


                md5CryptoServiceProvider_HashOfCompressedData = new MD5CryptoServiceProvider();

                byteArray_HashOfCompressedData = md5CryptoServiceProvider_HashOfCompressedData.ComputeHash(byteArray_ProcessedData, 0, byteArray_ProcessedData.Length);

                for (int_CycleCount = 0; int_CycleCount != byteArray_HashOfCompressedData.Length; int_CycleCount++)
                {
                    byteArray_ProcessedData[int_CycleCount + int_CurrentPositionInData] = byteArray_HashOfCompressedData[int_CycleCount];
                }

                return byteArray_ProcessedData;
            }


            #endregion

            #region Exceptions

            /// <summary> 
            /// The base JurikSoft Conpression exception.
            /// </summary>
            public class CompressionException : System.Exception
            {
                /// <summary> 
                /// Gets a message that describes the current exception.
                /// </summary>
                public override string Message
                {
                    get
                    {
                        return "Base JurikSoft Compression Library exception.";
                    }
                }
            }

            /// <summary> 
            /// The exception that is thrown when compression data is invalid.
            /// </summary>
            public class InvalidDataException : CompressionException
            {
                /// <summary> 
                /// Gets a message that describes the current exception.
                /// </summary>
                public override string Message
                {
                    get
                    {
                        return "Compressed data is corrupted or invalid.";
                    }
                }
            }

            /// <summary> 
            /// The exception that is thrown when header of compressed data is invalid.
            /// </summary>
            public class InvalidDataHeaderException : CompressionException
            {
                /// <summary> 
                /// Gets a message that describes the current exception.
                /// </summary>
                public override string Message
                {
                    get
                    {
                        return "Compressed data header is corrupted or invalid.";
                    }
                }
            }

            /// <summary> 
            /// The exception that is thrown when stored length of compressed data is not corresponding with actual data length.
            /// </summary>
            public class WrongCompressedSizeException : CompressionException
            {
                /// <summary> 
                /// Gets a message that describes the current exception.
                /// </summary>
                public override string Message
                {
                    get
                    {
                        return "Wrong size of compressed data.";
                    }
                }
            }

            /// <summary> 
            /// The exception that is thrown when stored length of decompressed data is not corresponding with actual decompressed data length.
            /// </summary>
            public class WrongDecompressedSizeException : CompressionException
            {
                /// <summary> 
                /// Gets a message that describes the current exception.
                /// </summary>
                public override string Message
                {
                    get
                    {
                        return "Wrong size of decompressed data.";
                    }
                }
            }

            /// <summary> 
            /// The exception that is thrown when stored check sum of decompressed data is not corresponding with actual check sum of decompressed data.
            /// </summary>
            public class WrongDecompressedDataHashException : CompressionException
            {
                /// <summary> 
                /// Gets a message that describes the current exception.
                /// </summary>
                public override string Message
                {
                    get
                    {
                        return "Wrong MD5 hash of decompressed data.";
                    }
                }
            }

            /// <summary> 
            /// The exception that is thrown when stored check sum of compressed data is not corresponding with actual check sum of compressed data.
            /// </summary>
            public class CompressedHashesAreNotEqualException : CompressionException
            {
                /// <summary> 
                /// Gets a message that describes the current exception.
                /// </summary>
                public override string Message
                {
                    get
                    {
                        return "Wrong MD5 hash of compressed data.";
                    }
                }
            }

            /// <summary> 
            /// The exception that is thrown when JurikSoft Compression Library version less than needed to decompress data.
            /// </summary>
            public class VersionLessThanNeededException : CompressionException
            {
                /// <summary> 
                /// Gets a message that describes the current exception.
                /// </summary>
                public override string Message
                {
                    get
                    {
                        return "Used version of JurikSoft Compression Library is less than version needed to decompress.";
                    }
                }
            }

            /// <summary> 
            /// The exception that is thrown when compressed data has zero length.
            /// </summary>
            public class CompressedDataHasZeroLengthException : CompressionException
            {
                /// <summary> 
                /// Gets a message that describes the current exception.
                /// </summary>
                public override string Message
                {
                    get
                    {
                        return "Data to compress cannot be a zero length.";
                    }
                }
            }

            /// <summary> 
            /// The exception that is thrown when there is an attempt to decompress byte array that is a null object reference.
            /// </summary>
            public class CompressedDataArrayIsNullReferenceException : CompressionException
            {
                /// <summary> 
                /// Gets a message that describes the current exception.
                /// </summary>
                public override string Message
                {
                    get
                    {
                        return "Compressed data byte array is not initialized.";
                    }
                }
            }

            #endregion
        }
    }
}
