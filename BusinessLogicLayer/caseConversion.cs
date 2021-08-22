using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    class caseConversion
    {
    public static string firstCaseToUpper(string word)
        {
            if (string.IsNullOrEmpty(word))
                return string.Empty;

            char[] a = word.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            for (int i=1; i < a.Length; i++)
            {
                if (char.IsUpper(a[i]))
                {
                    a[i] = char.ToUpper(a[i]);
                }
            }
            return new string(a);
        }
    }
}
