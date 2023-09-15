using System;
using System.Drawing;

namespace BullsEyeApp
{
    internal static class ColorUtilities
    {
        internal static char ConvertColorToEnum(Color color)
        {
            char enumColorChar;

            switch (color.Name)
            {
                case nameof(Color.Pink):
                    enumColorChar = (char)eColors.Pink;
                    break;
                case nameof(Color.Red):
                    enumColorChar = (char)eColors.Red;
                    break;
                case nameof(Color.LightGreen):
                    enumColorChar = (char)eColors.LightGreen;
                    break;
                case nameof(Color.LightBlue):
                    enumColorChar = (char)eColors.LightBlue;
                    break;
                case nameof(Color.Blue):
                    enumColorChar = (char)eColors.Blue;
                    break;
                case nameof(Color.Yellow):
                    enumColorChar = (char)eColors.Yellow;
                    break;
                case nameof(Color.Brown):
                    enumColorChar = (char)eColors.Brown;
                    break;
                case nameof(Color.White):
                    enumColorChar = (char)eColors.White;
                    break;
                default:
                    throw new Exception("Unknown color.");
            }

            return enumColorChar;
        }

        internal static Color ConvertEnumToColor(char colorEnum)
        {
            Color eNumColor;

            switch (colorEnum)
            {
                case (char)eColors.Pink:
                    eNumColor =  Color.Pink;
                    break;
                case (char)eColors.Red:
                    eNumColor = Color.Red;
                    break;
                case (char)eColors.LightGreen:
                    eNumColor = Color.LightGreen;
                    break;
                case (char)eColors.LightBlue:
                    eNumColor = Color.LightBlue;
                    break;
                case (char)eColors.Blue:
                    eNumColor = Color.Blue;
                    break;
                case (char)eColors.Yellow:
                    eNumColor = Color.Yellow;
                    break;
                case (char)eColors.Brown:
                    eNumColor = Color.Brown;
                    break;
                case (char)eColors.White:
                    eNumColor = Color.White;
                    break;
                default:
                    throw new Exception("Unknown color enum.");
            }

            return eNumColor;
        }

        enum eColors
        {
            Pink = 'A',
            Red = 'B',
            LightGreen = 'C',
            LightBlue = 'D',
            Blue = 'E',
            Yellow = 'F',
            Brown = 'G',
            White = 'H'
        }
    }
}
