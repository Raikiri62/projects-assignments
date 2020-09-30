public class ArgumentIsNotPositiveNumberException : ValueOutOfRangeException
{
    public ArgumentIsNotPositiveNumberException(string i_NameOfArgument, float i_ActualValue, float i_MaxValue = float.PositiveInfinity, bool i_IncludeMax = true)
        : base(i_NameOfArgument, i_ActualValue, 0f, i_MaxValue, /*i_IncludeMin = */false, i_IncludeMax)
    {
    }

    public ArgumentIsNotPositiveNumberException(string i_NameOfArgument, byte i_ActualValue, byte i_MaxValue, bool i_IncludeMax = true)
        : base(i_NameOfArgument, i_ActualValue, 0, i_MaxValue, /*i_IncludeMin = */false, i_IncludeMax)
    {
    }

    public ArgumentIsNotPositiveNumberException(string i_NameOfArgument, int i_ActualValue)
        : base(i_NameOfArgument, i_ActualValue, 0, eComparisonOperator.Greater)
    {
    }
}