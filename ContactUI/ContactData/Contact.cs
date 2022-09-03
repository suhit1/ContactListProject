using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactData
{
    [Serializable]
    public class Contact
    {

        /// <summary>
        /// Constructor for storing the values in properties
        /// </summary>
        /// <param name="name"> string </param>
        /// <param name="organisation">string</param>
        /// <param name="phoneObj">PhoneNumber class object</param>
        /// <param name="addressObj">Address class object</param>
        public Contact(string name, string organisation, PhoneNumber phoneObj, Address addressObj)
        {
            _name = name;                                           // storing the name
            _organisation = organisation;                           // storing the organisation's name
            _phoneNumbers = new List<PhoneNumber>();                // initialising the new list for PhoneNumber
            _phoneNumbers.Add(phoneObj);                            // storing the list of a phone number of a contact
            _addresses = new List<Address>();                       // initialising the new list
            _addresses.Add(addressObj);                            // storing the list of address of a contact
        }

        /// <summary>
        ///  for holding the name of Contact
        /// </summary>
        private string _name { get; set; }

        /// <summary>
        /// for holding the organisation's name of contact
        /// </summary>
        private string _organisation { get; set; }

        /// <summary>
        /// for holding the list of phone numbers of a contact
        /// </summary>
        private List<PhoneNumber> _phoneNumbers { get; set; }

        /// <summary>
        /// for holding the address of the contact
        /// </summary>
        private List<Address> _addresses { get; set; }

        // Getters Method

        /// <summary>
        ///  to get the value of name of contact
        /// </summary>
        /// <returns>returns name of a object</returns>
        public string getName() { return _name; }

        /// <summary>
        /// to get the organisation name of contact
        /// </summary>
        /// <returns>returns organisation name of an object</returns>
        public string getOrganisation() { return _organisation; }

        /// <summary>
        /// to get the list of phonenumbers of a contact
        /// </summary>
        /// <returns>returns list of phonenumber of a contact</returns>
        public List<PhoneNumber> getPhoneNumbers() { return _phoneNumbers; }

        /// <summary>
        ///  to get the list of addresses of a contact
        /// </summary>
        /// <returns>returns list of address of a contact</returns>
        public List<Address> getAddresses() { return _addresses; }

        // Setters Method

        /// <summary>
        /// to set the new value of name
        /// </summary>
        /// <param name="newName">name</param>
        public void setName(string newName) { _name = newName; }

        /// <summary>
        /// to set the new value of Organisation name
        /// </summary>
        /// <param name="newOrganisationName">organisation name</param>
        public void setOrganisationName(string newOrganisationName) { _organisation = newOrganisationName;  }

        /// <summary>
        /// to set the new updated value of phone numbers
        /// </summary>
        /// <param name="choice"> index at which object is present in list </param>
        /// <param name="newPhoneNumber"> new phone number </param>
        public void setPhoneNumber(int choice,string newPhoneNumber)
        {
            _phoneNumbers[choice-1].setPhoneNumber(newPhoneNumber);   // choice-1 because of the 0 based indexing
        }

        /// <summary>
        /// to set the new updated value of phone label
        /// </summary>
        /// <param name="choice">index at which object is present in list</param>
        /// <param name="newPhoneLabel">new phone label</param>
        public void setPhoneNumberLabel(int choice,string newPhoneLabel)
        {
            _phoneNumbers[choice - 1].setPhoneNumberLabel(newPhoneLabel);
        }

        /// <summary>
        /// to set the new updated value of address
        /// </summary>
        /// <param name="choice">index at which object is present in list</param>
        /// <param name="newAddress">new address</param>
        public void setAddress(int choice,string newAddress)
        {
            _addresses[choice - 1].setAddress(newAddress);
        }

        /// <summary>
        /// to set the new updated value of address label
        /// </summary>
        /// <param name="choice">index at which object is present in list</param>
        /// <param name="newAddressLabel">new address label</param>
        public void setAddressLabel(int choice, string newAddressLabel)
        {
            _addresses[choice - 1].setAddressLabel(newAddressLabel);
        }

        //Adders

        /// <summary>
        /// to add phonenumber of an existing contact
        /// </summary>
        /// <param name="phoneNumber">phone number</param>
        public void addPhoneNumber(PhoneNumber phoneNumber)
        {
            _phoneNumbers.Add(phoneNumber);
            Console.WriteLine("****************************************************");
            Console.WriteLine("Phone Number Successfully Added!  ");
            Console.WriteLine("****************************************************");
        }

        /// <summary>
        /// to add adress of an existing contact
        /// </summary>
        /// <param name="address">address</param>
        public void addAddress(Address address)
        {
            _addresses.Add(address);
            Console.WriteLine("****************************************************");
            Console.WriteLine("Address Successfully Added!  ");
            Console.WriteLine("****************************************************");
        }
    }
}
