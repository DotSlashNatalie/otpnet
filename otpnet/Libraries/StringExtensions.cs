using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTPNet
{
    public static class StringExtensions
    {
        /// <summary>Returns a string array that contains the substrings in this string that are seperated a given fixed length.</summary>
        /// <param name="s">This string object.</param>
        /// <param name="length">Size of each substring.
        ///     <para>CASE: length &gt; 0 , RESULT: String is split from left to right.</para>
        ///     <para>CASE: length == 0 , RESULT: String is returned as the only entry in the array.</para>
        ///     <para>CASE: length &lt; 0 , RESULT: String is split from right to left.</para>
        /// </param>
        /// <returns>String array that has been split into substrings of equal length.</returns>
        /// <example>
        ///     <code>
        ///         string s = "1234567890";
        ///         string[] a = s.Split(4); // a == { "1234", "5678", "90" }
        ///     </code>
        /// </example>            
        public static string[] Split(this string s, int length)
        {
            System.Globalization.StringInfo str = new System.Globalization.StringInfo(s);

            int lengthAbs = Math.Abs(length);

            if (str == null || str.LengthInTextElements == 0 || lengthAbs == 0 || str.LengthInTextElements <= lengthAbs)
                return new string[] { str.ToString() };

            string[] array = new string[(str.LengthInTextElements % lengthAbs == 0 ? str.LengthInTextElements / lengthAbs : (str.LengthInTextElements / lengthAbs) + 1)];

            if (length > 0)
                for (int iStr = 0, iArray = 0; iStr < str.LengthInTextElements && iArray < array.Length; iStr += lengthAbs, iArray++)
                    array[iArray] = str.SubstringByTextElements(iStr, (str.LengthInTextElements - iStr < lengthAbs ? str.LengthInTextElements - iStr : lengthAbs));
            else // if (length < 0)
                for (int iStr = str.LengthInTextElements - 1, iArray = array.Length - 1; iStr >= 0 && iArray >= 0; iStr -= lengthAbs, iArray--)
                    array[iArray] = str.SubstringByTextElements((iStr - lengthAbs < 0 ? 0 : iStr - lengthAbs + 1), (iStr - lengthAbs < 0 ? iStr + 1 : lengthAbs));

            return array;
        }
    }
}
