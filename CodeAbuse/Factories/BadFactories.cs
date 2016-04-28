using System;

namespace CodeAbuse.Factories
{
    public class Customer
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public bool ValidatePhoneNumber()
        {
            //if PhoneNumber is not valid
            return false;
        }
    }

    public class CustomerRepository
    {
        public void Save(Customer customer)
        {
            if (!customer.ValidatePhoneNumber())
            {
                throw new ArgumentException();
            }
            // Save the customer
        }
    }

    public class BadFactoriesExample
    {
        public void ExpectedProcedure()
        {
            var customerRepository = new CustomerRepository();
            var customer = new Customer { PhoneNumber = "555-867-5309" };
            customerRepository.Save(customer);
        }

        public void AbusedProcedure()
        {
            var customerRepository = new CustomerRepository();
            var customer = new Customer { PhoneNumber = "blarg" };

            // This will throw an exception because PhoneNUmber must be set to a valid phone number
            customerRepository.Save(customer);
        }
    }
}