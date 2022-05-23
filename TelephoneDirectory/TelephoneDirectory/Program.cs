using System;
using System.Collections.Generic;
using System.Linq;

namespace TelephoneDirectory
{

    interface Info
    {

        string Name { get; }
        bool Status { get; }
        string ContactInfo { get; }

        public string InfoType { get; set; }
        public string GetName();
        public string GetInfo();
        public bool GetStatus();
        public void Process();
    }

    class Phone : Info
    {
        public string InfoType { get; set; }
        public string Name { get;}
        public bool Status { get; }
        public string ContactInfo { get; }

        public Phone(string Name, bool Status, string ContactInfo)
        {
            this.Name = Name;
            this.Status = Status;    
            this.ContactInfo = ContactInfo;
        }

        public string GetName()
        {
            return Name;
        }
        public string GetInfo()
        {
            return ContactInfo;
        }
        public bool GetStatus()
        {
            return Status;
        }
        public void Process()
        {
            InfoType = "Phone number";
            Console.WriteLine(InfoType + " of " + Name + " is " + ContactInfo);
        }
    }

    class Email : Info
    {
        public string InfoType { get; set; }
        public string Name { get; }
        public bool Status { get; }
        public string ContactInfo { get; }

        public Email(string Name, bool Status, string ContactInfo)
        {
            this.Name = Name;
            this.Status = Status;
            this.ContactInfo = ContactInfo;
        }

        public string GetName()
        {
            return Name;
        }
        public string GetInfo()
        {
            return ContactInfo;
        }
        public bool GetStatus()
        {
            return Status;
        }
        public void Process()
        {
            InfoType = "Email Address";
            Console.WriteLine(InfoType + " of " + Name + "is" + ContactInfo);
        }
    }

    class Address : Info
    {
        public string InfoType { get; set; }
        public string Name { get; }
        public bool Status { get; }
        public string ContactInfo { get; }

        public Address(string Name, bool Status, string ContactInfo)
        {
            this.Name = Name;
            this.Status = Status;
            this.ContactInfo = ContactInfo;
        }

        public string GetName()
        {
            return Name;
        }
        public string GetInfo()
        {
            return ContactInfo;
        }
        public bool GetStatus()
        {
            return Status;
        }
        public void Process()
        {
            InfoType = "Address";
            Console.WriteLine(InfoType + " of " + Name + "is" + ContactInfo);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
            List<Info> contactList = CreateContactList();
            ConsoleCommands(contactList);
        }
        static void PrintMenu()
        {
            Console.WriteLine("**************Welcome To Phone Directory**************");
            Console.WriteLine("Type 'search {key}' to search a pattern among registered names");
            Console.WriteLine("Type 'process' to see all contacts");
            Console.WriteLine("Type 'exit' to exit");
        }
        static List<Info> CreateContactList()
        {
            List<Info> contactList = new List<Info>();

            Phone contact1 = new Phone("Hüma Bilgin", true, "5301764890");
            Phone contact2 = new Phone("Emre Yilmaz", true, "5301768260");
            Phone contact4 = new Phone("Umut Türe", true, "5467458978");
            Phone contact6 = new Phone("Beyza Gül", true, "5467458978");
            Email contact5 = new Email("Sıla Horu", false, "silahoru@gmail.com");
            Email contact7 = new Email("Feyza Bula", true, "feyzabula@gmail.com");
            Address contact3 = new Address("Nevzat Kaya", true, "Irmak Sk. No:4 Kadıköy İstanbul");
            Address contact8 = new Address("Ahmet Gülmüş", false, "Levazım cd. No:34 Beşiktaş İstanbul");
            Address contact9 = new Address("Tugay Uslu", false, "Çiçek Sk. No:12 Eminönü İstanbul");
            Address contact10 = new Address("Ateş Kızıl", true, "Nur Caddesi No:33 Şişli İstanbul");
            Address contact11 = new Address("Damla Güneş", false, "Selimiye Mahallesi pot Sokak No:7 İstanbul");

            contactList.Add(contact1);
            contactList.Add(contact2);
            contactList.Add(contact3);
            contactList.Add(contact4);
            contactList.Add(contact5);
            contactList.Add(contact6);
            contactList.Add(contact7);
            contactList.Add(contact8);
            contactList.Add(contact9);
            contactList.Add(contact10);
            contactList.Add(contact11);

            return contactList;
        }
        static void ConsoleCommands(List<Info> contactList)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.StartsWith("search "))
                {
                    Search(input, contactList);
                }
                else if (input == "process")
                {
                    foreach (Info contact in contactList)
                    {
                        bool isActive = contact.GetStatus();
                        if (isActive)
                        {
                            contact.Process();
                        }
                    }
                }
                else if (input == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command, please try again.");
                }
            }
        }
        static void Search(string input, List<Info> contactList)
        {
            int counter = 0;
            List<string> splittedInput = input.Split(' ').ToList();
            splittedInput.RemoveAt(0);
            string keyToSearch = string.Join(" ", splittedInput); 
            Console.WriteLine(keyToSearch);
            foreach (Info contact in contactList)
            {
                if (contact.Name.Contains(keyToSearch))
                {
                    counter++;
                    Console.WriteLine(contact.Name);
                }
            }
            if(counter == 0)
            {
                Console.WriteLine("There is no name matches with the key.");
            }
            else if(counter > 10)
            {
                Console.WriteLine("Too many results, please expand the search and try again.");
            }
        }
    }
}
