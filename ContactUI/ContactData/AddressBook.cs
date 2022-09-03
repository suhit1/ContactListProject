using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactData
{
    public class AddressBook
    {

        public AddressBook()
        {
            //deserialize
            using (Stream stream = File.Open(@"C:\ContactListProject2015\ContactUI\ContactUI\data.bin", FileMode.Open))
            {
                try
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    Contact contactObj = (Contact)bformatter.Deserialize(stream);
                    while (contactObj != null)
                    {
                        contactList.Add(contactObj);
                         contactObj = (Contact)bformatter.Deserialize(stream);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        } 

        /// <summary>
        /// List for storing the Contact Object
        /// </summary>
        public List<Contact> contactList = new List<Contact>();

        /// <summary>
        /// Method to Add new Contact
        /// </summary>
        /// <param name="contactObj"> take contact class object as parameter </param>
        public void addContact(Contact contactObj)
        {
            contactList.Add(contactObj);
            Console.WriteLine("****************************************************");
            Console.WriteLine("Contact Is Successfully Added");
            Console.WriteLine("****************************************************");
        }

        /// <summary>
        /// Method to search Contact by name
        /// </summary>
        /// <param name="name"> takes name as parameter </param>
        /// <returns> it returns list of object of contact whose name matches </returns>
        public List<Contact> searchByName(string name)
        {
            // this will add all the objects of Contact class whose name starts with name(given string)
            List<Contact> nameFound = contactList.FindAll(x => x.getName().ToLower().StartsWith(name.ToLower()));

            return nameFound;
        }

        /// <summary>
        /// Method to search Contact by Organisation name
        /// </summary>
        /// <param name="organisation"> takes organisation name as parameter </param>
        /// <returns> returns list of object of contact whose organsation name matches </returns>
        public List<Contact> searchByOrganisation(string organisation)
        {
            // this will add all the objects of Contact class whose name starts with organisation(given string)
            List<Contact> organisationFound = contactList.FindAll(x => x.getOrganisation().ToLower().StartsWith(organisation.ToLower()));

            return organisationFound;
        }

        /// <summary>
        /// Method to update the Contact of existing Contact
        /// </summary>
        /// <param name="name"> takes name as parameter </param>
        /// <param name="contactObj"> takes contact object as parameter </param>
        public void updateContact(string name, Contact contactObj)
        {

            // displaying the user what user wants to update
            Console.WriteLine("What Do you want to Update ?");
            Console.WriteLine("Press 1 for Name");
            Console.WriteLine("Press 2 for Organisation");
            Console.WriteLine("Press 3 for PhoneNumber");
            Console.WriteLine("Press 4 for Address");

            Console.Write("Enter Your option : ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    string newName;
                    while (true)
                    {
                        while (true)
                        {
                            Console.Write("Enter the new name : ");
                            newName = Console.ReadLine();
                            bool isDigit = newName.Any(x => char.IsDigit(x));
                            if (isDigit == false && newName.Length < 255) break;
                            else Console.WriteLine("Name can only contain english letters and length must be less than 255");
                        }
                        bool nameExists = contactList.Any(x => x.getName().ToLower() == newName.ToLower());
                        try
                        {
                            if (nameExists == false) break;
                            else throw new Exception("Name Already Exists in Contact List!");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("****************************************************");
                            Console.WriteLine(e.Message);
                            Console.WriteLine("****************************************************");
                        }
                    }
                    contactObj.setName(newName);
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("Name Successfully Updated.");
                    Console.WriteLine("****************************************************");
                    break;
                case 2:
                    Console.Write("Enter the new name of your Organisation : ");
                    string newOrganisationName = Console.ReadLine();
                    contactObj.setOrganisationName(newOrganisationName);
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("Organisation Name Successfully Updated.");
                    Console.WriteLine("****************************************************");
                    break;
                case 3:
                    int phoneNumberCount = contactObj.getPhoneNumbers().Count();
                    string newPhoneNumber;
                    if (phoneNumberCount > 1)
                    {
                        Console.WriteLine($"There are { phoneNumberCount } phone numbers present which one do you like to update");
                        Console.Write("These are the current number present with us : ");
                        int count = 1;
                        foreach (PhoneNumber phone in contactObj.getPhoneNumbers())
                        {
                            Console.Write($"{phone.getPhoneNumber()}({count}) ");
                            count++;
                        }
                        Console.WriteLine();
                        Console.Write("Enter Your Choice Eg:- 1,2  :  ");
                        int choice = int.Parse(Console.ReadLine());
                        while (true)
                        {
                            Console.Write("Enter new phone number : ");
                            newPhoneNumber = Console.ReadLine();
                            bool containsLetter = newPhoneNumber.Any(x => char.IsLetter(x));
                            if (newPhoneNumber.Length == 10 && containsLetter == false) break;
                            else Console.WriteLine("Phone Number must be of length 10 and it should contain digits only");
                        }
                        contactObj.setPhoneNumber(choice, "+91"+newPhoneNumber);
                        string phoneLabel;
                        while (true)
                        {
                            Console.Write("Enter Phone Label Eg:- Work,Home : ");
                            phoneLabel = Console.ReadLine();
                            bool isValidLabel = phoneLabel.Any(x => char.IsDigit(x));
                            if (isValidLabel == false && phoneLabel.Length < 255) break;
                            else Console.WriteLine("Label can only contain english letters and must be off length less than 255");
                        }
                        contactObj.setPhoneNumberLabel(choice, phoneLabel);
                    }
                    else
                    {
                        Console.Write("This is your current number : ");
                        foreach (PhoneNumber phone in contactObj.getPhoneNumbers())
                            Console.Write($"{phone.getPhoneNumber()} ");
                        Console.WriteLine();
                        while (true)
                        {
                            Console.Write("Enter new phone number : ");
                            newPhoneNumber = Console.ReadLine();
                            bool containsLetter = newPhoneNumber.Any(x => char.IsLetter(x));
                            if (newPhoneNumber.Length == 10 && containsLetter == false) break;
                            else Console.WriteLine("Phone Number must be of length 10 and contain digits only");
                        }
                        contactObj.setPhoneNumber(1, "+91"+newPhoneNumber);
                        string phoneLabel;
                        while (true)
                        {
                            Console.Write("Enter Phone Label Eg:- Work,Home : ");
                            phoneLabel = Console.ReadLine();
                            bool isValidLabel = phoneLabel.Any(x => char.IsDigit(x));
                            if (isValidLabel == false && phoneLabel.Length < 255) break;
                            else Console.WriteLine("Label can only contain english letters and must be off length less than 255");
                        }
                        contactObj.setPhoneNumberLabel(1, phoneLabel);
                    }
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("PhoneNumber Updated Successfully.");
                    Console.WriteLine("****************************************************");
                    break;
                case 4:
                    int addressCount = contactObj.getAddresses().Count();
                    string newAddress;
                    if (addressCount > 1)
                    {
                        Console.WriteLine($"There are { addressCount } addresses present which one do you like to update");
                        Console.Write("These are the current addresses present with us : ");
                        int count = 1;
                        foreach (Address address in contactObj.getAddresses())
                        {
                            Console.Write($"{address.getAddress()}({count}) ");
                            count++;
                        }
                        Console.WriteLine();
                        Console.Write("Enter Your Choice Eg:- 1,2  :  ");
                        int choice = int.Parse(Console.ReadLine());
                        Console.Write("Enter new adress : ");
                        newAddress = Console.ReadLine();
                        contactObj.setAddress(choice, newAddress);
                        string addressLabel;
                        while (true)
                        {
                            Console.Write("Enter Address Label Eg:- Work,Home : ");
                            addressLabel = Console.ReadLine();
                            bool isValidLabel = addressLabel.Any(x => char.IsDigit(x));
                            if (isValidLabel == false && addressLabel.Length < 255) break;
                            else Console.WriteLine("Label can only contain english letters and must be off length less than 255");
                        }
                        contactObj.setAddressLabel(choice, addressLabel);

                    }
                    else
                    {
                        Console.Write("This is your current addresses : ");
                        foreach (Address address in contactObj.getAddresses())
                            Console.Write($"{address.getAddress()} ");
                        Console.WriteLine();
                        Console.Write("Enter new  Address : ");
                        newAddress = Console.ReadLine();
                        contactObj.setAddress(1, newAddress);
                        string addressLabel;
                        while (true)
                        {
                            Console.Write("Enter Address Label Eg:- Work,Home : ");
                            addressLabel = Console.ReadLine();
                            bool isValidLabel = addressLabel.Any(x => char.IsDigit(x));
                            if (isValidLabel == false && addressLabel.Length < 255) break;
                            else Console.WriteLine("Label can only contain english letters and must be off length less than 255");
                        }
                        contactObj.setAddressLabel(1, addressLabel);
                    }
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("Address Successfully Updated.");
                    Console.WriteLine("****************************************************");
                    break;
                default:
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("****************************************************");
                    break;
            }
        }

        /// <summary>
        /// Method to delete a contact
        /// </summary>
        /// <param name="name"> takes name as parameter </param>
        public void deleteContact(string name)
        {
            bool nameFound = contactList.Any(x => x.getName().ToLower()==name.ToLower());

            try
            {
                if (nameFound)
                {
                    int nameIndex = contactList.FindIndex(x => x.getName().ToLower() == name.ToLower());
                    contactList.RemoveAt(nameIndex);
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("Contact Deleted Successfully.");
                    Console.WriteLine("****************************************************");
                }
                else
                {
                    throw new Exception("Name not found");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("****************************************************");
                Console.WriteLine(e.Message);
                Console.WriteLine("****************************************************");
            }
        }
    }
}
