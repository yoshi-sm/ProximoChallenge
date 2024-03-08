using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.BobsRentalChallenge
{
    public interface IBobsRepository
    {
        int GetPrice(int month, int bracket);
    }

    //Fake repository
    public class BobsRepository : IBobsRepository
    {
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

        public int GetPrice(int month, int bracket)
        {
            return Values.GetValueOrDefault(month)![bracket];
        }
    }
}
