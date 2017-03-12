using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TPP.Concurrency.Deadlock {

    public class Account {
        private decimal balance;
        private string accountNumber;

        public Account(string accountNumber, decimal balance = 0) {
            this.balance = balance;
            this.accountNumber = accountNumber;
        }

        public string AccountNumber { get { return this.accountNumber; } }

        /// <summary>
        /// Withdraw from the account
        /// <param name="amount">The amount of money to be withdrew</param>
        /// <returns>Whether the transaction was successful</returns>
        /// </summary>
        public bool Withdraw(decimal amount) {
            if (this.balance < amount)
                return false;
            this.balance -= amount;
            return true;
        }

        /// <summary>
        /// Credit in the account
        /// <param name="amount">The amount of money to be credited in the account</param>
        /// </summary>
        public void Credit(decimal amount) {
            this.balance += amount;
        }


        /// <summary>
        /// Transfer money from the current account (this) to the destination parameter
        /// <param name="destination">The detination account where the money is going to be transferred to</param>
        /// <param name="amount">The amount of many to be transferred</param>
        /// <returns>Whether the transaction was successfully done</returns>
        /// </summary>
        public bool Transfer(Account destination, decimal amount) {
            lock (this) {
                lock (destination) {
                    Thread.Sleep(100); // Simulates the processing...
                    if (this.Withdraw(amount)) {
                        destination.Credit(amount);
                        return true;
                    }
                    else
                        return false;
                }
            }
        }


    

    }
}
