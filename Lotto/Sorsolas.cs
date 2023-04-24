using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    internal class Sorsolas
    {
        public int week;
        public int firstNumber;
        public int secondNumber;
        public int thirdNumber;
        public int fourthNumber;
        public int fifthNumber;

        public Sorsolas(string week, string firstNumber, string secondNumber, string thirdNumber, string fourthNumber, string fifthNumber)
        {
            this.week = int.Parse(week);
            this.firstNumber = int.Parse(firstNumber);
            this.secondNumber = int.Parse(secondNumber);
            this.thirdNumber = int.Parse(thirdNumber);
            this.fourthNumber = int.Parse(fourthNumber);
            this.fifthNumber = int.Parse(fifthNumber);
        }
    }
}
