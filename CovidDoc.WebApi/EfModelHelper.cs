using CovidDoc.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CovidDoc.WebApi
{
    public class EfModelHelper
    {
        public static IEnumerable<Type> GetEfClasses()
        {
            return Assembly.GetAssembly(typeof(AppUser)).GetTypes().Where(x => x.GetProperty(@"Id") != null);
        }
    }
}
