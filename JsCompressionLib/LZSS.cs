using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;


namespace JurikSoft
{
	namespace Compression
	{
		/// <summary>
		/// 
		/// Represents the class of the LZSS compression algorithm.
		/// 
		/// </summary>
		public class LZSS : ICompression
		{

			/// <summary>
			/// 
			///Initializes a new instance of the LZSS class with a compression parameters like a RLE compression, affected PrefixCodes algorithm, hash chains limit, Lazy matching technique and maximum block size.
			/// 
			/// </summary>
			public LZSS(byte HashChainsLimit, bool UsePrefixCodesCompression, bool ToUseLazyMatching, bool ToUseRLE, int MaximumDataBlockSize)
			{
				if(HashChainsLimit == 0) HashChainsLimit++;

				PrefixCodesSupportForDistancesAndRLE = new CommonEnvironment.PrefixCodesSupportForLZSSDistancesAndLRE();
				PrefixCodesSupportForLZSSLengths = new CommonEnvironment.PrefixCodesSupportForLZSSLengths();

				PrefixCodesSupportForDistancesAndRLE.GenerateMapOfPrefixCodes(65536);
				PrefixCodesSupportForLZSSLengths.GenerateMapOfPrefixCodes(256);

				short_HashChainsLimit = HashChainsLimit;

				this.ToUseLazyMatching = ToUseLazyMatching;
				
				this.UsePrefixCodesCompression = UsePrefixCodesCompression;
				
				this.ToUseRLE = ToUseRLE; 

				this.MaximumDataBlockSize = MaximumDataBlockSize;

				commonEnvironment_obj = new CommonEnvironment();				
			}


			internal bool ToUseLazyMatching = true, ToUseRLE = false, UsePrefixCodesCompression = false; 
			internal int MaximumDataBlockSize = 131072;
 

			internal void InitHashesArrayList()
			{
                arrayList_HashesList = new List<ThreeBytesInt16Hash>(65536);
                
				for(int int_CycleCount = 0; int_CycleCount != 65536; int_CycleCount++)
				{
					arrayList_HashesList.Add(null);
				}
			}

			internal void StartUpInitialization()
			{
	
				InitHashesArrayList();

				short_MaximumPraseLength = 3;
				short_PositionFromBeginningOfFirstFoundedMatch = 0; 							  
				short_LastFoundMatchesLength = 0; 
		
				int_StartPositionOfSecondFoundedMatch = 0;
				
				int_MaximumDictionaryLength = 3;							 
				int_CurrentMatchLength = 0; 
				int_CurrentMatchNumber = 0; 
				int_CurrentBlockPosition = 0;
							 
				ushort_CalculatedHashCode = 0; 
				int_RLEBytesCount = 0;

				byte_CountOfBitsToPhrasePos = 2;
				byte_CountOfBitsToPhraseLength = 2;				
				byte_MinDistanceBetweenChains = 0;

				switch(short_HashChainsLimit)
				{
					case 1:
						byte_MinDistanceBetweenChains = 31;
						break;

					case 2:
						byte_MinDistanceBetweenChains = 17;
						break;

					case 3:
						byte_MinDistanceBetweenChains = 16;
						break;

					case 4:
						byte_MinDistanceBetweenChains = 10;
						break;

					case 5:
						byte_MinDistanceBetweenChains = 7;
						break;

					case 6:
						byte_MinDistanceBetweenChains = 6;
						break;

					case 7:
						byte_MinDistanceBetweenChains = 5;
						break;

					case 8:
						byte_MinDistanceBetweenChains = 4;
						break;
				}

                if (short_HashChainsLimit >= 9)
                {
                    byte_MinDistanceBetweenChains = 3;
                }
			}

			
			internal int [] intArray_FoundedMatchInfo = new int[2],
							intArray_RLEBytesCountInfo = new int[2];

			internal short short_MaximumPraseLength = 3, short_PositionFromBeginningOfFirstFoundedMatch = 0, 
						   short_LastFoundMatchesLength = 0, short_HashChainsLimit = 50;
	
			internal int int_StartPositionOfSecondFoundedMatch = 0, int_MaximumDictionaryLength = 3,
						 int_CurrentMatchLength = 0, int_CurrentMatchNumber = 0, int_CurrentBlockPosition = 0,
						 int_RLEBytesCount = 0;

			internal byte byte_CountOfBitsToPhrasePos = 2, byte_CountOfBitsToPhraseLength = 2,
					      byte_MinDistanceBetweenChains = 0;

			ushort ushort_CalculatedHashCode = 0;

            List<ThreeBytesInt16Hash> arrayList_HashesList = new List<ThreeBytesInt16Hash>();

			internal ThreeBytesInt16Hash threeBytesInt16Hash_CurrentObj;	

			internal CommonEnvironment commonEnvironment_obj;
		
			internal CommonEnvironment.PrefixCodesSupportForLZSSDistancesAndLRE PrefixCodesSupportForDistancesAndRLE;
	
			internal CommonEnvironment.PrefixCodesSupportForLZSSLengths PrefixCodesSupportForLZSSLengths;

			internal void IncreaseDictionaryAndPhraseLength(int int_CurrentPositionInData)
			{
				#region Dinamic increase maximum Dictionary and Phrase lengths

				if(int_CurrentPositionInData > int_MaximumDictionaryLength && int_CurrentPositionInData < 65535)
				{
					int_MaximumDictionaryLength = int_MaximumDictionaryLength * 2;

					int_MaximumDictionaryLength++;

					byte_CountOfBitsToPhrasePos++;
				}

				if(int_CurrentPositionInData > short_MaximumPraseLength && short_MaximumPraseLength < 255)
				{
					if(byte_CountOfBitsToPhraseLength > 2) short_MaximumPraseLength -= 3;

					short_MaximumPraseLength = (short)(short_MaximumPraseLength * 2);

					short_MaximumPraseLength += 3;

					short_MaximumPraseLength++;

					byte_CountOfBitsToPhraseLength++;
				}

				#endregion
			}


			#region Class for hashes bytes and store chains  

			internal class ThreeBytesInt16Hash : List<int>
            {
				internal int int_HashCode = 0, int_CurrentPositionInMatchesStartArray = 0;

				internal ThreeBytesInt16Hash(short short_HashChainsLimit)
				{
					this.Capacity = short_HashChainsLimit;
				}
		
                internal void AddStartPositionOfNewMatch(int int_StartPositionInArray)
				{
					if(this.Count < this.Capacity)
					{
						this.Add(int_StartPositionInArray);		

						int_CurrentPositionInMatchesStartArray++;
					}

					else
					{
						if(int_CurrentPositionInMatchesStartArray >= this.Capacity) int_CurrentPositionInMatchesStartArray = 0;
			
						this[int_CurrentPositionInMatchesStartArray++] = int_StartPositionInArray;	
					}		
				}				
			}
		
			#endregion

			#region Methods for Add, Calculate and Find Hash Code Of The Next 3 bytes in Input Buffer

            internal unsafe void AddNewInt16HashOfPossibleMatch(ref byte[] byteArray_BytesToProcess, ref int int_MatchStartPositionInArray, ref int int_MaxIntervalBetweenMatches)
            {
				if(int_MatchStartPositionInArray + 3 >= byteArray_BytesToProcess.Length) return;
		
				#region Calculate Int32 hash for next 3 bytes

				ushort_CalculatedHashCode = 0;				

				ushort_CalculatedHashCode = (ushort)((( byteArray_BytesToProcess[int_MatchStartPositionInArray] ^ (byteArray_BytesToProcess[int_MatchStartPositionInArray + 1])<<7) ^ (byteArray_BytesToProcess[int_MatchStartPositionInArray + 2]) << 11) & 0xffff);

				#endregion 
	
				if(arrayList_HashesList[ushort_CalculatedHashCode] != null)
				{
					threeBytesInt16Hash_CurrentObj = arrayList_HashesList[ushort_CalculatedHashCode];

                    if (int_MatchStartPositionInArray - threeBytesInt16Hash_CurrentObj[threeBytesInt16Hash_CurrentObj.int_CurrentPositionInMatchesStartArray - 1] > byte_MinDistanceBetweenChains)
                    {
                        threeBytesInt16Hash_CurrentObj.AddStartPositionOfNewMatch(int_MatchStartPositionInArray);
                    }
					return;			
				}

				threeBytesInt16Hash_CurrentObj = new ThreeBytesInt16Hash(short_HashChainsLimit);

				threeBytesInt16Hash_CurrentObj.int_HashCode = ushort_CalculatedHashCode;

				threeBytesInt16Hash_CurrentObj.AddStartPositionOfNewMatch(int_MatchStartPositionInArray);	
		
				arrayList_HashesList[ushort_CalculatedHashCode] = threeBytesInt16Hash_CurrentObj;	
			}

            internal unsafe bool FindInt16HashOfPossibleMatch(ref byte[] byteArray_BytesToProcess, ref int int_StartPositionInArray)
            {
                //!!!
               
				if(int_StartPositionInArray + 3 >= byteArray_BytesToProcess.Length) return false;
					
				ushort_CalculatedHashCode = 0;	
			
				ushort_CalculatedHashCode = (ushort)((( byteArray_BytesToProcess[int_StartPositionInArray] ^ (byteArray_BytesToProcess[int_StartPositionInArray + 1]) << 7) ^ (byteArray_BytesToProcess[int_StartPositionInArray + 2]) << 11) & 0xffff);
                                        
				if(arrayList_HashesList[ushort_CalculatedHashCode] != null) return true;
				else return false;
			}
		
			#endregion
			
			#region Methods for Finding Best Match in Input buffer

            internal unsafe int ComputeLengthForPossibleMatch(ref byte[] byteArray_DataToCompress, int int_CurrentPositionInData, int int_StartPositionOfFirstFoundedMatch)
			{
				if(int_CurrentPositionInData >= byteArray_DataToCompress.Length ||
					int_CurrentPositionInData - int_StartPositionOfFirstFoundedMatch > int_MaximumDictionaryLength) return 0;
		
				short_LastFoundMatchesLength = 0;
				short_PositionFromBeginningOfFirstFoundedMatch = 0;
		
				if(byteArray_DataToCompress[int_StartPositionOfFirstFoundedMatch] ==
					byteArray_DataToCompress[int_CurrentPositionInData])
				{
					int_StartPositionOfSecondFoundedMatch = int_CurrentPositionInData;
					
					int_CurrentPositionInData++;
					short_PositionFromBeginningOfFirstFoundedMatch++;
	
					short_LastFoundMatchesLength = 1;
				
					while(
						int_CurrentPositionInData < byteArray_DataToCompress.Length
						&&
						short_MaximumPraseLength > short_LastFoundMatchesLength
						&&
						int_StartPositionOfSecondFoundedMatch > int_StartPositionOfFirstFoundedMatch + short_PositionFromBeginningOfFirstFoundedMatch
						&&
						byteArray_DataToCompress[int_StartPositionOfFirstFoundedMatch + short_LastFoundMatchesLength] ==
						byteArray_DataToCompress[int_CurrentPositionInData]
						)
					{	
						int_CurrentPositionInData++;					
						short_PositionFromBeginningOfFirstFoundedMatch++;											
						short_LastFoundMatchesLength++;	
					}			
									
					return short_LastFoundMatchesLength;
				}

				else return 0;
			}

            internal unsafe int[] FindBestMatch(ref byte[] byteArray_DataToCompress, ref int int_CurrentPositionInData)
            {
				intArray_FoundedMatchInfo[0] = 0;
				intArray_FoundedMatchInfo[1] = 0;

				int_CurrentMatchLength = 0;
				int_CurrentMatchNumber = 0;

				threeBytesInt16Hash_CurrentObj = arrayList_HashesList[ushort_CalculatedHashCode];
		
				int int_LastBestMatchPosition = 0;

				for(; int_CurrentMatchNumber != threeBytesInt16Hash_CurrentObj.Count; int_CurrentMatchNumber++)
				{
                    int_CurrentMatchLength = ComputeLengthForPossibleMatch(ref byteArray_DataToCompress, int_CurrentPositionInData, threeBytesInt16Hash_CurrentObj[int_CurrentMatchNumber]);
				
					if(int_CurrentMatchLength > intArray_FoundedMatchInfo[0])
					{
						intArray_FoundedMatchInfo[0] = int_CurrentMatchLength;
						intArray_FoundedMatchInfo[1] = int_CurrentMatchNumber;

						int_LastBestMatchPosition = threeBytesInt16Hash_CurrentObj[int_CurrentMatchNumber];
					}

					if(int_CurrentMatchLength == intArray_FoundedMatchInfo[0] 
						&& threeBytesInt16Hash_CurrentObj[int_CurrentMatchNumber] > int_LastBestMatchPosition
						&& int_CurrentPositionInData - int_LastBestMatchPosition > 3
						)
					{
						intArray_FoundedMatchInfo[0] = int_CurrentMatchLength;
						intArray_FoundedMatchInfo[1] = int_CurrentMatchNumber;

						int_LastBestMatchPosition = threeBytesInt16Hash_CurrentObj[int_CurrentMatchNumber];
					}
				}

				if(int_CurrentPositionInData - threeBytesInt16Hash_CurrentObj[intArray_FoundedMatchInfo[1]] == 3)
				{
					intArray_FoundedMatchInfo[0] = 0;
					intArray_FoundedMatchInfo[1] = 0;
				}

				return intArray_FoundedMatchInfo;
			}

            internal unsafe int[] CalculateRLEBytesCount(ref byte[] byteArray_DataToCompress, int int_CurrentPositionInData)
			{
				intArray_RLEBytesCountInfo[0] = intArray_RLEBytesCountInfo[1] = int_RLEBytesCount = 1; // For Lazy Matching (0) (+1)

				while(true)
				{	
					if(int_CurrentPositionInData + int_RLEBytesCount >= byteArray_DataToCompress.Length) break;
			
					if(byteArray_DataToCompress[int_CurrentPositionInData] == byteArray_DataToCompress[int_CurrentPositionInData + int_RLEBytesCount])
						intArray_RLEBytesCountInfo[0]++;	

					else break;

					int_RLEBytesCount++;

					if(int_RLEBytesCount == 65537) break;								
				}

				int_CurrentPositionInData++;
				
				int_RLEBytesCount = 1;

				while(true)
				{	
					if(int_CurrentPositionInData + int_RLEBytesCount >= byteArray_DataToCompress.Length) break;
			
					if(byteArray_DataToCompress[int_CurrentPositionInData] == byteArray_DataToCompress[int_CurrentPositionInData + int_RLEBytesCount])
						intArray_RLEBytesCountInfo[1]++;

					else break;
			
					int_RLEBytesCount++;

					if(int_RLEBytesCount == 65537) break;	
				}

				return intArray_RLEBytesCountInfo;     
			}
            	
			#endregion

			BitArray bitArray_MetaData = null, bitArray_CurrentPrefixCodesCode = null;		

			MemoryStream memoryStream_SavedLiterals = null, memoryStream_CompressedBlock = null;

			PrefixCodes PrefixCodes_obj = null;			
        
			internal byte [] CompressDataBlock(byte [] byteArray_DataBlockToCompress, bool ToUseLazyMatching, bool ToUseRLE, int MaximumDataBlockSize)
			{	
				PrefixCodes_obj = new PrefixCodes(false);

				short short_LastFoundMatchesLength = 0;	

				byte [] byteArray_CompressedBlock = null;
			  				
				int int_StartPositionOfFirstFoundedMatch = 0, int_StartPositionOfSecondFoundedMatch = 0,
					int_CurrentPositionInBitArray = 0, int_PositionInDataBeforeCycle = 0, 
					int_DistanceToLastFoundedMatch = 0,	int_RLEBytesCount = 0;
     	
				int [] intArray_FirstFoundedMatchInfo = new int[2], 
					   intArray_SecondFoundedMatchInfo = new int[2];

				bitArray_MetaData = new BitArray(10000);
	
				memoryStream_SavedLiterals = new MemoryStream();
				memoryStream_CompressedBlock = new MemoryStream();

				memoryStream_CompressedBlock.Position = 1;
        
				InitHashesArrayList();

                #region StartUp initialization

                byte_CountOfBitsToPhraseLength = 2;
				short_MaximumPraseLength = 3;
				byte_CountOfBitsToPhrasePos = 2;
				int_MaximumDictionaryLength = 3;

                int int_CurrentPositionInData = 0;

                #endregion

				for(; int_CurrentPositionInData != byteArray_DataBlockToCompress.Length; int_CurrentPositionInData++) 
				{	
					#region Check for Dinamic increase maximum Dictionary and Phrase lengths need

                    if (int_CurrentPositionInData > int_MaximumDictionaryLength && int_CurrentPositionInData < 65535)
                    {
                        IncreaseDictionaryAndPhraseLength(int_CurrentPositionInData);
                    }

                    if (int_CurrentPositionInData > short_MaximumPraseLength && short_MaximumPraseLength < 255)
                    {
                        IncreaseDictionaryAndPhraseLength(int_CurrentPositionInData);
                    }
					#endregion

					#region Add all hashes of previous block of processed data

					for(; int_PositionInDataBeforeCycle != int_CurrentPositionInData; int_PositionInDataBeforeCycle++)
					{
                        AddNewInt16HashOfPossibleMatch(ref byteArray_DataBlockToCompress, ref int_PositionInDataBeforeCycle, ref int_MaximumDictionaryLength);
					}

					#endregion
					
					if(int_CurrentPositionInBitArray % 8 == 0)
					{
						bitArray_MetaData.Length = int_CurrentPositionInBitArray;

						byteArray_CompressedBlock = new byte[int_CurrentPositionInBitArray / 8];

						bitArray_MetaData.CopyTo(byteArray_CompressedBlock, 0);

						memoryStream_CompressedBlock.Write(byteArray_CompressedBlock, 0, byteArray_CompressedBlock.Length);

						bitArray_MetaData = new BitArray(10000);

						int_CurrentPositionInBitArray = 0;
					}

                    if (bitArray_MetaData.Length <= int_CurrentPositionInBitArray + 1000)
                    {
                        bitArray_MetaData.Length += 100000;
                    }

					#region Try coding using RLE 
				
					if(ToUseRLE == true)
					{
                        CalculateRLEBytesCount(ref byteArray_DataBlockToCompress, int_CurrentPositionInData);

						int_RLEBytesCount = intArray_RLEBytesCountInfo[0];

                        if (!FindInt16HashOfPossibleMatch(ref byteArray_DataBlockToCompress, ref int_CurrentPositionInData) 
							&& int_RLEBytesCount >= 2)
						{		
							bitArray_MetaData[int_CurrentPositionInBitArray++] = true;
							bitArray_MetaData[int_CurrentPositionInBitArray++] = true;

							int_RLEBytesCount -= 2;
			
							memoryStream_SavedLiterals.WriteByte(byteArray_DataBlockToCompress[int_CurrentPositionInData]);

							bitArray_CurrentPrefixCodesCode = (BitArray)PrefixCodesSupportForDistancesAndRLE.arrayList_MapOfPrefixCodes[int_RLEBytesCount];
							foreach(bool bool_CurrentPrefixCodesBit in bitArray_CurrentPrefixCodesCode)
							{
								bitArray_MetaData[int_CurrentPositionInBitArray++] = bool_CurrentPrefixCodesBit;
							}

							int_CurrentPositionInData += int_RLEBytesCount + 1;
		
							continue;				
						}					
					}
		
					#endregion	

                    if (FindInt16HashOfPossibleMatch(ref byteArray_DataBlockToCompress, ref int_CurrentPositionInData))
					{		
						#region Try coding using RLE 

						if(ToUseRLE == true && int_RLEBytesCount > short_MaximumPraseLength)
						{
							bitArray_MetaData[int_CurrentPositionInBitArray++] = true;
							bitArray_MetaData[int_CurrentPositionInBitArray++] = true;
		
							int_RLEBytesCount -= 2;
			
							memoryStream_SavedLiterals.WriteByte(byteArray_DataBlockToCompress[int_CurrentPositionInData]);
							
							bitArray_CurrentPrefixCodesCode = (BitArray)PrefixCodesSupportForDistancesAndRLE.arrayList_MapOfPrefixCodes[int_RLEBytesCount];
							foreach(bool bool_CurrentPrefixCodesBit in bitArray_CurrentPrefixCodesCode)
							{
								bitArray_MetaData[int_CurrentPositionInBitArray++] = bool_CurrentPrefixCodesBit;
							}

							int_CurrentPositionInData += int_RLEBytesCount + 1;
		
							continue;	
						}

						#endregion									

						#region Lazy Matching Implementation

                        intArray_FirstFoundedMatchInfo = FindBestMatch(ref byteArray_DataBlockToCompress, ref int_CurrentPositionInData);

						int_StartPositionOfFirstFoundedMatch = threeBytesInt16Hash_CurrentObj[intArray_FirstFoundedMatchInfo[1]];

						short_LastFoundMatchesLength = (short)intArray_FirstFoundedMatchInfo[0];

						if(short_LastFoundMatchesLength < 3)
						{
							bitArray_MetaData[int_CurrentPositionInBitArray++] = false;
				
							memoryStream_SavedLiterals.WriteByte(byteArray_DataBlockToCompress[int_CurrentPositionInData]);	

							continue;
						}

						if(ToUseRLE == true && ToUseLazyMatching == false && int_RLEBytesCount >= 2 
						&& intArray_FirstFoundedMatchInfo[0] < int_RLEBytesCount)
						{
							#region Code using RLE 

							bitArray_MetaData[int_CurrentPositionInBitArray++] = true;
							bitArray_MetaData[int_CurrentPositionInBitArray++] = true;
	
							int_RLEBytesCount -= 2;
							
							memoryStream_SavedLiterals.WriteByte(byteArray_DataBlockToCompress[int_CurrentPositionInData]);
									
							bitArray_CurrentPrefixCodesCode = (BitArray)PrefixCodesSupportForDistancesAndRLE.arrayList_MapOfPrefixCodes[int_RLEBytesCount];
							foreach(bool bool_CurrentPrefixCodesBit in bitArray_CurrentPrefixCodesCode)
							{
								bitArray_MetaData[int_CurrentPositionInBitArray++] = bool_CurrentPrefixCodesBit;
							}

							int_CurrentPositionInData += int_RLEBytesCount + 1;

							continue;					

							#endregion		
						}
                        int_CurrentPositionInData++;
                        if (ToUseLazyMatching && FindInt16HashOfPossibleMatch(ref byteArray_DataBlockToCompress, ref int_CurrentPositionInData))
                        {                           
                            intArray_SecondFoundedMatchInfo = FindBestMatch(ref byteArray_DataBlockToCompress, ref int_CurrentPositionInData);

                            int_CurrentPositionInData--;

                            if (intArray_SecondFoundedMatchInfo[0] > intArray_FirstFoundedMatchInfo[0]
                                && intArray_SecondFoundedMatchInfo[0] > 3)
                            {
                                #region Try coding using RLE

                                int_RLEBytesCount = intArray_RLEBytesCountInfo[1];

                                if (ToUseRLE == true && intArray_SecondFoundedMatchInfo[0] < int_RLEBytesCount)
                                {
                                    if (int_RLEBytesCount > intArray_RLEBytesCountInfo[0])
                                    {
                                        bitArray_MetaData[int_CurrentPositionInBitArray++] = false;

                                        memoryStream_SavedLiterals.WriteByte(byteArray_DataBlockToCompress[int_CurrentPositionInData]);

                                        int_CurrentPositionInData++;
                                    }

                                    else int_RLEBytesCount = intArray_RLEBytesCountInfo[0];


                                    bitArray_MetaData[int_CurrentPositionInBitArray++] = true;
                                    bitArray_MetaData[int_CurrentPositionInBitArray++] = true;

                                    int_RLEBytesCount -= 2;

                                    memoryStream_SavedLiterals.WriteByte(byteArray_DataBlockToCompress[int_CurrentPositionInData]);

                                    bitArray_CurrentPrefixCodesCode = (BitArray)PrefixCodesSupportForDistancesAndRLE.arrayList_MapOfPrefixCodes[int_RLEBytesCount];
                                    foreach (bool bool_CurrentPrefixCodesBit in bitArray_CurrentPrefixCodesCode)
                                    {
                                        bitArray_MetaData[int_CurrentPositionInBitArray++] = bool_CurrentPrefixCodesBit;
                                    }

                                    int_CurrentPositionInData += int_RLEBytesCount + 1;

                                    continue;
                                }


                                #endregion

                                int_StartPositionOfFirstFoundedMatch = threeBytesInt16Hash_CurrentObj[intArray_SecondFoundedMatchInfo[1]];

                                short_LastFoundMatchesLength = (short)intArray_SecondFoundedMatchInfo[0];

                                bitArray_MetaData[int_CurrentPositionInBitArray++] = false;

                                memoryStream_SavedLiterals.WriteByte(byteArray_DataBlockToCompress[int_CurrentPositionInData]);

                                int_CurrentPositionInData++;

                                #region Check for Dinamic increase maximum Dictionary and Phrase lengths need

                                if (int_CurrentPositionInData > int_MaximumDictionaryLength && int_CurrentPositionInData < 65535)
                                    IncreaseDictionaryAndPhraseLength(int_CurrentPositionInData);

                                if (int_CurrentPositionInData > short_MaximumPraseLength && short_MaximumPraseLength < 255)
                                    IncreaseDictionaryAndPhraseLength(int_CurrentPositionInData);

                                #endregion

                            }
                        }
                        else int_CurrentPositionInData--;

						#endregion 				

						#region Write literal and start new cycle IF founded phrase outside of dictionary of phrase size < 3

						if(int_CurrentPositionInData - int_StartPositionOfFirstFoundedMatch >= int_MaximumDictionaryLength
							|| short_LastFoundMatchesLength < 3)
						{
							if(int_CurrentPositionInData >= byteArray_DataBlockToCompress.Length) break;

							bitArray_MetaData[int_CurrentPositionInBitArray++] = false;

							memoryStream_SavedLiterals.WriteByte(byteArray_DataBlockToCompress[int_CurrentPositionInData]);	

							continue;
						}

						#endregion

						if(int_CurrentPositionInData >= byteArray_DataBlockToCompress.Length) break;

						#region Write distance and length info to BitArray

						int_StartPositionOfSecondFoundedMatch = int_CurrentPositionInData;
						int_CurrentPositionInData += short_LastFoundMatchesLength - 1;
                        
						bitArray_MetaData[int_CurrentPositionInBitArray++] = true;
                        
                        if (ToUseRLE == true)
                        {
                            bitArray_MetaData[int_CurrentPositionInBitArray++] = false;
                        }
	
						int_DistanceToLastFoundedMatch = int_StartPositionOfSecondFoundedMatch - int_StartPositionOfFirstFoundedMatch;

						#region Write LZSS Distance
                       
						bitArray_CurrentPrefixCodesCode = (BitArray)PrefixCodesSupportForDistancesAndRLE.arrayList_MapOfPrefixCodes[int_DistanceToLastFoundedMatch-4];
						
						if(bitArray_CurrentPrefixCodesCode.Length >= byte_CountOfBitsToPhrasePos)
                        {
							bitArray_MetaData[int_CurrentPositionInBitArray++] = false;

							commonEnvironment_obj.WriteDecimalNumberToBitArray(ref bitArray_MetaData, int_CurrentPositionInBitArray, 
							                                                   byte_CountOfBitsToPhrasePos, int_DistanceToLastFoundedMatch-4);
                        
                            int_CurrentPositionInBitArray += byte_CountOfBitsToPhrasePos;
						}
						
                        else
                        {                            
							bitArray_MetaData[int_CurrentPositionInBitArray++] = true;

							foreach(bool bool_CurrentPrefixCodesBit in bitArray_CurrentPrefixCodesCode)
							{
								bitArray_MetaData[int_CurrentPositionInBitArray++] = bool_CurrentPrefixCodesBit;
							}
						}                        
                        
						#endregion
					
						#region Write LZSS Length 

						if(int_StartPositionOfSecondFoundedMatch - int_StartPositionOfFirstFoundedMatch == 4)
						{
                            if (short_LastFoundMatchesLength == 3)
                            {
                                bitArray_MetaData[int_CurrentPositionInBitArray++] = true;
                            }
                            else
                            {
                                bitArray_MetaData[int_CurrentPositionInBitArray++] = false;
                            }

							continue;
						}		
						
						short_LastFoundMatchesLength -= 3;

						bitArray_CurrentPrefixCodesCode = (BitArray)PrefixCodesSupportForLZSSLengths.arrayList_MapOfPrefixCodes[short_LastFoundMatchesLength];
						
						foreach(bool bool_CurrentPrefixCodesBit in bitArray_CurrentPrefixCodesCode)
						{
							bitArray_MetaData[int_CurrentPositionInBitArray++] = bool_CurrentPrefixCodesBit;
						}			

						#endregion
					
						#endregion
				
						continue;
					}        

                    #region Write literal if phrase not found

                    {                        
					    bitArray_MetaData[int_CurrentPositionInBitArray++] = false;
    					
					    memoryStream_SavedLiterals.WriteByte(byteArray_DataBlockToCompress[int_CurrentPositionInData]);	
				    }

				    #endregion				
                } 

				#region Variables Declaration
						
				byte [] byteArray_MetaData = null, byteArray_CompressedLiterals = null,
						byteArray_DataBlockCompressedByStaticPrefixCodes = null,
						byteArray_CompressedDataBlock = null;							
			
				#endregion

				#region Write unuseds bits count

				bitArray_MetaData.Length = int_CurrentPositionInBitArray;

				new CommonEnvironment().AddUnusedsBitsCountInfo(bitArray_MetaData, memoryStream_CompressedBlock);

				byteArray_MetaData = new byte[memoryStream_CompressedBlock.ToArray().Length];

				memoryStream_CompressedBlock.Position = 0;

				memoryStream_CompressedBlock.Read(byteArray_MetaData, 0, byteArray_MetaData.Length);

				memoryStream_CompressedBlock.SetLength(0);

				#endregion

				int int_StaticPrefixCodesCompressedLiteralsSize = 0;
				int int_StaticPrefixCodesCompressedDataBlockSize = 0;
                
              
				
                if(this.UsePrefixCodesCompression == true) // Avarage 50-60 ms per call!!!
				{
					PrefixCodes_obj = new PrefixCodes(false);
		
					int_StaticPrefixCodesCompressedDataBlockSize = PrefixCodes_obj.DataAnalyzer(byteArray_DataBlockToCompress, false);
					int_StaticPrefixCodesCompressedLiteralsSize = PrefixCodes_obj.DataAnalyzer(memoryStream_SavedLiterals.ToArray(), false);
				}
				
				#region Compress block ONLY by static PrefixCodes or store full block uncompresed

				if(byteArray_MetaData.Length + int_StaticPrefixCodesCompressedLiteralsSize + 14 > byteArray_DataBlockToCompress.Length
				&& byteArray_MetaData.Length + memoryStream_SavedLiterals.ToArray().Length + 14 > byteArray_DataBlockToCompress.Length
				&& int_StaticPrefixCodesCompressedDataBlockSize > byteArray_DataBlockToCompress.Length && this.UsePrefixCodesCompression == false)
				{	
					memoryStream_CompressedBlock.SetLength(0);

					memoryStream_CompressedBlock.WriteByte(0); //Algorithm ID (1 byte) - 0 is Uncompressed

					memoryStream_CompressedBlock.Write(BitConverter.GetBytes(byteArray_DataBlockToCompress.Length), 0, 4);

					memoryStream_CompressedBlock.Write(byteArray_DataBlockToCompress, 0, byteArray_DataBlockToCompress.Length);
	
					byteArray_CompressedDataBlock = memoryStream_CompressedBlock.ToArray();

					memoryStream_CompressedBlock.Close();
					memoryStream_SavedLiterals.Close();

					return byteArray_CompressedDataBlock;
				}

				if(byteArray_MetaData.Length + int_StaticPrefixCodesCompressedLiteralsSize + 14 > int_StaticPrefixCodesCompressedDataBlockSize
				&& byteArray_MetaData.Length + memoryStream_SavedLiterals.ToArray().Length + 14 > int_StaticPrefixCodesCompressedDataBlockSize
				&& this.UsePrefixCodesCompression == true)
				{	
					byteArray_DataBlockCompressedByStaticPrefixCodes = PrefixCodes_obj.Compress(byteArray_DataBlockToCompress, false);

					memoryStream_CompressedBlock.SetLength(0);	
		
					memoryStream_CompressedBlock.WriteByte(1); //Algorithm ID (1 byte) - 1 is Static PrefixCodes

					memoryStream_CompressedBlock.Write(BitConverter.GetBytes(byteArray_DataBlockCompressedByStaticPrefixCodes.Length), 0, 4);

					memoryStream_CompressedBlock.Write(byteArray_DataBlockCompressedByStaticPrefixCodes, 0, byteArray_DataBlockCompressedByStaticPrefixCodes.Length);
			
					byteArray_CompressedDataBlock = memoryStream_CompressedBlock.ToArray();

					memoryStream_CompressedBlock.Close();
					memoryStream_SavedLiterals.Close();

					return byteArray_CompressedDataBlock;
				}

				#endregion

				memoryStream_CompressedBlock.WriteByte(2); //Algorithm ID (1 byte) - 2 is LZSS
			
				#region Post processing and Writing saved literals into Compressed memory Stream
             			
				if(int_StaticPrefixCodesCompressedLiteralsSize >= memoryStream_SavedLiterals.ToArray().Length
				|| this.UsePrefixCodesCompression == false)
				{
					memoryStream_CompressedBlock.WriteByte(0); // byte 0 is uncompressed literals

					memoryStream_CompressedBlock.Write(BitConverter.GetBytes(memoryStream_SavedLiterals.ToArray().Length), 0, 4);

					memoryStream_CompressedBlock.Write(memoryStream_SavedLiterals.ToArray(), 0, memoryStream_SavedLiterals.ToArray().Length);
				}
				else
				{	
					byteArray_CompressedLiterals = PrefixCodes_obj.CompressUsingNonAdaptivePrefixCodesMethod(memoryStream_SavedLiterals.ToArray());

					memoryStream_CompressedBlock.WriteByte(1); // byte 1 is static PrefixCodes compressed literals
					
					memoryStream_CompressedBlock.Write(BitConverter.GetBytes(byteArray_CompressedLiterals.Length), 0, 4);

					memoryStream_CompressedBlock.Write(byteArray_CompressedLiterals, 0, byteArray_CompressedLiterals.Length);
				} 

				#endregion
				
				#region Write Meta Data and Meta Data Size

				memoryStream_CompressedBlock.Write(BitConverter.GetBytes(byteArray_MetaData.Length), 0, 4);
						
				memoryStream_CompressedBlock.Write(byteArray_MetaData, 0, byteArray_MetaData.Length);

				#endregion				
                
				byteArray_CompressedDataBlock = memoryStream_CompressedBlock.ToArray();

				memoryStream_CompressedBlock.Close();
				memoryStream_SavedLiterals.Close();

				return byteArray_CompressedDataBlock;
			}


			/// <summary> 
			/// Compress input byte array using LZSS algorithm.
			/// </summary>
			/// 
			/// <returns> 
			/// An Compressed array of bytes with length > 0. 
			/// </returns>
			/// 
			/// <param name="DataToCompress">
			/// The input data to compress using LZSS algorithm.
			/// </param>/ 	 
			/// 	
			/// <param name="AddCheckSum">
			/// Indicating whether add to compressed data MD5 Hash check sum.
			/// </param>
			/// 
			/// <example> This sample shows how to compress byte array.
			/// <code>
			/// //Initializes a new instance of the LZSS class with a compression parameters: 
			/// //10 hash chains, use PrefixCodes, not use RLE and maximum data block up to 131072 bytes
			/// JurikSoft.Compression.ICompression compressionObj = 
			/// new JurikSoft.Compression.LZSS(10, true, true, false, 131072);
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
                if (DataToCompress == null)
                {
                    throw new CommonEnvironment.CompressedDataArrayIsNullReferenceException();
                }

                if (DataToCompress.Length == 0)
                {
                    throw new CommonEnvironment.CompressedDataHasZeroLengthException();
                }

				StartUpInitialization();
			
				MemoryStream memoryStream_CompressedData = new MemoryStream();

				UInt32 uInt32_DataBlocksCount = 0;

				

				BitArray bitArray_AlgorithmParameters = new BitArray(8);
								
				byte [] byteArray_DataBlockToCompress = null, byteArray_CompressedDataBlock = null,
						byteArray_HashOfDecompressedData = null, byteArray_CompressedData = null;

				uInt32_DataBlocksCount = (uint)(DataToCompress.Length / MaximumDataBlockSize);

				if((double)DataToCompress.Length / (double)MaximumDataBlockSize > (double)uInt32_DataBlocksCount) uInt32_DataBlocksCount++;

				int [] intArray_SizesOfBlocks = new int[uInt32_DataBlocksCount];

				memoryStream_CompressedData.Position = 45;
				
				#region Write Total Decompressed Size

				memoryStream_CompressedData.Write(BitConverter.GetBytes((UInt64)DataToCompress.LongLength), 0, 8);
				
				#endregion

				#region Write Hash Of Decompressed Data

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

				#region Write Data Algorithm parameters
				
				byte [] byteArray_AlgorithmParameters = new byte[2];				 

				bitArray_AlgorithmParameters[0] = ToUseLazyMatching;
				bitArray_AlgorithmParameters[1] = ToUseRLE;

				bitArray_AlgorithmParameters.CopyTo(byteArray_AlgorithmParameters, 0);

				memoryStream_CompressedData.Write(byteArray_AlgorithmParameters, 0, 2);
				
				#endregion	
				
				#region Write Data blocks count

				memoryStream_CompressedData.Write(BitConverter.GetBytes(uInt32_DataBlocksCount), 0, 4);
				
				#endregion	

				#region Compress by blocks

				for(int int_CycleCount = 0; DataToCompress.Length != int_CurrentBlockPosition; int_CycleCount++)
				{
					if(DataToCompress.Length > int_CurrentBlockPosition + MaximumDataBlockSize)
					{
						byteArray_DataBlockToCompress = commonEnvironment_obj.GetByteArrayPart(DataToCompress, int_CurrentBlockPosition, MaximumDataBlockSize);
						int_CurrentBlockPosition += MaximumDataBlockSize;
					}

					else 
					{
						byteArray_DataBlockToCompress = commonEnvironment_obj.GetByteArrayPart(DataToCompress, int_CurrentBlockPosition, DataToCompress.Length - int_CurrentBlockPosition);
						int_CurrentBlockPosition = DataToCompress.Length;
					}

					byteArray_CompressedDataBlock = CompressDataBlock(byteArray_DataBlockToCompress, ToUseLazyMatching, ToUseRLE, MaximumDataBlockSize);			
			
					memoryStream_CompressedData.Write(BitConverter.GetBytes(byteArray_CompressedDataBlock.Length), 0, 4);
				
					memoryStream_CompressedData.Write(byteArray_CompressedDataBlock, 0, byteArray_CompressedDataBlock.Length);
				}

				#endregion		

				byteArray_CompressedData = memoryStream_CompressedData.ToArray();

				memoryStream_CompressedData.Close();
			
				commonEnvironment_obj.AddSystemInformation(ref byteArray_CompressedData, 1);

				return byteArray_CompressedData;
		
			}		
            	
			internal byte [] DecompressDataBlock(byte [] byteArray_DataBlockToDecompress, bool bool_ToUseRLE)
			{
				PrefixCodes_obj = new PrefixCodes(false);

				MemoryStream memoryStream_DecompressedBlock = new MemoryStream(),
							 memoryStream_CompressedBlock = new MemoryStream(byteArray_DataBlockToDecompress);
				
				int int_CurrentBitPosition = 0, int_CurrentPositionInMemoryStream = 0,
					int_NewPhrasePosition = 0, int_NewPraseLength = 0, int_CurrentLiteralPosition = 0,
					int_RLEBytesCount = 0, int_LiteralsBlockSize = 0, int_MetaDataBlockSize = 0;

				byte byte_UnusedBitsCount = 0, byte_StoredLiteral = 0, byte_AlgorithmID = 0,
					 byte_LiteralsFormat = 0; 
	
				byte [] byteArray_NewPrase = null, byteArray_LiteralsBlock = null, byteArray_MetaData = null;
	
				byte_AlgorithmID = (byte)memoryStream_CompressedBlock.ReadByte();

				if(byte_AlgorithmID == 0)
				{
					return commonEnvironment_obj.GetByteArrayPart(byteArray_DataBlockToDecompress, 5, byteArray_DataBlockToDecompress.Length - 5);
				}

				if(byte_AlgorithmID == 1)
				{
					return commonEnvironment_obj.Decompress(commonEnvironment_obj.GetByteArrayPart(byteArray_DataBlockToDecompress, 5, byteArray_DataBlockToDecompress.Length - 5), false);
				}

				byte_LiteralsFormat = (byte)memoryStream_CompressedBlock.ReadByte();
		
				int_LiteralsBlockSize = BitConverter.ToInt32(byteArray_DataBlockToDecompress, 2);
				memoryStream_CompressedBlock.Position += 4;

				byteArray_LiteralsBlock = new byte[int_LiteralsBlockSize];

				memoryStream_CompressedBlock.Read(byteArray_LiteralsBlock, 0, byteArray_LiteralsBlock.Length);

                if (byte_LiteralsFormat == 1)
                {
                    byteArray_LiteralsBlock = PrefixCodes_obj.DecompressUsingNonAdaptivePrefixCodesMethod(byteArray_LiteralsBlock);
                }

				byte [] byteArray_MetaDataLength = new byte[4];
				memoryStream_CompressedBlock.Read(byteArray_MetaDataLength, 0, byteArray_MetaDataLength.Length);

				int_MetaDataBlockSize = BitConverter.ToInt32(byteArray_MetaDataLength, 0);
		
				byte_UnusedBitsCount = (byte)memoryStream_CompressedBlock.ReadByte();


				byteArray_MetaData = new byte[int_MetaDataBlockSize-1];
				memoryStream_CompressedBlock.Read(byteArray_MetaData, 0, byteArray_MetaData.Length);
				

				BitArray bitArray_MetaData = new BitArray(byteArray_MetaData);
			
				byte_CountOfBitsToPhraseLength = 2;
				short_MaximumPraseLength = 3;
				byte_CountOfBitsToPhrasePos = 2;
				int_MaximumDictionaryLength = 3;

				bitArray_MetaData.Length -= byte_UnusedBitsCount;		

				for(; int_CurrentBitPosition != bitArray_MetaData.Length; )
				{
					#region Dinamic increase maximum Dictionary and Phrase lengths
			
					if(memoryStream_DecompressedBlock.Position > int_MaximumDictionaryLength && memoryStream_DecompressedBlock.Position < 65535)
						IncreaseDictionaryAndPhraseLength((int)memoryStream_DecompressedBlock.Position);
						
					if(memoryStream_DecompressedBlock.Position > short_MaximumPraseLength && short_MaximumPraseLength < 255)
						IncreaseDictionaryAndPhraseLength((int)memoryStream_DecompressedBlock.Position);
			
					#endregion

                    if (bitArray_MetaData[int_CurrentBitPosition++] == true)
                    {
                        if (bool_ToUseRLE == true)
                            if (bitArray_MetaData[int_CurrentBitPosition++] == true) //Is RLE sequence
                            {
                                byte_StoredLiteral = byteArray_LiteralsBlock[int_CurrentLiteralPosition++];

                                PrefixCodesSupportForDistancesAndRLE.ConvertPrefixCodesCodeToDecimal(ref bitArray_MetaData, int_CurrentBitPosition);

                                int_RLEBytesCount = PrefixCodesSupportForDistancesAndRLE.DecodedPrefixCodesCode[0];
                                int_CurrentBitPosition = PrefixCodesSupportForDistancesAndRLE.DecodedPrefixCodesCode[1];

                                int_RLEBytesCount += 2;

                                for (; int_RLEBytesCount != 0; int_RLEBytesCount--)
                                {
                                    memoryStream_DecompressedBlock.WriteByte(byte_StoredLiteral);
                                }

                                continue;
                            }


                        // Is Distance-Length Pair

                        int_NewPraseLength = 0;
                        int_NewPhrasePosition = 0;

                        if (bitArray_MetaData[int_CurrentBitPosition++] == false)
                        {
                            int_NewPhrasePosition = commonEnvironment_obj.ReadDecimalNumberFromBitArray(ref bitArray_MetaData, int_CurrentBitPosition, byte_CountOfBitsToPhrasePos);
                            int_CurrentBitPosition += byte_CountOfBitsToPhrasePos;
                        }
                        else
                        {
                            PrefixCodesSupportForDistancesAndRLE.ConvertPrefixCodesCodeToDecimal(ref bitArray_MetaData, int_CurrentBitPosition);

                            int_NewPhrasePosition = PrefixCodesSupportForDistancesAndRLE.DecodedPrefixCodesCode[0];
                            int_CurrentBitPosition = PrefixCodesSupportForDistancesAndRLE.DecodedPrefixCodesCode[1];
                        }

                        int_NewPhrasePosition += 4;

                        if (int_NewPhrasePosition == 4)
                        {
                            if (bitArray_MetaData[int_CurrentBitPosition] == true)
                            {
                                int_NewPraseLength = 3;
                            }
                            else
                            {
                                int_NewPraseLength = 4;
                            }

                            int_CurrentBitPosition++;

                            byteArray_NewPrase = new byte[int_NewPraseLength];
                        }

                        if (int_NewPhrasePosition > 4)
                        {
                            PrefixCodesSupportForLZSSLengths.ConvertPrefixCodesCodeToDecimal(ref bitArray_MetaData, int_CurrentBitPosition);

                            int_NewPraseLength = PrefixCodesSupportForLZSSLengths.DecodedPrefixCodesCode[0];
                            int_CurrentBitPosition = PrefixCodesSupportForLZSSLengths.DecodedPrefixCodesCode[1];

                            int_NewPraseLength += 3;

                            byteArray_NewPrase = new byte[int_NewPraseLength];
                        }

                        // Copy bytes with readed length from readed distance 

                        int_CurrentPositionInMemoryStream = (int)memoryStream_DecompressedBlock.Position;

                        memoryStream_DecompressedBlock.Position -= int_NewPhrasePosition;

                        memoryStream_DecompressedBlock.Read(byteArray_NewPrase, 0, byteArray_NewPrase.Length);

                        memoryStream_DecompressedBlock.Position = int_CurrentPositionInMemoryStream;

                        memoryStream_DecompressedBlock.Write(byteArray_NewPrase, 0, byteArray_NewPrase.Length);
                    }

                    else
                    {
                        memoryStream_DecompressedBlock.WriteByte(byteArray_LiteralsBlock[int_CurrentLiteralPosition++]);
                    }
				}

				return memoryStream_DecompressedBlock.ToArray();
			}
            	
			internal byte [] Decompress(byte [] DataToDecompress, bool VerifyCheckSum)
			{					  
				MemoryStream memoryStream_DecompressedData = new MemoryStream(),
							 memoryStream_CompressedData = new MemoryStream(DataToDecompress);

				UInt64 uInt64_StoredTotalDecompressedSize = 0, uInt64_ComputedTotalDecompressedSize;

				UInt32 uInt32_DataBlocksCount = 0;

				MD5CryptoServiceProvider md5CryptoServiceProvider_HashOfDecompressedData = null;

				BitArray bitArray_AlgorithmParameters;

				byte [] byteArray_StoredHashOfDecompressedData = new byte[16],
						byteArray_ComputedHashOfDecompressedData = new byte[16],
						byteArray_AlgorithmParameters = new byte[2],
						byteArray_DataBlocksCount = new byte[4],
						byteArray_CurrentBlockSize = new byte[4],
						byteArray_DecompressedDataBlock = null;

				bool bool_ToUseRLE = false, bool_ToUseLazyMatching = false;

				byte byte_IsCheckSumExist = 1;

				int int_CurrentDataBlockSize = 0;


				uInt64_StoredTotalDecompressedSize = BitConverter.ToUInt64(memoryStream_CompressedData.ToArray(), 0);

				memoryStream_CompressedData.Position += 8;

				byte_IsCheckSumExist = (byte)memoryStream_CompressedData.ReadByte();

				if(byte_IsCheckSumExist == 1)
				{
					memoryStream_CompressedData.Read(byteArray_StoredHashOfDecompressedData, 0, byteArray_StoredHashOfDecompressedData.Length);
				}

				memoryStream_CompressedData.Read(byteArray_AlgorithmParameters, 0, byteArray_AlgorithmParameters.Length);
				
				bitArray_AlgorithmParameters = new BitArray(byteArray_AlgorithmParameters);

				bool_ToUseLazyMatching = bitArray_AlgorithmParameters[0];
				bool_ToUseRLE = bitArray_AlgorithmParameters[1];

				memoryStream_CompressedData.Read(byteArray_DataBlocksCount, 0, byteArray_DataBlocksCount.Length);
				
				uInt32_DataBlocksCount = BitConverter.ToUInt32(byteArray_DataBlocksCount, 0);

				for(int int_CycleCount = 0; int_CycleCount != uInt32_DataBlocksCount; int_CycleCount++)
				{
					int_CurrentDataBlockSize = BitConverter.ToInt32(memoryStream_CompressedData.ToArray(), (int)memoryStream_CompressedData.Position);

					memoryStream_CompressedData.Position += 4;

					byteArray_DecompressedDataBlock = DecompressDataBlock( commonEnvironment_obj.GetByteArrayPart(DataToDecompress, (int)memoryStream_CompressedData.Position, int_CurrentDataBlockSize), bool_ToUseRLE );
                    
					memoryStream_CompressedData.Position += int_CurrentDataBlockSize;

					memoryStream_DecompressedData.Write(byteArray_DecompressedDataBlock, 0, byteArray_DecompressedDataBlock.Length);
				}


				uInt64_ComputedTotalDecompressedSize = (ulong)memoryStream_DecompressedData.ToArray().Length;
                
				if(uInt64_StoredTotalDecompressedSize != uInt64_ComputedTotalDecompressedSize)
					throw new CommonEnvironment.WrongDecompressedSizeException();
			
				#region Verification to right hash

				if(byte_IsCheckSumExist == 1 && VerifyCheckSum == true)
				{
					md5CryptoServiceProvider_HashOfDecompressedData = new MD5CryptoServiceProvider();
			
					byteArray_ComputedHashOfDecompressedData = md5CryptoServiceProvider_HashOfDecompressedData.ComputeHash(memoryStream_DecompressedData.ToArray(), 0, (int)memoryStream_DecompressedData.Position);
									
					if(commonEnvironment_obj.IsBytesArraysEquals(ref byteArray_ComputedHashOfDecompressedData, ref byteArray_StoredHashOfDecompressedData) == false)
					throw new CommonEnvironment.WrongDecompressedDataHashException();				
				}

				#endregion
			
				return memoryStream_DecompressedData.ToArray();
			}

		}
	}
}

