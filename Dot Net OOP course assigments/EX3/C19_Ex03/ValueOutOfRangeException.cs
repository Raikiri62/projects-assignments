using System;

public class ValueOutOfRangeException : ArgumentOutOfRangeException
{
    private readonly float r_MinValue;
    private readonly float r_MaxValue;

    public ValueOutOfRangeException(string i_NameOfArgument, float i_ActualValue, float i_MinValue, float i_MaxValue, bool i_IncludeMin = true, bool i_IncludeMax = true)
        : base(i_NameOfArgument, i_ActualValue, string.Format("{0}{1}{2}",
        float.IsNegativeInfinity(i_MinValue) ? string.Empty : string.Format("{0} <{1} ", i_MinValue, i_IncludeMin ? "=" : string.Empty),
        i_NameOfArgument,
        float.IsPositiveInfinity(i_MaxValue) ? string.Empty : string.Format(" <{0} {1}", i_IncludeMax ? "=" : string.Empty, i_MaxValue),
        i_IncludeMin ? "=" : string.Empty, i_IncludeMax ? "=" : string.Empty))
    {
        r_MinValue = i_MinValue;
        r_MaxValue = i_MaxValue;
    }

    public ValueOutOfRangeException(string i_NameOfArgument, byte i_ActualValue, byte i_MinValue, byte i_MaxValue, bool i_IncludeMin = true, bool i_IncludeMax = true)
        : base(i_NameOfArgument, i_ActualValue, string.Format("{0} <{3} {1} <{3} {2}", i_NameOfArgument, i_MinValue, i_MaxValue))
    {
        r_MinValue = i_MinValue;
        r_MaxValue = i_MaxValue;
    }

    public ValueOutOfRangeException(string i_NameOfArgument, int i_ActualValue, int i_Threshold, eComparisonOperator i_ComparisonOperator)
        : base(i_NameOfArgument, i_ActualValue, string.Format("{0} {1} {2}", i_NameOfArgument, ComparisonOperator.ToString(i_ComparisonOperator), i_Threshold))
    {
    }

    public float MinValue
    {
        get { return r_MinValue; }
    }

    public float MaxValue
    {
        get { return r_MaxValue; }
    }
}