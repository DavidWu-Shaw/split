﻿using Split.Business;
using System;
using System.IO;

namespace Split
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args == null || args.Length == 0 )
            {
                Console.WriteLine("Please specify a filename.");
                return;
            }
            string inputFile = args[0];
            string outputFile = inputFile + ".out";

            try
            {
                StreamReader sr = new StreamReader(inputFile);
                // Get the first line as the number of members
                int memberCount = GetIntegerLine(sr);
                // Initilize TripGroup class        
                TripGroup tripGroup = new TripGroup();
                do
                {
                    Trip trip = new Trip();
                    tripGroup.AddTrip(trip);
                    // Loop to add members
                    for (int index = 0; index < memberCount; index++)
                    {
                        Member member = new Member();
                        trip.AddMember(member);
                        // Get the number of expenses for current member
                        int expenseCount = GetIntegerLine(sr);
                        // Loop to add expenses
                        for (int expenseIndex = 0; expenseIndex < expenseCount; expenseIndex++)
                        {
                            decimal amount = GetDecimalLine(sr);
                            member.AddCharge(amount);
                        }
                    }
                    // Get the number of members for next trip
                    memberCount = GetIntegerLine(sr);
                }
                while (memberCount != 0);
                //Close the read file
                sr.Close();
                // Start to output billing data
                StreamWriter streamWriter = new StreamWriter(outputFile);
                // Triger calculation
                tripGroup.Calculate();
                // Call Output method to output data
                tripGroup.Output(streamWriter);
                streamWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private static int GetIntegerLine(StreamReader sr)
        {
            string line = sr.ReadLine();
            return Convert.ToInt32(line);
        }
        private static decimal GetDecimalLine(StreamReader sr)
        {
            string line = sr.ReadLine();
            return Convert.ToDecimal(line);
        }
    }
}
