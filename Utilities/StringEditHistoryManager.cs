using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{

    public struct StringPosition {
        public int Pos;
        public int Length;

        public StringPosition(int pos, int length) { Pos = pos; Length = length; }
    }

    public class StringEditHistoryManager : EditHistoryManager<StringPosition, string?>
    {

        public StringBuilder StringBuilder { get; private set; }


        public StringEditHistoryManager(StringBuilder stringBuilder)
        {
            StringBuilder = stringBuilder;
        }

        public StringEditHistoryManager(string? text) : this(new StringBuilder(text)) { }


        public override bool AreEqualValues(StringPosition item, string? value1, string? value2)
        {
            return String.Equals(value1, value2);
        }

        public override void SetValue(StringPosition item, string? value)
        {
            if (item.Pos < StringBuilder.Length)
            {
                if (item.Length > 0) StringBuilder.Remove(item.Pos, item.Length);
                if (!string.IsNullOrEmpty(value)) StringBuilder.Insert(item.Pos, value);
            }
            else StringBuilder.Append(value);
        }
    }

}
