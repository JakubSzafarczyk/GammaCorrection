using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamCorCSharp
{
    public class GammaCorrection
    {
        public static byte[] GenerateLUTTable(double gamma)
        {
            byte[] lutTable = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                if ((255 * Math.Pow(i / 255.0, 1 / gamma)) > 255)
                {
                    lutTable[i] = 255;
                }
                else
                {
                    lutTable[i] = (byte)(255 * Math.Pow(i / 255.0, 1 / gamma));
                }
            }
            return lutTable;
        }

        public static void PerformGammaCorrection(byte[] orginalImagePart, int[] lutTable, int positionValue, int stopValue)
        {


            int w = positionValue;
            while (w < stopValue)
            {
                orginalImagePart[w] = (byte)lutTable[orginalImagePart[w]];
                w++;
            }
        }

        public static void PerformGammaCorrection2(byte[] orginalImagePart, int[] lutTable, int positionValue, int stopValue)
        {


            int w = positionValue;
            while (w < stopValue)
            {
                orginalImagePart[w] = (byte)lutTable[orginalImagePart[w]];
                w++;
            }
        }
    }
}
