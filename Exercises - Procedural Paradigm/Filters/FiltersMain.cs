using PlugInSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class FiltersMain : AExercise
    {
        public override string Description => "Filters";

        public override Version VersionNumber => new Version(1,0);

        private List<string> MockList = new List<string>()
        {
            "Questo",
            "Esercizio",
            "Serve a lavorare",
            "C0n Str1ngh3",
            "89734512",
            "Moooooolto casuali.....",
            "4m",
            "pappappero",
            "ammazza oh",
            "Anvedi questo",
        };

        public override void Run(IGUI guiHandler)
        {
            guiHandler.PrintList("Starting list", MockList);
            guiHandler.WriteMessage();

            guiHandler.PrintList("Reverted elements list", MockList.ToRevertedStrings());
            guiHandler.WriteMessage();
            guiHandler.PrintList("Element length list", MockList.ToLengthList());
            guiHandler.WriteMessage();

            guiHandler.PrintList("Element shorter than 3", MockList.LessThanLength(3));
            guiHandler.WriteMessage();
            guiHandler.PrintList("Element beginning with a", MockList.StartWithLetter('a'));
            guiHandler.WriteMessage();
            guiHandler.PrintList("Element convertible in int", MockList.IsConvertibleInInt());
            guiHandler.WriteMessage();

            guiHandler.AskForExit();
        }
    }

    public static class MyProjections
    {
        public static List<string> ToRevertedStrings(this List<string> inList)
        {
            List<string> outList = new List<string>();

            foreach (var text in inList)
            {                
                outList.Add(text.Revert());
            }

            return outList;
        }

        public static string Revert(this string strIn)
        {
            string strOut = "";
            for (int i = strIn.Length - 1; i >= 0; i--)
            {
                strOut += strIn[i];
            }
            return strOut;
        }

        public static List<int> ToLengthList(this List<string> inList)
        {
            List<int> outList = new List<int>();

            foreach (var item in inList)
            {
                outList.Add(item.Length);
            }

            return outList;
        }
    }

    public static class MyFilters
    {
        public static List<string> LessThanLength(this List<string> inList, int maxLenght)
        {
            List<string> outList = new List<string>();

            foreach (var item in inList)
            {
                if (item.Length < maxLenght)
                {
                    outList.Add(item);
                }
            }

            return outList;
        }

        public static List<string> StartWithLetter(this List<string> inList, char startingLetter)
        {
            List<string> outList = new List<string>();

            foreach (var item in inList)
            {
                if (item.ToLower()[0] == startingLetter)
                {
                    outList.Add(item);
                }
            }

            return outList;
        }

        public static List<string> IsConvertibleInInt(this List<string> inList)
        {
            List<string> outList = new List<string>();

            foreach (var item in inList)
            {
                if (int.TryParse(item, out int myInt))
                {
                    outList.Add(item);
                }
            }

            return outList;
        }
    }
}
