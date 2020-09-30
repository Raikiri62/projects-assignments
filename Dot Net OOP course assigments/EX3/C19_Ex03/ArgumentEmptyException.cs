using System;

public class ArgumentEmptyException : ArgumentException
{
    public ArgumentEmptyException(string i_NameOfArgument) : base(i_NameOfArgument + " must not be empty.", i_NameOfArgument)
    {
    }
}