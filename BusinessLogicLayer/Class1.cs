using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    class caseConversion
    {
        static public String firstCaseToUpper(String word) {
            switch (String.IsNullOrEmpty(word)){
                case true:
                    return String.Empty;
             
                case false:
                    return char.ToUpper(word[0]) + word.Substring(1);
                    
            }
        }
    }
}
