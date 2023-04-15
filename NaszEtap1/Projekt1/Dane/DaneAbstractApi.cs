using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class DaneAbstractApi
    {
        public static DaneAbstractApi CreateApi()
        { return new DaneApi(); }
    }

    internal class DaneApi : DaneAbstractApi { }
}
