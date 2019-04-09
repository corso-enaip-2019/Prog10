using System;

namespace DIOC_Contracts
{
    public interface IGui
    {
        int ReadInt(string message);
        void Write(string message, bool newLine = true);
    }

    public interface IMath
    {
        bool IsPrime(int i);
    }
}
