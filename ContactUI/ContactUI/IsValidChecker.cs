using System;
using ContactData;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ContactUI
{
    public class IsValidChecker
    {
        /// <summary>
        /// Method to check Phone Number is Valid or not
        /// </summary>
        /// <param name="number"> string </param>
        /// <returns> it will return true if length of phone number is 10 otherwise false </returns>
        public  bool phoneNumberCheck(string number)
        {

            bool containsLetter = number.Any(x => char.IsLetter(x));

            try
            {
                if (number.Length != 10 || containsLetter == true)
                {
                    throw new Exception("PhoneNumber must be of length 10 and must include digits only.");
                }
                else
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Method to check name exists already exists or not
        /// </summary>
        /// <param name="name"> Name to check that it exists or not </param>
        /// <param name="addressBookObj"> addressBookObj take the object of addressbook </param>
        /// <returns> it will return true if name exists otherwise false </returns>
        public  bool NameExists(string name, AddressBook addressBookObj)
        {
            bool output = addressBookObj.contactList.Any(x => x.getName().ToLower().Equals(name.ToLower()));
            if (output == true) return true;
            return false;
        }

        /// <summary>
        /// Method to check name and labels are valid or not
        /// </summary>
        /// <param name="nameLabel"> Takes string name label as parameter </param>
        /// <returns> it returns true if label is valid else false </returns>
        public  bool NameLabel(string nameLabel)
        {

            bool isDigit = nameLabel.Any(x => char.IsDigit(x));
            if (isDigit == false && nameLabel.Length < 255 && nameLabel.Length>0) return true;
            return false;

        }
    }
}
