using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetColor
{
    class ColorSpace
    {
        public enum Type
        {
            RGB,
            CMYK,
            HSV,
            HSL,
            HEX,
        }
        ColorSpaceType ColorType;
        
        public string ColorFormat(Color RGB) => ColorType.getColorFormat(RGB); 

        public ColorSpace(ColorSpaceType ColorType) => this.ColorType = ColorType;
 
    }

    interface ColorSpaceType
    {
        string getColorFormat(Color RGB);
    }

    #region RGB轉其他色彩空間
    class RGB : ColorSpaceType
    {
        public string getColorFormat(Color RGB)
        {
            return $"RGB=({RGB.R}, {RGB.B}, {RGB.G})";
        }
    }

    class CMYK : ColorSpaceType
    {
        public string getColorFormat(Color RGB)
        {
            var R = RGB.R / 255f;
            var G = RGB.G / 255f;
            var B = RGB.B / 255f;

            var K = 1f - Math.Max(Math.Max(R, G), B);
            if (K == 1F) return $"CMYK=({0}, {0}, {0}, {(int)Math.Round(K * 100)})";

            var C = (int)Math.Round(((1f - R - K) / (1f - K)) * 100);
            var M = (int)Math.Round(((1f - G - K) / (1f - K)) * 100);
            var Y = (int)Math.Round(((1f - B - K) / (1f - K)) * 100);
            var intK = (int)Math.Round(K * 100);

            return $"CMYK=({C}, {M}, {Y}, {intK})";
        }
    }

    class HSV : ColorSpaceType
    {
        public string getColorFormat(Color RGB)
        {
            var R = RGB.R / 255f;
            var G = RGB.G / 255f;
            var B = RGB.B / 255f;

            var Cmax = Math.Max(Math.Max(R, G), B);
            var Cmin = Math.Min(Math.Min(R, G), B);
            var delta = Cmax - Cmin;


            var H = 0f;
            if(delta == 0 )
                H = 0f;
            else if (Cmax == R)
                H = (((G - B) / delta) % 6f) * 60;
            else if (Cmax == G)
                H = (((B - R) / delta) + 2f) * 60;
            else if (Cmax == B)
                H = (((R - G) / delta) + 4f) * 60;
            H = (float)Math.Round(H);

            var S = 0f;
            if (Cmax != 0)
                S = (float)Math.Round(((delta / Cmax)*100),1);

            var V = (float)Math.Round(Cmax * 100,1);
            return $"HSV=({H:0}, {S:0.0}, {V:0.0})";
        }
    }

    class HSL : ColorSpaceType
    {
        public string getColorFormat(Color RGB)
        {
            var H = RGB.GetHue();
            var S = RGB.GetSaturation();
            var L = RGB.GetBrightness();

            return $"HSL=({H:0}, {S:0.0}, {L:0.0})";
        }
    }

    class HEX : ColorSpaceType
    {
        public string getColorFormat(Color RGB)
        {
            return $"HEX={ColorTranslator.ToHtml(RGB)}";
        }
    } 
    #endregion
}
