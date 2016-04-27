using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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

            public ErrorMonad<U> AndThen<U>(Func<TaskFactory, ErrorMonad<U>> step)
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

            public static Customer Create(string name, string phoneNumber)
            {
                if (ValidPhoneNumber.IsMatch(phoneNumber))
                {
                    return ErrorMonad<Customer>.Valid(Customer.Create(name, phoneNumber));
                }
                else
                {
                    return ErrorMonad<Customer>.Error("Invalid PhoneNumber");
                }
            }
        }

        public class CustomerRepository
        {
            public ErrorMonad<int> Save(Customer customer)
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
            var name = "Jenny";
            var phoneNumber = "8675309";
            Customer.Create(name, phoneNumber).
        }
    }
}
