using System;
using System.Threading.Tasks;

namespace CodeAbuse.Monads
{
    class MonadStart
    {
        public class ErrorMonad<T>
        {
            private readonly T _value;
            private readonly string _error;

            public ErrorMonad(T value, string error)
            {
                _value = value;
                _error = error;
            }

            public static ErrorMonad<T> Error(string error)
            {
                return new ErrorMonad<T>(default(T), error);
            }

            public static ErrorMonad<T> Valid(T value)
            {
                return new ErrorMonad<T>(value, null);
            }

            public ErrorMonad<T> OnError(Action<string> onError)
            {
                if (_error != null)
                {
                    onError(_error);
                }

                return this;
            }

            public ErrorMonad<T> OnValid(Action<T> onValid)
            {
                if (_error == null)
                {
                    onValid(_value);
                }

                return this;
            }

            public ErrorMonad<U> AndThen<U>(Func<T, ErrorMonad<U>> step)
            {
                if (_error != null)
                {
                    return ErrorMonad<U>.Error(_error);
                }
                else
                {
                    return step(_value);
                }
            }
        }

        public class Customer
        {
            public int CustomerId;

            private readonly string _name;
            private readonly string _phoneNumber;

            public Customer(string name, string phoneNumber)
            {
                _name = name;
                _phoneNumber = phoneNumber;
            }

            public static ErrorMonad<Customer> Create(string name, string phoneNumber)
            {
                if (ValidPhoneNumber.IsMatch(phoneNumber))
                {
                    return ErrorMonad<Customer>.Valid(new Customer(name, phoneNumber));
                }
                else
                {
                    return ErrorMonad<Customer>.Error("THERE WAS AN ERRORRR");
                }
            }
        }

        public class CustomerRepository
        {
            public ErrorMonad<int>  Save(Customer customer)
            {
                if (Successful(customer))
                {
                    return ErrorMonad<int>.Valid(customer.CustomerId);
                }
                else
                {
                    return ErrorMonad<int>.Error("Failed to Save Customer");
                }
            }

            private bool Successful(Customer customer)
            {
                return true;
            }
        }

        public class ValidPhoneNumber
        {
            public static bool IsMatch(string phoneNumber)
            {
                //figure out if it's a match
                return true;
            }
        }

        public void ShowAndTell()
        {
<<<<<<< HEAD
            var name = "Bogart";
            var phoneNumber = "6675309";

            var repository = new CustomerRepository();

            Customer.Create(name, phoneNumber).AndThen(customer => repository.Save(customer)).OnError(ShowError).OnValid(ReturnCustomerId);
        }

        private void ShowError(string errorMessage)
        {
            throw new Exception(errorMessage);
        }

        private void ReturnCustomerId(int customerId)
        {
            Console.Write(customerId);
=======
            var name = "Jenny";
            var phoneNumber = "8675309";
            Customer.Create(name, phoneNumber);
>>>>>>> 4f140877dd676bf89bf15cdf1b078bc858810e4f
        }
    }
}
