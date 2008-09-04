using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace GreenTea.Utils
{
    public class NumberUtils
    {
        public static decimal RoundToMoney(decimal d)
        {
            string tmp = "";

            tmp = Math.Abs(d).ToString("C");
            tmp = tmp.Replace(",", "");
            decimal ret = 0;
            decimal.TryParse(tmp.Substring(1), out ret);
            if (d < 0)
                return -ret;
            else
                return ret;
        }

    }
}
