using System;
using ContactData;
using System.Collections.Generic;
using log4net;
using System.IO;

namespace ContactUI
{
    
    internal class ContactList
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            try
            {
                Log.Info("This is start of dowork");

                Log.Info("This is end of do work");
            }
            catch (Exception e)
            {
                Log.Error("Error occured");
                Log.Error(e.Message);
            }

            /// calling the  GetoptionsFromUser class method to get options from user
            new GetOptionsFromUser().GetOptions();

        }
    }
}
