using System;

namespace ContactData
{
    public class PhoneNumber
    {

        /// <summary>
        /// Constructor for storing the values in properties
        /// </summary>
        /// <param name="label">label</param>
        /// <param name="phonenumber">phonenumber</param>
        public PhoneNumber(string label, string phonenumber)
        {
            _label = label;
            _phoneNumber = phonenumber;
        }

        /// <summary>
        /// For holding the label of phonenumber
        /// </summary>
        private string _label { get; set; }

        /// <summary>
        /// for holding the phonenumber
        /// </summary>
        private string _phoneNumber { get; set; }

        // Getters

        /// <summary>
        /// to get the value of phone number of a contact
        /// </summary>
        /// <returns>returns the phonenumber of a phonnumber object</returns>
        public string getPhoneNumber() { return _phoneNumber; }

        /// <summary>
        /// to get the value of label of a phone number of a contact
        /// </summary>
        /// <returns>returns the phonenumber label of a phonnumber object</returns>
        public string getLabel() { return _label; }

        // Setters

        /// <summary>
        /// to update the value of an existing contact number
        /// </summary>
        /// <param name="newPhoneNumber">new phone number</param>
        public void setPhoneNumber(string newPhoneNumber)
        {
            _phoneNumber = newPhoneNumber;
        }

        /// <summary>
        ///  to update the value of label of an existing contact number
        /// </summary>
        /// <param name="newPhoneLabel">phone number label</param>

        public void setPhoneNumberLabel(string newPhoneLabel)
        {
            _label = newPhoneLabel;
        }
    }
}
