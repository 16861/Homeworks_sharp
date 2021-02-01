using System;

namespace sixth_homework_convert
{
    public class TempConvertor
    {
        public int ConvertFromCtoF(int c) {
            return Convert.ToInt32((c*9/5)+32);
        }
        public int ConvertFromFtoC(int f) {
            return Convert.ToInt32((f-32)*5/9);
        }
    }
}
