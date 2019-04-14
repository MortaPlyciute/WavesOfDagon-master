using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Extensions
{
    public static class ExtensionMethods
    {
        public static T CustomFirstOrDefault<T>(this List<T> list)
        {
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return default(T);
            }
        }
    }
}
