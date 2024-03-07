using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public static class BobsRental
    {
        //Table of values
        private static readonly Dictionary<int, List<int>> Values = new Dictionary<int, List<int>>()
        {
            {1,  new List<int>() {50, 49, 48, 45} },
            {2,  new List<int>() {50, 49, 48, 45} },
            {3,  new List<int>() {50, 49, 48, 45} },
            {4,  new List<int>() {51, 50, 49, 48} },
            {5,  new List<int>() {52, 51, 50, 50} },
            {6,  new List<int>() {55, 54, 53, 52} },
            {7,  new List<int>() {55, 54, 53, 52} },
            {8,  new List<int>() {55, 54, 53, 52} },
            {9,  new List<int>() {52, 51, 50, 50} },
            {10, new List<int>(){51, 50, 49, 48}  },
            {11, new List<int>(){50, 49, 48, 45}  },
            {12, new List<int>(){60, 58, 56, 52}  },
        };


        public static int RentalPrice(DateTimeOffset startingDate, int numberOfDays)
        {
            var bracket = CalculateBracket(numberOfDays);
            var rentalPrice = 0;

            while (numberOfDays > 0)
            {
                //The +1 takes into account the current day into the price calculation
                var remainingDaysInMonth = (DateTime.DaysInMonth(startingDate.Year, startingDate.Month) - startingDate.Day) + 1;

                if (remainingDaysInMonth < numberOfDays)
                    rentalPrice += Values.GetValueOrDefault(startingDate.Month)![bracket] * remainingDaysInMonth;
                else
                    rentalPrice += Values.GetValueOrDefault(startingDate.Month)![bracket] * numberOfDays;

                startingDate = startingDate.AddDays(remainingDaysInMonth);
                numberOfDays -= remainingDaysInMonth;
            }

            return rentalPrice;
        }

        //Calculation of the pricing brackets 
        private static int CalculateBracket(int numberOfDays)
        {
            //1-3
            if (numberOfDays < 3) return 0;

            //4-8
            if (numberOfDays < 9) return 1;

            //9-15
            if (numberOfDays < 16) return 2;

            //16+
            return 3;
        }
    }
}
