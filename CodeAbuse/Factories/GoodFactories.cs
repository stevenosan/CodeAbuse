using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CodeAbuse.Factories
{
    class GoodFactories
    {
        public static class CustomerFactory
        { 
            public class Customer
            {
                private string _name;
                private string _phoneNumber;

                private Customer(string name, string phoneNumber)
                {
                    _name = name;
                    _phoneNumber = phoneNumber;
                }
                public static Customer Create(string name, string phoneNumber)
                {
                    if (ValidatePhoneNumber(phoneNumber))
                    {
                        return new Customer(name, phoneNumber);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            private static bool ValidatePhoneNumber(string phoneNumber)
            {
                //validate the phone number
                return true;
            }
        }

        public void AddSteve()
        {
            var steve = CustomerFactory.Customer.Create("steve", "453-123-4567");
        }
    }
}
