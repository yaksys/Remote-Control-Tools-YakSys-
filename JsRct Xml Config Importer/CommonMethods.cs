using System;

namespace JurikSoft
{
    namespace XMLConfigImporer
    {
        class CommonMethods
        {
            public static bool IsBytesArraysEquals(byte[] byteArray_InitialData, byte[] byteArray_ComparedData)
            {
                if (byteArray_InitialData.Length != byteArray_ComparedData.Length) return false;

                for (int int_CycleCount = 0; int_CycleCount != byteArray_InitialData.Length; int_CycleCount++)
                {
                    if (byteArray_InitialData[int_CycleCount] != byteArray_ComparedData[int_CycleCount]) return false;
                }

                return true;
            }
        }
    }
}