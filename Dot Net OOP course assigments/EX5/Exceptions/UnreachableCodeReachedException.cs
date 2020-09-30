using System;

// If there is a code that is not reachable without hacking the software then throw this exception in this code.
// If this exception has been thrown then the software has been hacked by someone.
public class UnreachableCodeReachedException : Exception
{
    public UnreachableCodeReachedException() : base("Someone successfully hacked this software! Terminating now!")
    {
    }
}