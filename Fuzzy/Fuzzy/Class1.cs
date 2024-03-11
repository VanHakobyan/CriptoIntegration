using FuzzySharp;

namespace Fuzzy
{

    public class SQLFunctions
    {
        public static int Match(string input1, string input2)
        {
            return Fuzz.PartialRatio(input1, input2);
        }
    }
}
