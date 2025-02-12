using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GammaCorrection
{
    unsafe class AsmInterface
    {
        [DllImport(@"C:\Work\JA\Projekt\GammaCorrection\x64\Debug\GamCorAsm.dll")]
        public static unsafe extern int gamma_correction(byte* imagePtr, int* lut, int posVal, int stopVal);

        [DllImport(@"C:\Work\JA\Projekt\GammaCorrection\x64\Debug\GamCorAsm.dll")]
        public static unsafe extern int gen_lut(float* gamma_value, float* lut);

       
        public static int[] GenerateLUTTable(double gammaValue)
        {
            unsafe
            {
                int[] luTable = new int[256];
                fixed (int* lut = luTable)
                {
                    float tmpGamma = (1.0f / (float)gammaValue);
                    float e;
                    for (int i = 0; i < luTable.Length; i++)
                    {
                        e = (float)((float)i / 255.0f);
                        gen_lut(&tmpGamma, &e);
                        if (e > 255)
                        {
                            e = 255;
                        }
                        if (((int)e) < 0)
                        {
                            e = 0;
                        }
                        lut[i] = (int)e;
                    }
                }
                return luTable;
            }
        }

        public static void PerformGammaCorrection(byte[] orginalImagePart, int[] luTable, int positionValue, int stopValue)
        {
            unsafe
            {
                fixed (byte* ptr = orginalImagePart)
                {
                    fixed (int* ptr2 = luTable)
                    {
                        gamma_correction(ptr,ptr2,positionValue,stopValue);
                    }
                }
            }
        }
    }
}
