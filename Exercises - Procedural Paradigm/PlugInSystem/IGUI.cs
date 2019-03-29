using System;
using System.Drawing;

namespace PlugInSystem
{
    public interface IGUI
    {
        int AskForPositiveInt(string requestMessage);
        string AskForText(string requestMessage);
        ConsoleKeyInfo AskForKey(bool intercept = false);
        void WriteMessage(string message, bool newLine = true);
        void WriteMessage(string message, Color color, bool newLine = true);
        bool AskForExit();
    }
}
