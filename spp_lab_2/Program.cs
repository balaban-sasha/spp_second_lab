using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace spp_lab_2
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class WeakDelegate
    {
        private Action<int, int> ex1;

        public WeakDelegate(Action<int, int> ex1)
        {
            this.ex1 = ex1;
        }

        public void GetDelegate()
        {
            ex1.Invoke(3,2);
        }
    }
}
