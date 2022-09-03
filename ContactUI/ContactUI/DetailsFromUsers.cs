using System;
using ContactData;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUI
{
    internal  class DetailsFromUser
    {

        /// <summary>
        /// Method to take input from user regarding name and organisation
        /// </summary>
        /// <param name="addressBookObj">  takes addressbook object as parameter</param>
        /// <returns> it returns the newly generated contact object </returns>
        internal  Contact ContactDetailsFromUser(AddressBook addressBookObj)
        {
            string contactName;
            IsValidChecker isValidCheckerObj = new IsValidChecker();
            while (true)
            {
                while (true)
                {
                    Console.Write("Enter the name of Contact: ");
                    contactName = Console.ReadLine();
                    bool isValidName = isValidCheckerObj.NameLabel(contactName);  // to check that if any digit is present in string or not
                    try
                    {
                        if (isValidName) break;
                        else throw new Exception("Name can only include english letters and must be of length greater than 0 and less than 255");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                bool output = isValidCheckerObj.NameExists(contactName, addressBookObj);
                try{

                    if (output == true)
                    {
                        Console.WriteLine("****************************************************");
                        throw new Exception("Name is already present");
                    }
                    else break;
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("****************************************************");
                }
            }

            string organisationName;

            while (true)
            {
                Console.Write("Enter the name of your Organisation: ");
                organisationName = Console.ReadLine();
                try
                {
                    if (organisationName.Length < 255) break;
                    else throw new Exception("Name Of the organisation must be of length greater than 0 and less than length 255");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            PhoneNumber phoneNumberObj = PhoneDetailsFromUser();

            Address addressObj = AddressDetailsFromUser();

            Contact contactObj = new Contact(contactName, organisationName, phoneNumberObj, addressObj);

            Console.WriteLine("****************************************************");

            return contactObj;
        }

        /// <summary>
        /// Method to take input from user regarding phone number
        /// </summary>
        /// <returns> it returns newly generated object of Phonenumber class </returns>
        internal PhoneNumber PhoneDetailsFromUser()
        {
            string phoneNumber;
            IsValidChecker isValidCheckerObj = new IsValidChecker();
            while (true)
            {
                Console.Write("Enter the Phone Number: ");
                phoneNumber = Console.ReadLine();
                bool output = isValidCheckerObj.phoneNumberCheck(phoneNumber);
                if (output == true) break;
            }

            string phoneLabel;
            while (true)
            {
                Console.Write("Enter the Label for you Phone Number Eg:- Work,Home : ");
                 phoneLabel = Console.ReadLine();
                bool isValidLabel = isValidCheckerObj.NameLabel(phoneLabel);
                try
                {
                    if (isValidLabel) break;
                    else throw new Exception("Label must contain english letters only and length must be less than 255");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return new PhoneNumber(phoneLabel, "+91"+phoneNumber);
        }

        /// <summary>
        /// Method to take input from user regarding address
        /// </summary>
        /// <returns> it returns the newly generated object of address class </returns>
        internal Address AddressDetailsFromUser()
        {
            Console.Write("Enter your Address: ");
            string address = Console.ReadLine();
            string addressLabel;
            IsValidChecker isValidCheckerObj = new IsValidChecker();
            while (true)
            {
                Console.Write("Enter the Label for your address Eg:- Office,Home :");
                addressLabel = Console.ReadLine();
                bool isValidLabel = isValidCheckerObj.NameLabel(addressLabel);
                try
                {
                    if (isValidLabel) break;
                    else throw new Exception("Address label must contain only englih letter and must be of length less than 255");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return new Address(addressLabel, address);
        }

        /// <summary>
        /// Method to take input from user regarding update contact
        /// </summary>
        /// <returns> it returns the name of contact which you want to update. </returns>
        internal string UpdateDetailsFromUser()
        {
            Console.Write("Enter the name of contact which you want to update : ");
            string name = Console.ReadLine();
            return name;
        }

    }
}
