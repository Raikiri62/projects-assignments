using System;
using System.Collections;

public class TuringMachine<T> : IEnumerable
{
    private T[] m_TapeContent;
    private long m_HeadPosition;

    public TuringMachine(ulong i_LengthOfTape, T i_symbol, long i_InitialHeadPosition = 0)
    {
        m_TapeContent = new T[i_LengthOfTape];
        for (long i = PositionOfFirstSymbol; i <= PositionOfLastSymbol; i++)
        {
            m_TapeContent[i] = i_symbol;
        }

        m_HeadPosition = i_InitialHeadPosition;
    }

    public T[] TapeContent
    {
        get
        {
            return m_TapeContent;
        }

        set
        {
            m_TapeContent = value;
            m_HeadPosition = 0;
        }
    }

    public long HeadPosition
    {
        get
        {
            return m_HeadPosition;
        }

        set
        {
            if (value < PositionOfFirstSymbol || value > PositionOfLastSymbol)
            {
                throw new ArgumentOutOfRangeException("value", value, string.Format("HeadPosition must be both either greater than or equal to PositionOfFirstSymbol ({0}) and less than or equal to PositionOfLastSymbol ({1}).", PositionOfFirstSymbol, PositionOfLastSymbol));
            }

            m_HeadPosition = value;
        }
    }

    public T CurrentSymbol
    {
        get
        {
            return m_TapeContent[m_HeadPosition];
        }

        set
        {
            m_TapeContent[m_HeadPosition] = value;
        }
    }

    public long PositionOfFirstSymbol
    {
        get
        {
            return 0;
        }
    }

    public long LengthOfTape
    {
        get
        {
            return m_TapeContent.LongLength;
        }
    }

    public long PositionOfLastSymbol
    {
        get
        {
            return LengthOfTape - 1;
        }
    }

    public long Move(long i_movement = 1)
    {
        long headMovement;
        long newHeadPosition = m_HeadPosition + i_movement;
        if (newHeadPosition >= PositionOfFirstSymbol && newHeadPosition <= PositionOfLastSymbol)
        {
            m_HeadPosition = newHeadPosition;
            headMovement = i_movement;
        }
        else if (newHeadPosition > PositionOfLastSymbol)
        {
            headMovement = PositionOfLastSymbol - m_HeadPosition;
            m_HeadPosition = PositionOfLastSymbol;
        }
        else if (newHeadPosition < PositionOfFirstSymbol)
        {
            headMovement = PositionOfFirstSymbol - m_HeadPosition;
            m_HeadPosition = PositionOfFirstSymbol;
        }
        else
        {
            throw new UnreachableCodeReachedException();
        }

        return headMovement;
    }

    public long Jump(long i_target)
    {
        long headMovement;
        if (i_target >= PositionOfFirstSymbol && i_target <= PositionOfLastSymbol)
        {
            headMovement = i_target - m_HeadPosition;
            m_HeadPosition = i_target;
        }
        else if (i_target > PositionOfLastSymbol)
        {
            headMovement = PositionOfLastSymbol - m_HeadPosition;
            m_HeadPosition = PositionOfLastSymbol;
        }
        else if (i_target < PositionOfFirstSymbol)
        {
            headMovement = PositionOfFirstSymbol - m_HeadPosition;
            m_HeadPosition = PositionOfFirstSymbol;
        }
        else
        {
            throw new UnreachableCodeReachedException();
        }

        return headMovement;
    }

    public long Write(T i_symbol, long i_movement = 1)
    {
        CurrentSymbol = i_symbol;
        return Move(i_movement);
    }

    public T Read(long i_movement = 1)
    {
        T readSymbol = CurrentSymbol;
        Move(i_movement);
        return readSymbol;
    }

    public IEnumerator GetEnumerator()
    {
        return m_TapeContent.GetEnumerator();
    }

    public T this[long index]
    {
        get
        {
            return m_TapeContent[index];
        }

        set
        {
            m_TapeContent[index] = value;
        }
    }
}