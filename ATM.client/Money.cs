//  Money.cs - 30/12/2021
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
    public class Money
    {
        public string Currency { get; init; }
        public decimal Value { get; set; }

        public Money(string currency)
        {
            Currency = currency;
        }

        public Money(string currency, decimal value)
        {
            Currency = currency;
            Value = value;
        }

        public bool Transaction(Account from, Account to, decimal value)
        {
            if (value < 1.0m)
            {
                Console.WriteLine("Transaction Failed:");
                Console.WriteLine($"  A transaction must consist of a value over {Currency}1.00");
            }
            else
            {
                to.Balance.Value += value;
                from.Balance.Value -= value;
                Console.WriteLine($"Transaction Complete: ({from.Username}->{to.Username})");
            }
            return false;
        }
    }
}
