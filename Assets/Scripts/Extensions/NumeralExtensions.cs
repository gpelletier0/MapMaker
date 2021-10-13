namespace Extensions
{
    public static class NumeralExtensions
    {
        public static int ZeroCheck(this int numeral) => numeral < 0 ? 0 : numeral;
    }
}