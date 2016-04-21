using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAbuse.Factories
{
    class BadFactories
    {
        public class CustomRepository
        {
            public void Save(Customer customer)
            {
                if (!customer.Validate())
                {
                    throw new ArgumentException();
                }
            }
        }

        public class Customer
        {
            private string _phoneNumber;
            public bool Validate()
            {
                //if PhoneNumber is not valid
                return false;
            }
        }
    }
}
