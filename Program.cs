using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Codeforces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfIterations = int.Parse(Console.ReadLine());

            List<OperandsСalculator> operandsСalculators = new List<OperandsСalculator>();

            for (int i = 0; i < numberOfIterations; i++)
            {
                string line = Console.ReadLine();

                if (OperandsСalculator.TryParse(line, out OperandsСalculator value))
                {
                    operandsСalculators.Add(value);
                }
            }

            Console.WriteLine();

            for (int i = 0; i < operandsСalculators.Count; i++)
            {
                Console.WriteLine(operandsСalculators[i].GetResult());
            }
        }
    }

    class OperandsСalculator
    {
        public OperandsСalculator(int firstValue, int secondValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
        }

        public int FirstValue { get; private set; }

        public int SecondValue { get; private set; }

        public int GetResult()
        {
            return FirstValue + SecondValue;
        }

        public static bool TryParse(string line, out OperandsСalculator value)
        {
            const int numberOfOperands = 2;
            value = null;

            if (string.IsNullOrEmpty(line))
            {
                return false;
            }

            string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != numberOfOperands)
            {
                return false;
            }

            int a = 0;
            int b = 0;

            if (int.TryParse(parts[0], out a) && int.TryParse(parts[1], out b))
            {
                value = new OperandsСalculator(a, b);
                return true;
            }

            return false;
        }
    }
}
