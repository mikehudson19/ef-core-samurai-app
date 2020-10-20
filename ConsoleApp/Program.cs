using System;
using SamuraiApp.Domain;
using SamuraiApp.Data;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            GetSamurais("Before Add:");
            //InsertMultipleSamurais();
            AddSamurai();
            GetSamurais("After Add: ");
            GetSamuraisSimpler();
            //QueryFilters();
            //RetrieveAndUpdateSamurai();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        #region Methods
        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Ragnar" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
            Console.WriteLine("Successfully added to DB");
        }

        private static void InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Brida" };
            var samurai2 = new Samurai { Name = "Finan" };
            _context.Samurais.AddRange(samurai, samurai2);
            _context.SaveChanges();

        }

        private static void InsertVariousTypes()
        {
            var samurai = new Samurai { Name = "Alfred" };
            var clan = new Clan { ClanName = "Imperial Clan" };
            _context.AddRange(samurai, clan); // When you dont specify the DBSet, you can add various different types to the DB.
            _context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

        // TWO DIFFERENT WAYS TO EXECUTE A LINQ QUERY - USE THE TOLIST() METHOD, OR ENUMERATE OVER. USING TOLIST() IS THE BETTER APPROACH. 
        private static void GetSamuraisSimpler()
        {
            //var query = _context.Samurais;
            //foreach (var samurai in query)
            //{
            //    Console.WriteLine(samurai.Name);
            //}

            var samurais = _context.Samurais.ToList();
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

        private static void QueryFilters()
        {
            //var samurais = _context.Samurais.Where(s => s.Name == "Ivar").ToList();
            //foreach (var samurai in samurais)
            //{
            //Console.WriteLine(samurai.Name);
            //}

            //var samurais = _context.Samurais.Where(s => s.Name.Contains("U")).ToList();
            //foreach (var samurai in samurais)
            //{
            //Console.WriteLine(samurai.Name);
            //}

            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Bjorn");
            Console.WriteLine(samurai.Name);

            var last = _context.Samurais.OrderBy(s => s.Id).LastOrDefault(s => s.Name == "Bjorn");
            Console.WriteLine(last.Name);
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "san";
            _context.SaveChanges();
            Console.WriteLine(samurai.Name);
        }

        private static void RetrieveAndDeleteSamurai()
        {
            var samurai = _context.Samurais.Find(1);
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
        }
        #endregion
    }
}
