using System;
public class ArgumentNaNException : ArgumentException
{
    public ArgumentNaNException(string i_NameOfArgument) : base(i_NameOfArgument + " must not be NaN.", i_NameOfArgument)
    {
    }
}