using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Serialized_HW1
{
    public class Subunit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public List<Subunit> SubUnits { get; set; }
        public List<WhiteCollar> Employees { get; set; }
    }
    public class Corporate
    {
        public string CorpName { get; set; }
        public List<Subunit> Departments { get; set; }
    }

    public class WhiteCollar
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string BirthDate { get; set; }
        public bool IsHead { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Corporate parkwood = new Corporate
            {
                CorpName = "Parkwood Entertainment",
                Departments = new List<Subunit>()
            };

            Subunit arts = new Subunit
            {
                UnitId = 1,
                UnitName = "Artists & Repertoire",
                SubUnits = new List<Subunit>(),
                Employees = new List<WhiteCollar>()
            };

            Subunit marketing = new Subunit
            {
                UnitId = 2,
                UnitName = "Marketing",
                SubUnits = new List<Subunit>(),
                Employees = new List<WhiteCollar>()
            };

            WhiteCollar bey = new WhiteCollar
            {
                Name = "Beyonce",
                Surname = "Knowles",
                Position = "CEO",
                BirthDate = "04/09/1981",
                IsHead = true
            };

            string json = JsonSerializer.Serialize(parkwood);
            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}