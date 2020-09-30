using System;

public class ArgumentInfinityException : ArgumentException
{
    public ArgumentInfinityException(string i_NameOfArgument) : base(i_NameOfArgument + " must not be infinity.", i_NameOfArgument)
    {
    }
}