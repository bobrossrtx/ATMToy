//  Bank.cs - 30/12/2021
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
using System.Collections.Generic;

namespace ATM.Client
{
    public class Bank : Money
    {
        public object MyProperty { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
        private Money TotalValue { get; set; }

        public Bank(string currency, decimal value) : base(currency)
        {
            TotalValue = new Money(currency, value);
#if DEBUG
            Console.WriteLine("Bank Created");
#endif
        }

        public void AddAccount(Account account)
        {
            if (account != null)
            {
#if DEBUG
                Console.WriteLine($"Adding Account: {account.AccountNumber}");
#endif
                Accounts.Add(account);
                UpdateTotalValue(account, 1, 0);
            }
        }

        public Account FindAccount(Guid accountNumber)
        {
            foreach (var account in Accounts)
            {
                if (account.AccountNumber == accountNumber)
                    return account;
            }
            Console.WriteLine("No account found");
            return null;
        }

        /**
         * type:
         *  - 1     = deposit
         *  - 2     = withdraw
         *  - any   = print
         */
        public void UpdateTotalValue(Account account, int type, decimal change)
        {
            if (type == 1)
            {
                TotalValue.Value -= change;
                TotalValue.Value += account.GetBalance();
            }
            else if (type == 2) TotalValue.Value -= change;
#if DEBUG
            Console.WriteLine($"New Total Bank Balance: {Currency}{TotalValue.Value}");
#endif
        }
    }
}
