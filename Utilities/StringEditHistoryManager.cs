using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{


    public class StringEditHistoryManager : EditHistoryManager<int, string>
    {

        public StringBuilder Text { get; private set; }


        public StringEditHistoryManager(StringBuilder text)
        {
            Text = text;
        }

        public StringEditHistoryManager(string text) : this(new StringBuilder(text)) { }


        public override bool AreEqualValues(int item, string value1, string value2)
        {
            return String.Equals(value1, value2);
        }

        public override void SetValue(int item, string value)
        {
            if (item < Text.Length) Text.Insert(item, value);
            else Text.Append(value);
        }
    }

}
