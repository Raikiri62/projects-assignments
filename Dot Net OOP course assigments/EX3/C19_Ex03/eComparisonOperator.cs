public enum eComparisonOperator
{
    Greater,
    Less,
    GreaterOrEqual,
    LessOrEqual,
    Equal,
    Different
}

public static class ComparisonOperator
{
    public static string ToString(eComparisonOperator i_ComparisonOperator)
    {
        string output;
        switch (i_ComparisonOperator)
        {
            case eComparisonOperator.Different:
                output = "!=";
            break;
            case eComparisonOperator.Equal:
                output = "==";
            break;
            case eComparisonOperator.Greater:
                output = ">";
            break;
            case eComparisonOperator.GreaterOrEqual:
                output = ">=";
            break;
            case eComparisonOperator.Less:
                output = "<";
            break;
            case eComparisonOperator.LessOrEqual:
                output = "<=";
            break;
            default: throw new UnreachableCodeReachedException();
        }

        return output;
    }
}