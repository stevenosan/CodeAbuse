using System;

namespace CodeAbuse.Factories
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
                if (!ValidatePhoneNumber(phoneNumber))
                {
                    throw new ArgumentException();
                }
                return new Customer(name, phoneNumber);
            }
        }

        private static bool ValidatePhoneNumber(string phoneNumber)
        {
            //validate the phone number
            return true;
        }
    }

    public class CustomerRepositoryUsingFactory
    {
        public void Save(CustomerFactory.Customer customer)
        {
            // Save the customer
        }
    }

    public class GoodFactoriesExample
    {
        public void NewWayToCall()
        {
            var customerRepository = new CustomerRepositoryUsingFactory();
            var steve = CustomerFactory.Customer.Create("steve", "453-123-4567");
            customerRepository.Save(steve);
        }
    }
}