using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_bannikov
{

    public class Subunit
    {
        public int UnitId;
        public string UnitName;
        public List<Subunit> SubUnits;
        public List<WhiteCollar> Employees;
        public Subunit()
        {
            UnitId = ' ';
            UnitName = "unknown";
            SubUnits = new List<Subunit>();
            Employees = new List<WhiteCollar>();
        }

        public Subunit(int unitid, string unitname)
        {
            UnitId = unitid;
            UnitName = unitname;
            SubUnits = new List<Subunit>();
            Employees = new List<WhiteCollar>();
        }

        public void AddSubUnit(Subunit sunitname)
        {
            SubUnits.Add(sunitname);
        }

        public void AddEmployee(WhiteCollar employee)
        {
            Employees.Add(employee);
        }
        public string GetSubunit()
        {
            return "Unit Name:" + UnitName;
        }
    }

    public class Corporate
    {
        public string CorpName;
        public List<Subunit> Departments;

        public Corporate()
        {
            CorpName = "unknown";
            Departments = new List<Subunit>();
        }

        public Corporate(string corpname)
        {
            CorpName = corpname;
            Departments = new List<Subunit>();
        }

        public void AddDepartments(Subunit depname)
        {
            Departments.Add(depname);
        }

    }

    public class WhiteCollar
    {
        public string Name, Surname, Position, BirthDate;
        public bool IsHead;
        // тк вывод организовывать не нужно, дата рождения строкой 
        public WhiteCollar()
        {
            Name = "unknown";
            Surname = "unknown";
            Position = "unknown";
            BirthDate = "xx.xx.xxxx";
            IsHead = false;
        }

        public WhiteCollar(string name, string surname, string position,
            string birthdate, bool ishead)
        {
            Name = name;
            Surname = surname;
            Position = position;
            BirthDate = birthdate;
            IsHead = ishead;
        }

        public void SetHead()
        {
            IsHead = true;
        }

        public string GetWhiteCollar() => "Name: " + Name + " Surname:" + Surname + ". Date of Birth:" +
                    BirthDate + ". Position held: " + Position + "Dep. Head: " + IsHead;
    }


    class Program
    {
        public static void PrintUnitInfo(Subunit subun, int indent)
        {
            Console.Write(new String(' ', indent));
            Console.WriteLine(subun.UnitName);
            indent++;
            foreach (Subunit depart in subun.SubUnits)
            {
                PrintUnitInfo(depart, indent);
            }
        }

        static void Main(string[] args)
        {
            Corporate parkwood = new Corporate("Parkwood Entertainment");
            Subunit marketing = new Subunit(1, "Marketing");
            Subunit arts = new Subunit(2, "Artists & Repertoire");
            Subunit brands = new Subunit(3, "Brands");
            Subunit smed = new Subunit(4, "Social media marketing");
            Subunit tv = new Subunit(5, "TV marketing");
            WhiteCollar bey = new WhiteCollar("Beyonce", "Knowles", "CEO", "4/09/1981", true);
            WhiteCollar jlo = new WhiteCollar("Jennifer", "Lopez", "Singer", "24/07/1969", false);
            WhiteCollar emgad = new WhiteCollar("Emin", "Gadzhiev", "Marketing specialist", "22/01/2000", false);
            marketing.AddSubUnit(smed);
            marketing.AddSubUnit(tv);
            arts.AddEmployee(bey);
            arts.AddEmployee(jlo);
            smed.AddEmployee(emgad);
            emgad.SetHead();
            parkwood.AddDepartments(marketing);
            parkwood.AddDepartments(arts);
            parkwood.AddDepartments(brands);

            Console.WriteLine(parkwood.CorpName + " Hierarachy");

            foreach (Subunit subunit in parkwood.Departments)
            {
                PrintUnitInfo(subunit, 3);
            }
            Console.ReadLine();


        }
    }

}