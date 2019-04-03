using System;
using System.Collections.Generic;
using System.Drawing;

namespace PlugInSystem
{
    public interface IGUI
    {
        int AskForPositiveInt(string requestMessage);
        decimal AskForDecimal(string requestMessage);
        string AskForText(string requestMessage);
        ConsoleKeyInfo AskForKey(bool intercept = false);
        void WriteMessage(string message = null, bool newLine = true);
        void WriteMessage(string message, Color color, bool newLine = true);
        bool AskForExit();
        void ClrScr();
        void PrintList<T>(string listName, List<T> list);
    }
}
