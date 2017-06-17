using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TestCalcService
{
    public class MultiBinding : System.Windows.Data.MultiBinding
    {
        public MultiBinding(BindingBase b1, BindingBase b2, object converter)
        {
            Bindings.Add(b1);
            Bindings.Add(b2);
            Converter = converter as IMultiValueConverter;
        }
    }
}
