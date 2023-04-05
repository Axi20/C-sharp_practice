using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read data from txt 
            List<DataStorage> dataStorage = new List<DataStorage>();
            List<Numbers> numbers = new List<Numbers>();
            string[] lines = File.ReadAllLines("sorsolas.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                DataStorage numbersObject = new DataStorage(values[0], values[1], values[2], values[3], values[4], values[5]);
                dataStorage.Add(numbersObject);
            }

            // How many numbers are in the list
            int pc = 0;
            for (int i = 1; i < 91; i++)
            {
                foreach (var item in dataStorage)
                {
                    pc += (i == item.firstNumber) ? 1 : 0;
                    pc += (i == item.secondNumber) ? 1 : 0;
                    pc += (i == item.thirdNumber) ? 1 : 0;
                    pc += (i == item.fourthNumber) ? 1 : 0;
                    pc += (i == item.fifthNumber) ? 1 : 0;    
                }
                Numbers numbersObject = new Numbers(i, pc);
                numbers.Add(numbersObject);
                pc = 0;
            }

            // Task 2
            Console.Write("Give a number between 1-90: ");
            string userInput = Console.ReadLine();
            int week = 0;
            if(int.TryParse(userInput, out week))
            {
                if(week > 0 && week < 53)
                { 
                    foreach (var item in dataStorage)
                    {
                        if(item.week == week)
                        {
                            Console.WriteLine($"Task 2: {item.week}, {item.firstNumber}, {item.secondNumber}, {item.thirdNumber}, {item.fourthNumber}, {item.fifthNumber}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The number is not in the expected range!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input type!");
            }

            // Task 3
            int minPc = int.MaxValue;
            int minNumber = 0;
            foreach (var item in numbers)
            {
                if (minPc > item.pieces)
                {
                    minPc = item.pieces;
                    minNumber = item.number;
                }
            }
            Console.WriteLine($"Task 3: {minNumber} {minPc}");

            // Task 4
            int evenSum = 0;
            foreach (var item in numbers)
            {
                if ( item.number % 2 == 0)
                {
                    evenSum += item.pieces;
                }
            }
            Console.WriteLine($"Task 4: {evenSum}");

            // Task 5-6
            int number5 = 0;
            int number46 = 0;
            foreach (var item in numbers)
            {
                if(item.number == 5)
                {
                    number5 = item.pieces;
                }
                if( item.number == 46)
                {
                    number46 = item.pieces;
                }
            }
            Console.WriteLine($"Task 5-6 \n 5: {number5} 46: {number46}");

            // Task 7.
            foreach (var item in numbers)
            {
                Console.WriteLine(item.number + ";" + item.pieces);
            }

        }
    }
}
