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

        public override Version VersionNumber => new Version(1, 0);

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
            "12.12",
            "42,84",
            "",
            null
        };

        public override void Run(IGUI guiHandler)
        {
            guiHandler.PrintList(MockList, "Starting list");
            guiHandler.WriteMessage();

            #region Extensions example
            guiHandler.PrintList(MockList.ToRevertedStrings(), "Reverted elements list");
            guiHandler.WriteMessage();
            guiHandler.PrintList(MockList.ToLengthList(), "Elements length list");
            guiHandler.WriteMessage();
            guiHandler.PrintList(MockList.LessThanLength(3), "Elements shorter than 3");
            guiHandler.WriteMessage();
            guiHandler.PrintList(MockList.StartWithLetter('a'), "Elements beginning with a");
            guiHandler.WriteMessage();
            guiHandler.PrintList(MockList.IsConvertibleInInt(), "Elements convertible in int");
            guiHandler.WriteMessage();
            #endregion Extensions example

            #region Interface example
            guiHandler.WriteMessage("WITH INTERFACE");
            guiHandler.PrintList(MockList.Filter(new ShortStringFilter(3)), "Elements shorter than 3");
            guiHandler.WriteMessage();
            guiHandler.PrintList(MockList.Filter(new StartWithFilter('a')), "Elements beginning with a");
            guiHandler.WriteMessage();
            guiHandler.PrintList(MockList.Filter(new StringConvertibleToInt_Filter()), "Elements convertible in int");
            guiHandler.WriteMessage();

            guiHandler.PrintList(MockList.Project(new LenghtFromString_Projection()), "Elements length list");
            guiHandler.WriteMessage();
            guiHandler.PrintList(MockList.Project(new InvertedString_Projection()), "Reverted elements list");
            guiHandler.WriteMessage();
            #endregion Interface example

            #region Delegate example
            guiHandler.WriteMessage("WITH DELEGATES");
            guiHandler.PrintList(MockList.FilterBy(x => x != null && x.Length < 3), "Elements shorter than 3");
            guiHandler.WriteMessage();
            guiHandler.PrintList(MockList.FilterBy(x =>x != null && (x.StartsWith("A") || x.StartsWith("a")))
                , "Elements beginning with a");
            guiHandler.WriteMessage();
            guiHandler.PrintList(MockList.FilterBy(x => x != null && int.TryParse(x, out int _)), "Elements convertible in int");
            guiHandler.WriteMessage();

            //guiHandler.PrintList(MockList.Project(new LenghtFromString_Projection()), "Elements length list");
            //guiHandler.WriteMessage();
            //guiHandler.PrintList(MockList.Project(new InvertedString_Projection()), "Reverted elements list");
            //guiHandler.WriteMessage();
            #endregion Delegate example

            guiHandler.AskForExit();
        }
    }

    #region Extensions filter and projections
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
            if (strIn == null) return null;

            string strOut = "";
            if (strIn != null)
            {
                for (int i = strIn.Length - 1; i >= 0; i--)
                {
                    strOut += strIn[i];
                }
            }
            return strOut;
        }

        public static List<int> ToLengthList(this List<string> inList)
        {
            List<int> outList = new List<int>();

            foreach (var item in inList)
            {
                if (item != null)
                {
                    outList.Add(item.Length);
                }
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
                if (item != null)
                {
                    if (item.Length < maxLenght)
                    {
                        outList.Add(item);
                    }
                }
            }

            return outList;
        }

        public static List<string> StartWithLetter(this List<string> inList, char startingLetter)
        {
            List<string> outList = new List<string>();

            foreach (var item in inList)
            {
                if (item != null && item.Length > 0)
                {
                    if (item.ToLower()[0] == startingLetter)
                    {
                        outList.Add(item);
                    }
                }
            }

            return outList;
        }

        public static List<string> IsConvertibleInInt(this List<string> inList)
        {
            List<string> outList = new List<string>();

            foreach (var item in inList)
            {
                if (item != null)
                {
                    if (int.TryParse(item, out int myInt))
                    {
                        outList.Add(item);
                    }
                }
            }

            return outList;
        }
    }
    #endregion Extensions filter and projections

    #region Interface filter
    public interface IFilter
    {
        bool Filter<T>(T s);
    }

    public static class MyFilters2
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> inList, IFilter condition)
        {
            List<T> outList = new List<T>();

            foreach (var item in inList)
            {
                if (condition.Filter(item))
                {
                    outList.Add(item);
                }
            }

            return outList;
        }
    }

    class ShortStringFilter : IFilter
    {
        int _maxValue = 0;
        public ShortStringFilter(int maxValue)
        {
            _maxValue = maxValue;
        }

        public bool Filter<T>(T s)
        {
            if (s == null) return false;
            return s.ToString().Length < _maxValue;
        }
    }

    class StringConvertibleToInt_Filter : IFilter
    {
        public bool Filter<T>(T s)
        {
            if (s == null) return false;
            return int.TryParse(s.ToString(), out int _);
        }
    }

    class StartWithFilter : IFilter
    {
        char _initalLower;
        char _initialUpper;

        public StartWithFilter(char initial)
        {
            _initalLower = char.ToLower(initial);
            _initialUpper = char.ToUpper(initial);
        }

        public bool Filter<T>(T s)
        {
            if (s == null) return false;
            return s.ToString().StartsWith(_initalLower.ToString()) || s.ToString().StartsWith(_initialUpper.ToString());
        }
    }
    #endregion Interface filter
    #region Interface projection
    public interface IProject<TInput, TOutput>
    {
        TOutput Project(TInput item);
    }

    public static class MyInterfaceProjection
    {
        public static IEnumerable<TOutput> Project<TInput, TOutput>(this IEnumerable<TInput> input, IProject<TInput, TOutput> projection)
        {
            List<TOutput> output = new List<TOutput>();

            foreach(TInput item in input)
            {
                output.Add(projection.Project(item));
            }

            return output;
        }
    }

    class LenghtFromString_Projection : IProject<string, int>
    {
        public int Project(string item)
        {
            if (item == null) return 0;
            return item.Length;
        }
    }

    class InvertedString_Projection : IProject<string, string>
    {
        public string Project(string item)
        {
            if (item == null) return null;
            return item.Revert();
        }
    }
    #endregion Interface projection

    #region Delegate system

    delegate bool Filter<TInput>(TInput item);

    static class Filters
    {
        public static IEnumerable<T> FilterBy<T>(this IEnumerable<T> input, Filter<T> filter)
        {
            List<T> output = new List<T>();

            foreach(var item in input)
            {
                if (filter(item))
                output.Add(item);
            }

            return output;
        }
    }
    #endregion Delegate system
}
