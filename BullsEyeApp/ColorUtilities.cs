using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsEyeApp
{
    internal static class ColorUtilities
    {
        internal static char converColorToEnum(Color color)
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

        internal static Color convertEnumToColor(char colorEnum)
        {
            switch (colorEnum)
            {
                case (char)eColors.Pink:
                    return Color.Pink;
                case (char)eColors.Red:
                    return Color.Red;
                case (char)eColors.LightGreen:
                    return Color.LightGreen;
                case (char)eColors.LightBlue:
                    return Color.LightBlue;
                case (char)eColors.Blue:
                    return Color.Blue;
                case (char)eColors.Yellow:
                    return Color.Yellow;
                case (char)eColors.Brown:
                    return Color.Brown;
                case (char)eColors.White:
                    return Color.White;
                default:
                    throw new Exception("Unknown color enum.");
            }
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
