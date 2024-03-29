﻿using System;

namespace _07Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split(" ");

            string names = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];

            var firstCustomTuple = new MyTuple<string, string>(names, address);

            string[] personBeerInfo = Console.ReadLine()
                .Split(" ");

            string personName = personBeerInfo[0];
            int litersOfBeer = int.Parse(personBeerInfo[1]);

            var secondCustomTuple = new MyTuple<string, int>(personName, litersOfBeer);

            string[] numbers = Console.ReadLine()
                .Split(" ");

            int firstNumber = int.Parse(numbers[0]);
            double secondNumber = double.Parse(numbers[1]);

            var thirdCustomTuple = new MyTuple<int, double>(firstNumber, secondNumber);

            Console.WriteLine(firstCustomTuple);
            Console.WriteLine(secondCustomTuple);
            Console.WriteLine(thirdCustomTuple);
        }
    }
}