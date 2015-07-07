using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace CheckSite
{
    class IoCContainer
    {
        private static Lazy<IKernel> _kernel = new Lazy<IKernel>(() => new StandardKernel());

        private static IKernel Kernel
        {
            get { return _kernel.Value; }
        }

        public static object Get(Type objectType)
        {
            return Kernel.Get(objectType);
        }

        public static T Get<T>()
        {
            return Kernel.TryGet<T>();
        }

        public static void Initialize(Action<IKernel> initLogic)
        {
            initLogic(Kernel);
        }
    }
}
