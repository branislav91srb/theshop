using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Utility
{
    public static class Compare
    {
        /// <summary>
        /// Compares property values of two objects 
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecound"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>False if not same type or all property values are not same. In other case true.</returns>
        public static bool EqualsTo<TFirst, TSecound>(this TFirst first, TSecound second) where TFirst : class, new() 
            where TSecound : class
        {
            // Check if same type
            if(first is TSecound == false)
            {
                return false;
            }

            foreach(var prop in typeof(TFirst).GetProperties())
            {
                var firstValue = prop.GetValue(first);
                var secondValue = prop.GetValue(second);

                if (!firstValue.Equals(secondValue))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
