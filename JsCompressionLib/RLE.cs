using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JurikSoft
{
	namespace Compression
	{
		/// <summary>
		/// Represents the class of the Run Length Encoding compression algorithm.
		/// </summary>
		public class RLE : ICompression
		{
			/// <summary>
			/// 
			///Initializes a new instance of the RLE class with a affected PrefixCodes algorithm.
			/// 
			/// </summary>
			public RLE(PrefixCodesCompression PrefixCodes_Settings)
			{
				PrefixCodesSupportForDistancesAndRLE = new CommonEnvironment.PrefixCodesSupportForLZSSDistancesAndLRE();
				PrefixCodesSupportForDistancesAndRLE.GenerateMapOfPrefixCodes(65536);
 
				this.PrefixCodes_Settings = PrefixCodes_Settings;

				commonEnvironment_obj = new CommonEnvironment();

				bitArray_MetaData = new BitArray(10000);

				int_RLEBytesFounded = 0;
			}

			
			internal PrefixCodesCompression PrefixCodes_Settings;

			internal CommonEnvironment commonEnvironment_obj;
							
			internal CommonEnvironment.PrefixCodesSupportForLZSSDistancesAndLRE PrefixCodesSupportForDistancesAndRLE;

			internal BitArray bitArray_MetaData = new BitArray(10000);
			
			internal int int_RLEBytesFounded = 0;
				
			internal int CalculateRLEBytesCount(ref byte [] byteArray_DataToCompress, int int_CurrentPositionInData)
			{
				int_RLEBytesFounded = 1;

				while(true)
				{	
					if(int_CurrentPositionInData + int_RLEBytesFounded >= byteArray_DataToCompress.Length) break;
			
					if(byteArray_DataToCompress[int_CurrentPositionInData] == byteArray_DataToCompress[int_CurrentPositionInData + int_RLEBytesFounded])
					int_RLEBytesFounded++;	

					else break;

					if(int_RLEBytesFounded == 65537) break;								
				}
				
				return int_RLEBytesFounded;     
			}

			
			PrefixCodes PrefixCodes_obj = new PrefixCodes(false);

			/// <summary> 
			/// Compress input byte array using RLE algorithm.
			/// </summary>
			/// 
			/// <returns> 
			/// An Compressed array of bytes with length > 0. 
			/// </returns>
			/// 
			/// <param name="DataToCompress">
			/// The input data to compress using RLE algorithm.
			/// </param>/ 	 
			/// 	
			/// <param name="AddCheckSum">
			/// Indicating whether add to compressed data MD5 Hash check sum.
			/// </param>
			/// 
			/// <example> This sample shows how to compress byte array.
			/// <code>
			/// //Initializes a new instance of the RLE class with a compression parameter:
			/// //PrefixCodesCompression enum value that indicate use PrefixCode to compress 
			/// //single uncompressed bytes or store bytes uncompressed
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
			/// 
			public byte [] Compress(byte [] DataToCompress, bool AddCheckSum)
			{
				if(DataToCompress == null) throw new CommonEnvironment.CompressedDataArrayIsNullReferenceException();
				if(DataToCompress.Length == 0) throw new CommonEnvironment.CompressedDataHasZeroLengthException();

				BitArray bitArray_CurrentPrefixCodesCode = null;
		
				MemoryStream memoryStream_SavedLiterals = new MemoryStream(),
							 memoryStream_MetaData = new MemoryStream(),
							 memoryStream_CompressedData = new MemoryStream();
				
				PrefixCodes_obj = new PrefixCodes(false);

				byte [] byteArray_HashOfDecompressedData = null, byteArray_CompressedData = null, 
						byteArray_CompressedLiterals = null, byteArray_CompressedBlock = null;

				memoryStream_MetaData.Position = 1;

				int int_CurrentPositionInBitArray = 0;

				for(int int_CurrentPositionInData = 0; int_CurrentPositionInData < DataToCompress.Length; ) 
				{
					CalculateRLEBytesCount(ref DataToCompress, int_CurrentPositionInData);

					memoryStream_SavedLiterals.WriteByte(DataToCompress[int_CurrentPositionInData++]);

					if(bitArray_MetaData.Length <= int_CurrentPositionInBitArray + 1000) 
					   bitArray_MetaData.Length += 100000;

					if(int_RLEBytesFounded >= 2)
					{
						int_CurrentPositionInData += int_RLEBytesFounded-1;

						bitArray_MetaData[int_CurrentPositionInBitArray++] = true;

						bitArray_CurrentPrefixCodesCode = (BitArray)PrefixCodesSupportForDistancesAndRLE.arrayList_MapOfPrefixCodes[int_RLEBytesFounded-2];
						
						foreach(bool bool_CurrentPrefixCodesBit in bitArray_CurrentPrefixCodesCode)
						{
							bitArray_MetaData[int_CurrentPositionInBitArray++] = bool_CurrentPrefixCodesBit;
						}	

						if(int_CurrentPositionInBitArray % 8 == 0)
						{
							bitArray_MetaData.Length = int_CurrentPositionInBitArray;

							byteArray_CompressedBlock = new byte[int_CurrentPositionInBitArray / 8];

							bitArray_MetaData.CopyTo(byteArray_CompressedBlock, 0);

							memoryStream_MetaData.Write(byteArray_CompressedBlock, 0, byteArray_CompressedBlock.Length);

							bitArray_MetaData = new BitArray(10000);

							int_CurrentPositionInBitArray = 0;
						}

						continue;
					}

					bitArray_MetaData[int_CurrentPositionInBitArray++] = false;
				}

				/*				 
				 * 	first 45 bytes Empty for System Data Information
				 *  8 bytes for Total Decompressed Size (UInt64)
				 *	1 byte to Hash Flag + 16 bytes of Decompressed Data MD5 Hash 
				 *  4 bytes for Literals Block Length (int)
				 *  X bytes Literals Block
				 *  4 bytes for Meta Data Block Length (int)
				 *  X bytes Meta Data Block	(UnUseds bits count and then Meta Data)			 
				*/

				memoryStream_CompressedData.Position = 45;

				#region Total Decompressed Size

				memoryStream_CompressedData.Write(BitConverter.GetBytes((UInt64)DataToCompress.Length), 0, 8);
				
				#endregion
	
				#region Hash Of Decompressed Data
				
				if(AddCheckSum)
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

				#region Post processing and Writing saved literals into Compressed memory Stream

				int int_StaticPrefixCodesCompressedLiteralsSize = PrefixCodes_obj.DataAnalyzer(memoryStream_SavedLiterals.ToArray(), false);
							
				if(PrefixCodes_Settings == PrefixCodesCompression.DoNotUse || int_StaticPrefixCodesCompressedLiteralsSize >= memoryStream_SavedLiterals.ToArray().Length)
				{
					memoryStream_CompressedData.WriteByte(0); // 0 is uncompressed

					memoryStream_CompressedData.Write(BitConverter.GetBytes(memoryStream_SavedLiterals.ToArray().Length), 0, 4);

					memoryStream_CompressedData.Write(memoryStream_SavedLiterals.ToArray(), 0, memoryStream_SavedLiterals.ToArray().Length);
				}
				else
				{									
					if(PrefixCodes_Settings == PrefixCodesCompression.NonAdaptive)
					{
						memoryStream_CompressedData.WriteByte(1); // 1 is PrefixCodes Non Adaptive
						PrefixCodes_obj.DataAnalyzer(memoryStream_SavedLiterals.ToArray(), false);
						byteArray_CompressedLiterals = PrefixCodes_obj.CompressUsingNonAdaptivePrefixCodesMethod(memoryStream_SavedLiterals.ToArray());
					}
					if(PrefixCodes_Settings == PrefixCodesCompression.Adaptive)
					{
						memoryStream_CompressedData.WriteByte(2); // 2 is PrefixCodes Adaptive
						PrefixCodes_obj.DataAnalyzer(memoryStream_SavedLiterals.ToArray(), true);
						byteArray_CompressedLiterals = PrefixCodes_obj.CompressUsingAdaptivePrefixCodesMethod(memoryStream_SavedLiterals.ToArray()); 
					}
					
					memoryStream_CompressedData.Write(BitConverter.GetBytes(byteArray_CompressedLiterals.Length), 0, 4);

					memoryStream_CompressedData.Write(byteArray_CompressedLiterals, 0, byteArray_CompressedLiterals.Length);
				}

				#endregion

				#region Write unuseds bits count

				bitArray_MetaData.Length = int_CurrentPositionInBitArray;

				new CommonEnvironment().AddUnusedsBitsCountInfo(bitArray_MetaData, memoryStream_MetaData);

				#endregion
				
				#region Write Meta Data and Meta Data Size

				memoryStream_CompressedData.Write(BitConverter.GetBytes((int)memoryStream_MetaData.ToArray().Length), 0, 4);
						
				memoryStream_CompressedData.Write(memoryStream_MetaData.ToArray(), 0, memoryStream_MetaData.ToArray().Length);

				#endregion				
         			
				byteArray_CompressedData = memoryStream_CompressedData.ToArray();

				memoryStream_CompressedData.Close();
				memoryStream_SavedLiterals.Close();
				memoryStream_MetaData.Close();

				commonEnvironment_obj.AddSystemInformation(ref byteArray_CompressedData, 2);

				return byteArray_CompressedData;
			}

				
			internal byte [] Decompress(byte [] DataToDecompress, bool VerifyCheckSum)
			{									
				MD5CryptoServiceProvider md5CryptoServiceProvider_HashOfDecompressedData = null;

				BitArray bitArray_CompressedData = null;

				MemoryStream memoryStream_DecompressedData = new MemoryStream(),
							 memoryStream_CompressedData = new MemoryStream(DataToDecompress);
				
				PrefixCodes_obj = new PrefixCodes(false);

				UInt64 uInt64_TotalDecompressedSize = 0;

				int int_CurrentPositionInBitArray = 0, int_CurrentLiteralPosition = 0,
					int_RLEBytesCount = 0, int_SizeOfLiteralsBlock = 0, int_SizeOfMetaDataBlock = 0;

				byte [] byteArray_StoredLiteralsBlock = null, byteArray_MetaData = null,
						byteArray_LiteralsBlock = null, byteArray_StoredHashOfDecompressedData = new byte[16],
						byteArray_DecompressedData = null, byteArray_ComputedHashOfDecompressedData = new byte[16];

				byte byte_UnusedBitsCount = 0, byte_StoredLiteral = 0, 
					 byte_LiteralsFormat = 0, byte_IsCheckSumExist = 0; 
			
				/*				 
				 *  8 bytes for Total Decompressed Size (UInt64)
				 *  1 byte - Hash Flag 
				 *	16 bytes of Decompressed Data MD5 Hash
				 *  4 bytes for Literals Block Length (int)
				 *  X bytes Literals Block
				 *  4 bytes for Meta Data Block Length (int)
				 *  X bytes Meta Data Block	(UnUseds bits count and then Meta Data)		 
				*/

				uInt64_TotalDecompressedSize = BitConverter.ToUInt64(memoryStream_CompressedData.ToArray(), 0);
				
				memoryStream_CompressedData.Position += 8;

				byte_IsCheckSumExist = (byte)memoryStream_CompressedData.ReadByte();

				if(byte_IsCheckSumExist == 1)
				{
					memoryStream_CompressedData.Read(byteArray_StoredHashOfDecompressedData, 0, byteArray_StoredHashOfDecompressedData.Length);
				}

				byte_LiteralsFormat = (byte)memoryStream_CompressedData.ReadByte();
			
							
				int_SizeOfLiteralsBlock = BitConverter.ToInt32(memoryStream_CompressedData.ToArray(), (int)memoryStream_CompressedData.Position);
				memoryStream_CompressedData.Position += 4;

				byteArray_StoredLiteralsBlock = new byte[int_SizeOfLiteralsBlock];

				memoryStream_CompressedData.Read(byteArray_StoredLiteralsBlock, 0, byteArray_StoredLiteralsBlock.Length);
				
				int_SizeOfMetaDataBlock = BitConverter.ToInt32(memoryStream_CompressedData.ToArray(), (int)memoryStream_CompressedData.Position);
				memoryStream_CompressedData.Position += 4;

				byteArray_MetaData = new byte[int_SizeOfMetaDataBlock];

				memoryStream_CompressedData.Read(byteArray_MetaData, 0, byteArray_MetaData.Length);

				bitArray_CompressedData = new BitArray(byteArray_MetaData);
		
				byte_UnusedBitsCount = (byte)byteArray_MetaData[0];


				switch(byte_LiteralsFormat)
				{
					case 0:
                        byteArray_LiteralsBlock = byteArray_StoredLiteralsBlock;
					break;
					
					case 1:
						byteArray_LiteralsBlock = PrefixCodes_obj.DecompressUsingNonAdaptivePrefixCodesMethod(byteArray_StoredLiteralsBlock);
					break;	
				
					case 2:
						byteArray_LiteralsBlock = PrefixCodes_obj.DecompressUsingAdaptivePrefixCodesMethod(byteArray_StoredLiteralsBlock);
					break;		
				}

				for(int_CurrentPositionInBitArray = 8, int_CurrentLiteralPosition = 0; 
					int_CurrentPositionInBitArray < bitArray_CompressedData.Length - byte_UnusedBitsCount; 
				   ) 
				{
					byte_StoredLiteral = byteArray_LiteralsBlock[int_CurrentLiteralPosition++];

					if(bitArray_CompressedData[int_CurrentPositionInBitArray++] == true)
					{	
						PrefixCodesSupportForDistancesAndRLE.ConvertPrefixCodesCodeToDecimal(ref bitArray_CompressedData, int_CurrentPositionInBitArray);

						int_RLEBytesCount = PrefixCodesSupportForDistancesAndRLE.DecodedPrefixCodesCode[0];
						int_CurrentPositionInBitArray = PrefixCodesSupportForDistancesAndRLE.DecodedPrefixCodesCode[1];

						int_RLEBytesCount += 2;

						for(int int_CycleCount = 0; int_CycleCount != int_RLEBytesCount; int_CycleCount++)
						{
                            memoryStream_DecompressedData.WriteByte(byte_StoredLiteral);
						}

						continue;
					}

					else memoryStream_DecompressedData.WriteByte(byte_StoredLiteral);
				}

				byteArray_DecompressedData = memoryStream_DecompressedData.ToArray();
				
				#region Verification for right hash

				md5CryptoServiceProvider_HashOfDecompressedData = new MD5CryptoServiceProvider();
			
				byteArray_ComputedHashOfDecompressedData = md5CryptoServiceProvider_HashOfDecompressedData.ComputeHash(byteArray_DecompressedData, 0, byteArray_DecompressedData.Length);
	
				#endregion
			
				if(uInt64_TotalDecompressedSize != (ulong)byteArray_DecompressedData.LongLength)
				throw new CommonEnvironment.WrongDecompressedSizeException();
			
				if(byte_IsCheckSumExist == 1 && VerifyCheckSum == true)
				{
					md5CryptoServiceProvider_HashOfDecompressedData = new MD5CryptoServiceProvider();
			
					byteArray_ComputedHashOfDecompressedData = md5CryptoServiceProvider_HashOfDecompressedData.ComputeHash(memoryStream_DecompressedData.ToArray(), 0, (int)memoryStream_DecompressedData.Position);
									
					if(commonEnvironment_obj.IsBytesArraysEquals(ref byteArray_ComputedHashOfDecompressedData, ref byteArray_StoredHashOfDecompressedData) == false)
						throw new CommonEnvironment.WrongDecompressedDataHashException();				
				}

				return byteArray_DecompressedData;
			}
		}
	}
}
