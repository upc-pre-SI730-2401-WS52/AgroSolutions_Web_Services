using System;

namespace Shared;

public class FinanceNotException : Exception
{
    public FinanceNotException()
    {
    }

    public FinanceNotException(string message)
        : base(message)
    {
    }

    public FinanceNotException(string message, Exception inner)
        : base(message, inner)
    {
    }
}