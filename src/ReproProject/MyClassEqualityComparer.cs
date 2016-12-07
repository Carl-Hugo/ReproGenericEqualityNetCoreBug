using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReproProject
{
    public class MyClassEqualityComparer<T>
        where T : class
    {
        public bool Equals(MyClass<T> x, MyClass<T> y)
        {
            var sameValue = x.Value == y.Value;
            return sameValue;
        }

        public bool AlternateEquals(MyClass<T> x, MyClass<T> y)
        {
            var sameValue = x.Value.Equals(y.Value);
            return sameValue;
        }
    }
}
