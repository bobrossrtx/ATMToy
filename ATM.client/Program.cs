//  Program.cs - 30/12/2021
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
using System;

namespace ATM.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank("$", 500.00m);
            var bobrossrtx = new Account(bank, "password", "bobrossrtx");
            var jeremy = new Account(bank, "12345", "jeremy");

            var cash = 200.00m;
            bobrossrtx.DepositMoney(cash);

            bobrossrtx.TransferMoney(jeremy, 10.50m);
            bobrossrtx.GetBalance();
            jeremy.GetBalance();
        }
    }
}