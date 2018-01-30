/*
 * Program: InClass5
 * Porpose: Generate a Program to
 * reverse a enter's name and to 
 * validade SIN number
 * 
 * Written by Daiana Arantes
 * 
 * January 2018
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inClass5
{
    class Program
    {
        //method to revert name
        private static void RevertUserNAme()
        {
            string userName = null;
            string revertedName = "";
            Console.Write("\nPlease insert your name: ");
            userName = Console.ReadLine();

            string[] reverseName = userName.Split(' ');

            for (int i = reverseName.Length; i > 0; i--)
            {
                revertedName += reverseName[i - 1];

                if (i > 1)
                {
                    revertedName += " ";
                }
            }
            Console.WriteLine();
            Console.WriteLine(revertedName);
        }
        static void Main(string[] args)
        {

            RevertUserNAme();

            int[] validateDigits = new int[9] { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int[] userSinNumber;
            string receiveSinNumber;
            int[] validationResult = new int[9];
            int result = 0;

            string validationResultLarge;
            int newValidationResult = 0;

            do
            {
                Console.Write("\nPlease insert your SIN Number: ");
                receiveSinNumber = Console.ReadLine();

                userSinNumber = new int[9];

                //split Sin Number and save inside userSinNumber
                for (int i = 0; i < receiveSinNumber.Length; i++)
                {
                    //get a char by a specifc position and 
                    //convert to string and convert to int
                    userSinNumber[i] = int.Parse(receiveSinNumber[i].ToString());
                }

                //validate id sin number is valid
                for (int i = 0; i < userSinNumber.Length; i++)
                {
                    //multiply each position of userSinNumber with validateDigits
                    validationResult[i] = userSinNumber[i] * validateDigits[i];

                    //Validate if there is two digits
                    if (validationResult[i] > 9)
                    {
                        newValidationResult = 0;
                        validationResultLarge = validationResult[i].ToString();

                        //sun to digits
                        for (int j = 0; j < validationResultLarge.Length; j++)
                        {
                            //get a char by a specifc position and convert to
                            //string and convert to int
                            newValidationResult += 
                                int.Parse(validationResultLarge[j].ToString());
                        }

                        validationResult[i] = newValidationResult;
                    }
                }

                //Validate if Sin is valid or not
                foreach (int validationItem in validationResult)
                {
                    result += validationItem;
                }

                if (result % 10 == 0)
                {
                    Console.WriteLine("\nValid SIN\n");
                }
                else
                {
                    Console.WriteLine("\nInvalid SIN\n");
                }

            } while (result % 10 != 0);
        }
    }
}
