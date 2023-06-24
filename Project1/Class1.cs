using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Class1
    {
        static void Main()
        {
            var catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine("Loaded assemblies:");
            foreach (var part in catalog.Parts)
            {
                Console.WriteLine(part.ToString());
            }

        }
    }
}
