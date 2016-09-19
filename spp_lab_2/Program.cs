using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace spp_lab_2
{
    public class Program
    {
        static private GetFunctionResult GetFunction
        {
            get
            {
                return new GetFunctionResult();
            }
        }
        internal class GetFunctionResult
        {
            internal int GetRuslt(int arg1, int arg2, int arg3, int arg4)
            {
                return (arg1 + arg2) / (arg3 + arg4);
            }

            internal bool GetResultTwo(string arg1, bool arg2, bool arg3, string arg4, int arg5, int arg6)
            {
                if ((arg1 == "University") && (arg2 == true) && (arg3 == false) && (arg4 == "BSUIR") && (arg5 == 3)&&(arg6==2016))
                    return true;
                else
                    return false;
            }
        }

        static void Main(string[] args)
        {
            Delegate weakDelegate= new WeakDelegate((Func<int, int, int,int,int>)GetFunction.GetRuslt);

            Console.WriteLine(weakDelegate.DynamicInvoke(10, 20, 4, 1));
            weakDelegate = new WeakDelegate((Func<string,bool,bool,string,int,int,bool>)GetFunction.GetResultTwo);
            Console.WriteLine(weakDelegate.DynamicInvoke("University",true,false,"BSUIR",3, 2016));
            Console.ReadKey();
        }
    }
    public class WeakDelegate
    {
        public WeakReference target;
        public MethodInfo method;

        public Delegate Weak {
            get {
                if (target.IsAlive)
                    return Delegate.CreateDelegate(Expression.GetDelegateType(
                        (from parameter in method.GetParameters() select parameter.ParameterType)
                        .Concat(new[] { method.ReturnType })
                            .ToArray()), target.Target, method);
                else
                    return null;
            }
            set { }
        }

        public WeakDelegate(Delegate ex)
        {
            this.method = (MethodInfo)ex.Method;
            this.target =new WeakReference(ex.Target);
        }
        
        public static implicit operator Delegate(WeakDelegate ex)
        {
            return ex.Weak;

        }


    }

}