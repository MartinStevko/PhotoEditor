using System;

namespace PhotoEditor
{
    static public class ColorFilters
    {
        static public Tuple<byte, byte, byte> NoFilter(byte red, byte green, byte blue)
        {
            return new Tuple<byte, byte, byte>(red, green, blue);
        }

        static public Tuple<byte, byte, byte> RedFilter(byte red, byte green, byte blue)
        {
            return new Tuple<byte, byte, byte>(red, 0, 0);
        }

        static public Tuple<byte, byte, byte> GreenFilter(byte red, byte green, byte blue)
        {
            return new Tuple<byte, byte, byte>(0, green, 0);
        }

        static public Tuple<byte, byte, byte> BlueFilter(byte red, byte green, byte blue)
        {
            return new Tuple<byte, byte, byte>(0, 0, blue);
        }
    }
}
