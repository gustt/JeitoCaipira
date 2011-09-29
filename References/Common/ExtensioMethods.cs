using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace References.Common
{
    public static class ExtensioMethods
    {
        public static int ToInt(this object value)
        {
                int castReturn;
                if (value != null && int.TryParse(value.ToString(), out castReturn))
                    return castReturn;
                else
                    return 0;
        }
    }
}
