using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactData
{
    public class Address
    {
        /// <summary>
        /// Constructor for storing the values in properties
        /// </summary>
        /// <param name="label"> it takes label of address </param>
        /// <param name="address"> it takes address  </param>
        public Address(string label, string address)
        {
            _label = label;
            _address = address;
        }

        /// <summary>
        /// for holding the vale of address label
        /// </summary>
        private string _label { get; set; }

        /// <summary>
        /// for holding the value of address
        /// </summary>
        private string _address { get; set; }

        // Getters

        /// <summary>
        /// to get the value of address of a contact
        /// </summary>
        /// <returns> it returns the value of address for a contact object </returns>
        public string getAddress() { return _address; }

        /// <summary>
        /// to get the value of label of the address of contact
        /// </summary>
        /// <returns> it returns the valye of address label for a contact object </returns>
        public string getLabel() { return _label; }

        // Setters

        /// <summary>
        /// to set the updated value of address of an existing contact
        /// </summary>
        /// <param name="newAddress"> takes address as parameter </param>
        public void setAddress(string newAddress)
        {
            _address = newAddress;
        }

        /// <summary>
        /// to set the updated value of label of an existing address
        /// </summary>
        /// <param name="newAddressLabel"> takes address label as parameter </param>
        public void setAddressLabel(string newAddressLabel)
        {
            _label = newAddressLabel;
        }
    }
}
