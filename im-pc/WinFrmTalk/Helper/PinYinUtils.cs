using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class PinYinUtils
{
    public static long GetIntSpellCode(string CnChar)
    {
        if (UIUtils.IsNull(CnChar))
        {
            return 0;
        }

        CnChar = CnChar.TrimStart();
        if (UIUtils.IsNull(CnChar))
        {
            return 0;
        }
        long iCnChar;

        byte[] ZW = Encoding.Default.GetBytes(CnChar);

        //如果是字母，则直接返回
        if (ZW.Length == CnChar.Length)
        {
            iCnChar = ZW[0];
        }
        else
        {
            int i1 = (short)(ZW[0]);
            int i2 = (short)(ZW[1]);
            iCnChar = i1 * 256 + i2;
        }

        return iCnChar;
    }
    /// <summary>
    /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母
    /// </summary>
    /// <param name="CnChar">单个汉字</param>
    /// <returns>单个大写字母</returns>

    public static string GetCharSpellCode(string CnChar)
    {
        long iCnChar;
        CnChar = CnChar.TrimStart();
        byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

        //如果是字母，则直接返回

        if (ZW.Length == CnChar.Length)
        {
            return CnChar.Substring(0, 1).ToUpper();
        }
        else
        {
            // get the array of byte from the single char
            int i1 = (short)(ZW[0]);
            int i2 = (short)(ZW[1]);
            iCnChar = i1 * 256 + i2;
        }

        // iCnChar match the constant

        if ((iCnChar >= 45217) && (iCnChar <= 45252))
        {
            return "A";
        }

        else if ((iCnChar >= 45253) && (iCnChar <= 45760))
        {
            return "B";
        }
        else if ((iCnChar >= 45761) && (iCnChar <= 46317))
        {

            return "C";

        }
        else if ((iCnChar >= 46318) && (iCnChar <= 46825))
        {

            return "D";

        }
        else if ((iCnChar >= 46826) && (iCnChar <= 47009))
        {

            return "E";

        }
        else if ((iCnChar >= 47010) && (iCnChar <= 47296))
        {

            return "F";

        }
        else if ((iCnChar >= 47297) && (iCnChar <= 47613))
        {

            return "G";

        }
        else if ((iCnChar >= 47614) && (iCnChar <= 48118))
        {

            return "H";

        }
        else if ((iCnChar >= 48119) && (iCnChar <= 49061))
        {

            return "J";

        }
        else if ((iCnChar >= 49062) && (iCnChar <= 49323))
        {

            return "K";

        }
        else if ((iCnChar >= 49324) && (iCnChar <= 49895))
        {

            return "L";

        }
        else if ((iCnChar >= 49896) && (iCnChar <= 50370))
        {

            return "M";

        }
        else if ((iCnChar >= 50371) && (iCnChar <= 50613))
        {

            return "N";

        }
        else if ((iCnChar >= 50614) && (iCnChar <= 50621))
        {

            return "O";

        }
        else if ((iCnChar >= 50622) && (iCnChar <= 50905))
        {

            return "P";

        }
        else if ((iCnChar >= 50906) && (iCnChar <= 51386))
        {

            return "Q";

        }
        else if ((iCnChar >= 51387) && (iCnChar <= 51445))
        {

            return "R";

        }
        else if ((iCnChar >= 51446) && (iCnChar <= 52217))
        {

            return "S";

        }
        else if ((iCnChar >= 52218) && (iCnChar <= 52697))
        {

            return "T";

        }
        else if ((iCnChar >= 52698) && (iCnChar <= 52979))
        {

            return "W";

        }
        else if ((iCnChar >= 52980) && (iCnChar <= 53640))
        {

            return "X";

        }
        else if ((iCnChar >= 53689) && (iCnChar <= 54480))
        {

            return "Y";

        }
        else if ((iCnChar >= 54481) && (iCnChar <= 55289))
        {

            return "Z";

        }
        else
            return ("?");

    }


    /// <summary>
    /// 仿微信排序
    /// A-Z == 65 - 90
    /// 0-9 == 48(+43) - 57(+43)  
    /// </summary>
    public static int GetFristASCIICode(string str)
    {
        if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str.TrimStart()))
        {
            return 101;
        }

        string InChar = str.TrimStart().Substring(0, 1);

        byte[] ZW = Encoding.Default.GetBytes(InChar);


        long iCnChar;

        //如果是字母，仅仅只有一个首字母
        if (ZW.Length == InChar.Length)
        {
            // A-Z
            if (ZW[0] >= 65 && ZW[0] <= 90)
            {
                return ZW[0];
            }
            else if (ZW[0] >= 97 && ZW[0] <= 122)
            {
                // a-z 转换成大写字母
                return ZW[0] - 32;
            }
            else
            {
                return ZW[0] + 43;
            }
        }
        else
        {
            // get the array of byte from the single char
            int i1 = (short)(ZW[0]);
            int i2 = (short)(ZW[1]);
            iCnChar = i1 * 256 + i2;
        }

        // iCnChar match the constant
        if ((iCnChar >= 45217) && (iCnChar <= 45252))
        {
            return 65;
        }

        else if ((iCnChar >= 45253) && (iCnChar <= 45760))
        {
            return 66;
        }
        else if ((iCnChar >= 45761) && (iCnChar <= 46317))
        {

            return 67;

        }
        else if ((iCnChar >= 46318) && (iCnChar <= 46825))
        {

            return 68;

        }
        else if ((iCnChar >= 46826) && (iCnChar <= 47009))
        {

            return 69;

        }
        else if ((iCnChar >= 47010) && (iCnChar <= 47296))
        {

            return 70;

        }
        else if ((iCnChar >= 47297) && (iCnChar <= 47613))
        {

            return 71;

        }
        else if ((iCnChar >= 47614) && (iCnChar <= 48118))
        {

            return 72;

        }
        else if ((iCnChar >= 48119) && (iCnChar <= 49061))
        {

            return 74; // j

        }
        else if ((iCnChar >= 49062) && (iCnChar <= 49323))
        {

            return 75;//k

        }
        else if ((iCnChar >= 49324) && (iCnChar <= 49895))
        {

            return 76; //l

        }
        else if ((iCnChar >= 49896) && (iCnChar <= 50370))
        {

            return 77;//m

        }
        else if ((iCnChar >= 50371) && (iCnChar <= 50613))
        {

            return 78;//n

        }
        else if ((iCnChar >= 50614) && (iCnChar <= 50621))
        {

            return 79;//o

        }
        else if ((iCnChar >= 50622) && (iCnChar <= 50905))
        {

            return 80;//p

        }
        else if ((iCnChar >= 50906) && (iCnChar <= 51386))
        {

            return 81;//q

        }
        else if (iCnChar == 61947)// 覃大宁
        {
            return 81;//q
        }
        else if ((iCnChar >= 51387) && (iCnChar <= 51445))
        {

            return 82;

        }
        else if ((iCnChar >= 51446) && (iCnChar <= 52217))
        {

            return 83;

        }
        else if ((iCnChar >= 52218) && (iCnChar <= 52697))
        {

            return 84;//t

        }
        else if ((iCnChar >= 52698) && (iCnChar <= 52979))
        {

            return 87;// "W"; //w

        }
        else if ((iCnChar >= 52980) && (iCnChar <= 53640))
        {

            return 88;// "X";//x

        }
        else if ((iCnChar >= 53689) && (iCnChar <= 54480))
        {

            return 89;/// "Y";


        }
        else if ((iCnChar >= 54481) && (iCnChar <= 55289))
        {

            return 90;// "Z";

        }
        else
            return 101;

    }
}
