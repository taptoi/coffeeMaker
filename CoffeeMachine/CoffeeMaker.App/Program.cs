using System;
using System.IO;
using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

using CoffeeMaker.Interface;

namespace CoffeeMaker.App
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            new Program().Run();
        }

    }

    public class Program 
    {
        [Import]
        public ICoffeeMakerService CoffeeMakerServiceApi { get; set; }

        public Program()
        {
            string directory = Directory.GetCurrentDirectory() + "/Plugins/";
            LoadPlugins(directory);    
        }

        public void Run()
        {
            int updateIntervalMs = 100;
            CoffeeMakerServiceApi.Start(updateIntervalMs);    
        }

        private void LoadPlugins(string directory)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog(directory));
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
