using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Inlamning_2_ra_kod
{
    class Person
    {
        public string name, address, phone, email;
        public Person(string N, string A, string P, string E)
        {
            name = N; address = A; phone = P; email = E;
        }
        public Person()
        {
            Console.WriteLine("Lägger till ny person");
            Console.Write("  1. ange namn:    ");
            name = Console.ReadLine();
            Console.Write("  2. ange adress:  ");
            address = Console.ReadLine();
            Console.Write("  3. ange telefon: ");
            phone = Console.ReadLine();
            Console.Write("  4. ange email:   ");
            email = Console.ReadLine();
        }

        public void SetAttribute(string spacestochange,string newvalue)
        {
            switch (spacestochange)
            {
                case "name": name = newvalue; break;
                case "address":address = newvalue; break;
                case "phone":phone = newvalue; break;
                case "email": email = newvalue; break;
                default: break;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> Dict = new List<Person>();
            string filePath = @"C:\Users\Dator 15\source\repos\Inlamning_2_ra_kod\Inlamning_2_ra_kod\list.txt";
            Console.Write("Laddar adresslistan ... ");
            using (StreamReader fileStream = new StreamReader(filePath))
            {
                while (fileStream.Peek() >= 0)
                {
                    string line = fileStream.ReadLine();
                    string[] word = line.Split('#');
                    Person P = new Person(word[0], word[1], word[2], word[3]);
                    Dict.Add(P);
                }
            }
            Console.WriteLine("done!");
            Console.WriteLine("hi welcome to the address list");
            Console.WriteLine("type exit to exit ");
            string command;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                string[] abook = command.Split(' ');
                switch (abook[0])
                {
                    case "exit":
                        stopvoid(Dict, abook);
                        break;
                    case "new":
                        newvoid(Dict, abook);
                        break;
                    case "delete":
                        deletevoid(Dict, abook);
                        break;
                    case "show":
                        showvoid(Dict, abook);
                        break;
                    case "edit":
                        editvoid(Dict, abook);
                        break;
                }
            } while (command != "exit");
        }
        // METHOD: slutavoid
        // PURPOSE: if you type the command "sluta" this method wil type out the messige "hej då"
        //PARAMETERS: alla parametrarnas namn och innebörd
        //RETURN VALUE: returvärdets innebörd
        static void stopvoid(List<Person> Dict, string[] abook)
        {
            Console.WriteLine("by bye!");
        }
        // METHOD: nyvoid
        // PURPOSE: hur den används
        //PARAMETERS: alla parametrarnas namn och innebörd
        //RETURN VALUE: returvärdets innebörd
        static void newvoid(List<Person> Dict, string[] abook)
        {
            Dict.Add(new Person());
        }
        // METHOD: tabortvoid
        // PURPOSE: the purpose of this method is to delete peapole from the list
        static void deletevoid(List<Person> Dict, string[] abook)
        {
            Console.Write("who do you want to delet (type name): ");
            string wanttoremove = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].name == wanttoremove) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Error: {0} didnt exist in the phone list", wanttoremove);
            }
            else
            {
                Dict.RemoveAt(found);
            }
        }
        // METHOD: visa
        // PURPOSE: if you type the command "visa" it will show you the list of pepole in the list the name,
        //RETURN VALUE: --
        static void showvoid(List<Person> Dict, string[] abook)
        {
            for (int i = 0; i < Dict.Count(); i++)
            {
                Person P = Dict[i];
                Console.WriteLine("{0}, {1}, {2}, {3}", P.name, P.address, P.phone, P.email);
            }
        }
        // METHOD: ändravoid
        // PURPOSE: in this methode you can edit the pepole in the list
        static void editvoid(List<Person> Dict, string[] abook)
        {
            Console.Write("who do yu want to edit (type name): ");
            string wanttochange = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].name == wanttochange) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("error: {0} didnt exist in det phone list", wanttochange);
            }
            else
            {
                Console.Write("what do you want to edit (name, address, phone or email): ");
                string spacestochange = Console.ReadLine();
                Console.Write("what did you want to edit {0} on {1} to: ", spacestochange, wanttochange);
                string newvalue = Console.ReadLine();
              
                 Dict[found].SetAttribute(spacestochange, newvalue);
            }
            
        }
    }
}