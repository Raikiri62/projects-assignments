public static partial class Parse
{
     public static bool? Bool(string i_String)
     {
         bool output;
         return bool.TryParse(i_String, out output) ? new bool?(output) : null;
     }

     public static char? Char(string i_String)
     {
         char output;
         return char.TryParse(i_String, out output) ? new char?(output) : null;
     }

     public static byte? Byte(string i_String)
     {
         byte output;
         return byte.TryParse(i_String, out output) ? new byte?(output) : null;
     }

     public static sbyte? SByte(string i_String)
     {
         sbyte output;
         return sbyte.TryParse(i_String, out output) ? new sbyte?(output) : null;
     }

     public static ushort? UShort(string i_String)
     {
         ushort output;
         return ushort.TryParse(i_String, out output) ? new ushort?(output) : null;
     }

     public static short? Short(string i_String)
     {
         short output;
         return short.TryParse(i_String, out output) ? new short?(output) : null;
     }

     public static uint? UInt(string i_String)
     {
         uint output;
         return uint.TryParse(i_String, out output) ? new uint?(output) : null;
     }
     
     public static int? Int(string i_String)
     {
         int output;
         return int.TryParse(i_String, out output) ? new int?(output) : null;
     }

     public static ulong? ULong(string i_String)
     {
         ulong output;
         return ulong.TryParse(i_String, out output) ? new ulong?(output) : null;
     }

     public static long? Long(string i_String)
     {
         long output;
         return long.TryParse(i_String, out output) ? new long?(output) : null;
     }

     public static float? Float(string i_String)
     {
         float output;
         return float.TryParse(i_String, out output) ? new float?(output) : null;
     }

     public static double? Double(string i_String)
     {
         double output;
         return double.TryParse(i_String, out output) ? new double?(output) : null;
     }

     public static decimal? Decimal(string i_String)
     {
         decimal output;
         return decimal.TryParse(i_String, out output) ? new decimal?(output) : null;
     }

     public static System.DateTime? DateTime(string i_String)
     {
         System.DateTime output;
         return System.DateTime.TryParse(i_String, out output) ? new System.DateTime?(output) : null;
     }

     public static T? Enumeration<T>(string i_String) where T : struct
     {
         T output;
         return Enum<T>.TryParse(i_String, out output) ? new T?(output) : null;
     }
}