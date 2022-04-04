namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int MaxValue;
        private int MinValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }

        public override bool IsValid(object obj)
        {
            int inputInt = (int)obj;
            if (inputInt < MinValue || inputInt > MaxValue)
            {
                return false;
            } 
            return true;
        }
    }
}
