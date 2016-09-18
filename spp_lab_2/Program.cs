using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        public WeakReference Target;
        public MethodInfo Method;
        public WeakDelegate(Delegate ex)
        {
            this.Method = (MethodInfo)ex.Method;
            this.Target =new WeakReference(ex.Target);
            
        }

        public Delegate GetDelegate()
        {
            if (Target.IsAlive)
                return Delegate.CreateDelegate(Expression.GetDelegateType(
                    (from parameter in Method.GetParameters() select parameter.ParameterType)
                    .Concat(new[] { Method.ReturnType })
                        .ToArray()), Target.Target, Method);
            else
                return null;
        }
      
    }
}
