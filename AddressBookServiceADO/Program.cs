﻿using System;

namespace AddressBookServiceADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome To Address Book Service!");
            AddressBookOperations addressBookOperations = new AddressBookOperations();
            addressBookOperations.Operations();
        }
    }
}
