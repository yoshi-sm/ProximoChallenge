using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.BobsRentalChallenge
{
    public class BobsRental
    {
        private IBobsRepository _repository;

        //DI 
        public BobsRental(IBobsRepository repository)
        {
            _repository = repository;
        }

        public int RentalPrice(DateTimeOffset startingDate, int numberOfDays)
        {
            var bracket = CalculateBracket(numberOfDays);
            var rentalPrice = 0;

            while (numberOfDays > 0)
            {
                //The +1 takes into account the current day into the price calculation
                var remainingDaysInMonth = DateTime.DaysInMonth(startingDate.Year, startingDate.Month) - startingDate.Day + 1;

                //Getting the prices from the repository
                if (remainingDaysInMonth < numberOfDays)
                    rentalPrice += _repository.GetPrice(startingDate.Month, bracket) * remainingDaysInMonth;
                else
                    rentalPrice += _repository.GetPrice(startingDate.Month, bracket) * numberOfDays;

                //Adding/Subtracting days at the end of the loop
                startingDate = startingDate.AddDays(remainingDaysInMonth);
                numberOfDays -= remainingDaysInMonth;
            }

            return rentalPrice;
        }

        //Calculation of the pricing brackets 
        private int CalculateBracket(int numberOfDays)
        {
            //1-3
            if (numberOfDays < 4) return 0;

            //4-8
            if (numberOfDays < 9) return 1;

            //9-15
            if (numberOfDays < 16) return 2;

            //16+
            return 3;
        }
    }
}
