using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotDAL;
using AutoLotDAL.ConnectedLayer;
using AutoLotDAL.Models;

using System.Data;
using System.Configuration;
using static System.Console;


namespace AutoLotCUIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** The AutoLot Console UI *****\n");

            string connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            bool userDone = false;
            string userCommand = "";

            InventoryDAL invDAL = new InventoryDAL();
            invDAL.OpenConnection(connectionString);

            try
            {
                ShowInstructions();
                do
                {
                    Write("\nPlease enter your command: ");
                    userCommand = ReadLine();
                    WriteLine();
                    switch (userCommand?.ToUpper()??"")
                    {
                        case "I":
                            InsertNewCar(invDAL);
                            break;
                        case "U":
                            UpdateCarPetName(invDAL);
                            break;
                    }
                }
            }

        }

        private static void ShowInstructions()
        {
            WriteLine("I: Inserts a new car.");
            WriteLine("U: Updates an existing car.");
            WriteLine("D: Deletes an existing car.");
            WriteLine("L: Lists current inventory.");
            WriteLine("S: Shows these instructions.");
            WriteLine("P: Looks up pet name.");
            WriteLine("Q: Quits program.");
        }
    }
}
