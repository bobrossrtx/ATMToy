//  Account.cs - 30/12/2021
//  owenboreham<owenkadeboreham@gmail.com>
//
//  Copyright 2021  owenboreham
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
// 	http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//
using System;

namespace ATM.Client
{
    public class Account
    {
        private bool LoggedIn { get; set; }
        private string Password { get; set; }
        public Guid AccountNumber { get;  init; }
        public string Username { get; private set; }
        public Money Balance { get; private set; }
        private Bank _bank { get; init; }

        // Dummy Constructor
        public Account() { }

        public Account(Bank bank, string password, string username)
        {
            this.Password = password;
            this.AccountNumber = Guid.NewGuid();
            this.Username = username;
            this.Balance = new Money(bank.Currency, 0.00m);
            this._bank = bank;

            this._bank.AddAccount(this);
            Console.WriteLine($"Account Created - {Username}");
            Console.WriteLine($"Your Account Number: {AccountNumber} (Remember to write this down)");
        }

        public void TransferMoney(Account to, decimal ammount)
        {
            Balance.Transaction(this, to, ammount);
        }

        public void DepositMoney(decimal ammount)
        {
            Balance.Value += ammount;
            Console.WriteLine($"Successfully deposited {_bank.Currency}{ammount} into bank account.");
            _bank.UpdateTotalValue(this, 1, ammount);
        }

        public decimal WithdrawMoney(decimal ammount)
        {
            Balance.Value -= ammount;
            Console.WriteLine($"Successfully withdrew {_bank.Currency}{ammount} from bank account.");
            _bank.UpdateTotalValue(this, 2, ammount);
            return ammount;
        }

        public bool SetPassword(string password, string oldPassword)
        {
            if (!LoggedIn) return false;

            if (oldPassword != Password)
            {
                Console.WriteLine("Error: Incorrect password");
                return false;
            }

            Password = password;
            return true;
        }

        public bool SetUsername(string username)
        {
            if (!LoggedIn) return false;

            Username = username;
            return true;
        }

        public bool Login(Guid accountNumber, string password)
        {
            if (accountNumber == AccountNumber && password == Password) LoggedIn = true;
            else LoggedIn = false;
            return LoggedIn;
        }

        public bool Logout()
        {
            LoggedIn = false;
            return true;
        }

        public decimal GetBalance()
        {
            Console.WriteLine($"{this.Username} ({this.AccountNumber}) has {Balance.Currency}{Balance.Value}");
            return Balance.Value;
        }
    }
}
