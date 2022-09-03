using System;
using ContactData;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUI
{
    internal  class GetOptionsFromUser
    {

        /// <summary>
        /// Method to display the Options
        /// </summary>
        internal  void DisplayOptions()
        {
            Console.WriteLine("Please Select From the Below Options :- ");
            Console.WriteLine("0 For Exit!");
            Console.WriteLine("1 For Add New Contact");
            Console.WriteLine("2 For Search By Name");
            Console.WriteLine("3 For Search By Organisation");
            Console.WriteLine("4 For Updating Contact");
            Console.WriteLine("5 For Deleting Contact");
            Console.WriteLine("6 For Adding PhoneNumber to an existing Contact");
            Console.WriteLine("7 For Adding Address to an existing Contact");
            Console.WriteLine("8 For Displaying the Contact List");
            Console.WriteLine("****************************************************");
            Console.Write("Enter Your Option : ");
        }

        /// <summary>
        /// Method to take input from user For the option
        /// </summary>
        internal void GetOptions()
        {
            AddressBook addressBookObj = new AddressBook();
            ProgramHelpers programHelperObj = new ProgramHelpers();

            while (true)
            {
                DisplayOptions();
                int option=-1;
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please Select From The Above Option Only!");
                }

                if (option == 0) break;

                switch (option)
                {
                    case 1:
                        programHelperObj.addToContact(addressBookObj);
                        break;
                    case 2:
                        programHelperObj.searchByName(addressBookObj);
                        break;
                    case 3:
                        programHelperObj.searchByOrganisation(addressBookObj);
                        break;
                    case 4:
                        programHelperObj.updatingContact(addressBookObj);
                        break;
                    case 5:
                        programHelperObj.deleteContact(addressBookObj);
                        break;
                    case 6:
                        programHelperObj.addPhoneNumber(addressBookObj);
                        break;
                    case 7:
                        programHelperObj.addAddress(addressBookObj);
                        break;
                    case 8:
                        programHelperObj.displayingContact(addressBookObj.contactList);
                        break;
                    default:
                        Console.WriteLine("****************************************************");
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine("****************************************************");
                        break;
                }
            }
            //serialize
            using (Stream stream = File.Open(FilePath.dir, FileMode.Create))
            {
                try
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, addressBookObj.contactList);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
