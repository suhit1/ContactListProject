using System;
using ContactData;
using System.Collections.Generic;
using System.Linq;

namespace ContactUI
{
    internal class ProgramHelpers
    {

        /// <summary>
        /// Helper method to add to contact
        /// </summary>
        /// <param name="addressBookObj"> Takes AddressBook Object as parameter </param>
        internal  void addToContact(AddressBook addressBookObj)
        {
            DetailsFromUser detailsFromUserObj = new DetailsFromUser();
            Contact contactObj = detailsFromUserObj.ContactDetailsFromUser(addressBookObj);
            addressBookObj.addContact(contactObj);       // sending the contactObj to AddressBook class
        }


        /// <summary>
        /// Helper method to search by name in contact
        /// </summary>
        /// <param name="addressBookObj"> takes AddressBook Object as parameter </param>
        internal void searchByName(AddressBook addressBookObj)
        {
            Console.Write("Enter the Name which you want to search: ");
            string contactName = Console.ReadLine();
            if (contactName.Length == 0) displayingContact(addressBookObj.contactList);
            else
            {
                List<Contact> namesFound = addressBookObj.searchByName(contactName);
                if (namesFound.Count == 0) Console.WriteLine("No record Found");
                else
                    displayingContact(namesFound);
            }
        }
        

        /// <summary>
        /// Helper method to search by organisation in contact
        /// </summary>
        /// <param name="addressBookObj"> Takes AddressBook Object as parameter </param>
        internal  void searchByOrganisation(AddressBook addressBookObj)
        {

            Console.Write("Enter the Name of the Organisation which you want to search: ");
            string organisationName = Console.ReadLine();
            if (organisationName.Length == 0) displayingContact(addressBookObj.contactList);
            else
            {
                List<Contact> organisationsFound = addressBookObj.searchByOrganisation(organisationName);
                try
                {
                    if (organisationsFound.Count == 0) throw new Exception("No record Found");
                    else
                        displayingContact(organisationsFound);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

        }


        /// <summary>
        /// Helper Method to update the contact
        /// </summary>
        /// <param name="addressBookObj"> Takes AddressBook Object as parameter </param>
        internal  void updatingContact(AddressBook addressBookObj)
        {
            DetailsFromUser detailsFromUserObj = new DetailsFromUser();
            string contactName = detailsFromUserObj.UpdateDetailsFromUser();
            IsValidChecker isValidCheckerObj = new IsValidChecker();
            Contact contactObj;

            // checking that name exists or not
            bool nameExists = isValidCheckerObj.NameExists(contactName,addressBookObj);
            Console.WriteLine("****************************************************");
            try
            {
                
                if (nameExists==false) throw new Exception("This name does not exists in Contact list!");
                else
                {
                    Console.WriteLine("Name Found");
                    contactObj = addressBookObj.contactList.Find(x => x.getName().ToLower() == contactName.ToLower());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("****************************************************");
                return;
            }
            Console.WriteLine("****************************************************");
            //if name exists
            addressBookObj.updateContact(contactName, contactObj);
        }


        /// <summary>
        /// Helper method to delete by name in contact
        /// </summary>
        /// <param name="addressBookObj"> Takes AddressBook Object as parameter </param>
        internal  void deleteContact(AddressBook addressBookObj)
        {
            Console.Write("Enter the name of Contact which you want to delete : ");
            string name = Console.ReadLine();
            addressBookObj.deleteContact(name);
        }


        /// <summary>
        /// Helper method to add phone number to an existing contact        
        /// </summary>
        /// <param name="addressBookObj"> takes AddressBook Object as parameter </param>
        internal  void addPhoneNumber(AddressBook addressBookObj)
        {
            Console.Write("Enter the name of contact of which you want to Add Phone Number to : ");
            string name = Console.ReadLine();
            IsValidChecker isValidCheckerObj = new IsValidChecker();
            bool nameIsFound = isValidCheckerObj.NameExists(name,addressBookObj);
            if(nameIsFound== true)
            {
                Console.WriteLine("Name Found ");

                Contact contactObj = addressBookObj.contactList.Find(x=>x.getName().ToLower() == name.ToLower());
                string phoneNumber;

                while (true)
                {
                    Console.Write("Enter The Phone Number : ");
                    phoneNumber = Console.ReadLine();
                    bool phoneIsvalid = isValidCheckerObj.phoneNumberCheck(phoneNumber);
                    if (phoneIsvalid == true) break;
                }
                string phoneLabel;
                while (true)
                {
                    Console.Write("Enter The Phone Number label Eg:- Work,Home : ");
                     phoneLabel = Console.ReadLine();
                    bool isValid = isValidCheckerObj.NameLabel(phoneLabel);
                    try
                    {
                        if (isValid == true) break;
                        else throw new Exception("Label can consist of only english letter and length must be less than 255");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                PhoneNumber phoneNumberObj = new PhoneNumber(phoneLabel, "+91"+phoneNumber);
                contactObj.addPhoneNumber(phoneNumberObj);
            }
            else
            {
                Console.WriteLine("****************************************************");
                Console.WriteLine("Name not found in contact List");
                Console.WriteLine("****************************************************");
            }
        }


        /// <summary>
        /// Helper method to add address to an existing contact
        /// </summary>
        /// <param name="addressBookObj"> Takes AddressBook Object as parameter </param>
        internal  void addAddress(AddressBook addressBookObj)
        {
            Console.Write("Enter the name of contact of which you want to Add Address to: ");
            string name = Console.ReadLine();
            IsValidChecker isValidCheckerObj = new IsValidChecker();
            bool nameIsFound = isValidCheckerObj.NameExists(name, addressBookObj);
            if (nameIsFound == true)
            {
                Console.WriteLine("Name Found ");

                Contact contactObj = addressBookObj.contactList.Find(x => x.getName().ToLower() == name.ToLower());
                Console.Write("Enter Address : ");
                string address = Console.ReadLine();
                string addressLabel;
                while (true)
                {
                    Console.Write("Enter The Address label Eg:- Office,Home : ");
                    addressLabel = Console.ReadLine();
                    bool isValid = isValidCheckerObj.NameLabel(addressLabel);
                    try
                    {
                        if (isValid == true && addressLabel.Length < 255) break;
                        else throw new Exception("Label can consist of only english letter and length must be less than 255");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Address addressObj = new Address(addressLabel,address);
                contactObj.addAddress(addressObj);
            }
            else
            {

                Console.WriteLine("Name not found in contact List");
            }
        }


        /// <summary>
        /// Method to display the contact list
        /// </summary>
        /// <param name="contactList"> Takes list of contact object as parameter </param>
        internal  void displayingContact(List<Contact> contactList)
        {

            Console.WriteLine("****************************************************");
            Console.WriteLine("Displaying Contact List");
            Console.WriteLine("****************************************************");
            foreach (Contact cont in contactList)
            {
                Console.WriteLine($"Name: {cont.getName()}");
                Console.WriteLine($"Organisation:{cont.getOrganisation()}");
                foreach (PhoneNumber phone in cont.getPhoneNumbers())
                {
                    Console.WriteLine($"PhoneNumber: {phone.getPhoneNumber()}");
                    Console.WriteLine($"PhoneLabel: { phone.getLabel()}");
                }
                foreach (Address address in cont.getAddresses())
                {
                    Console.WriteLine($"Address: {address.getAddress()}");
                    Console.WriteLine($"Addresslabel: { address.getLabel()}");
                }
                Console.WriteLine("****************************************************");
            }
        }
    }
}