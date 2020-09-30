using System;

public class UnreachableCodeReachedException : Exception
{
    public UnreachableCodeReachedException() : base("Someone successfully hacked this software! Terminating now!")
    {
    }
}