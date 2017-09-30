using System;
using System.IO;
using Starcounter.Core.Options;
using Starcounter.Core.Bluestar;
using Starcounter.Core.Hosting;
using Starcounter.Core;
using System.Linq;

namespace SC.ConsoleStarter
{
    [Database]
    public abstract class Person
    {
        public abstract string Name { get; set; }
        public abstract string Says { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const string dbName = "defaultDatabase";

            CreateDatabaseIfNone(dbName);

            using (var appHost = new AppHostBuilder()
                .UseDatabase(dbName)
                .Build())
            {
                appHost.Start();
                Console.WriteLine("App host started");

                Db.Transact(() =>
                {
                    var person = Db.Insert<Person>();
                    person.Name = "John Doe";
                    person.Says = "Hello world!";
                });

                Db.Transact(() =>
                {
                    var person = Db.SQL<Person>(
                        $"SELECT p FROM {typeof(Person)} p")
                        .FirstOrDefault();

                    Console.WriteLine($"{person.Name} says \"{person.Says}\"");
                });
            }
        }

        static void CreateDatabaseIfNone(string dbName)
        {
            if (StarcounterOptions.TryOpenExisting(dbName))
                return;

            Directory.CreateDirectory(dbName);
            ScCreateDb.Execute(dbName);
            Console.WriteLine("Database started");
        }
    }
}
