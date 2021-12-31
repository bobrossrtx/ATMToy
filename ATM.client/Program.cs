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

            //var cash = 200.00m;
            //bobrossrtx.DepositMoney(cash);

            //bobrossrtx.TransferMoney(jeremy, 10.50m);
            //bobrossrtx.GetBalance();
            //jeremy.GetBalance();

            // Interface
            while (true)
            {
                // Print Banner
                Console.WriteLine("------------------------");
                Console.WriteLine("    ATM - Bobrossrtx    ");
                Console.WriteLine("------------------------");

                // Login
                bool loggedIn = false;

                Console.WriteLine("Login:");
                Console.Write(" Account Number: ");
                string accountNumberString = Console.ReadLine();
                Account account = new Account();
                Guid accountNumber;
                Guid x;

                if (Guid.TryParse(accountNumberString, out x))
                {
                    accountNumber = Guid.Parse(accountNumberString);
                    Console.Write(" Password: ");
                    string password = Console.ReadLine();
                    account = bank.FindAccount(accountNumber);
                    loggedIn = account.Login(accountNumber, password);
                }
                else loggedIn = false;


                if (loggedIn)
                {
                    Console.WriteLine($"Logged in as {account.Username}");

                optionsInterface:
                    // Print Options
                    Console.WriteLine("(1) - Deposit    (4) - Transfer");
                    Console.WriteLine("(2) - Withdraw");
                    Console.WriteLine("(3) - Balance    (0) - Exit");

                    Console.Write("> ");
                    string input = Console.ReadLine();

                    decimal ammount = 0;

                    switch (input)
                    {
                        case "1":
                            Console.Write("Enter Ammount: ");
                            ammount = Convert.ToDecimal(Console.ReadLine());
                            account.DepositMoney(ammount);
                            goto optionsInterface;

                        case "2":
                            Console.Write("Enter Ammount: ");
                            ammount = Convert.ToDecimal(Console.ReadLine());
                            account.WithdrawMoney(ammount);
                            goto optionsInterface;

                        case "3":
                            account.GetBalance();
                            goto optionsInterface;

                        case "4":
                            Console.Write("Account Number: ");
                            string transferAccountNumberString = Console.ReadLine();
                            Account transferAccount = new Account();
                            Guid z;

                            if (Guid.TryParse(transferAccountNumberString, out z))
                            {
                                transferAccount = bank.FindAccount(Guid.Parse(transferAccountNumberString));
                                if (transferAccount is null) goto optionsInterface;
                                Console.Write("Enter Ammount: ");
                                ammount = Convert.ToDecimal(Console.ReadLine());
                                account.TransferMoney(transferAccount, ammount);
                            }
                            else Console.WriteLine("Invalid Account Number");
                            goto optionsInterface;

                        case "0":
                            break;
                        default:
                            goto optionsInterface;
                    }
                }
                else Console.WriteLine("Invalid Credentials");
            }
        }
    }
}