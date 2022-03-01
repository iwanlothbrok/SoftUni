using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {

        public int CalculatorDiffrence(string dateOne, string dateTwo)
        {
            var firstDateArr = dateOne.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                            .Select(int.Parse).ToArray();

            DateTime firstDateTime = new DateTime(firstDateArr[0], firstDateArr[1], firstDateArr[2]);


            var secondDateArr = dateTwo.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                            .Select(int.Parse).ToArray();

            DateTime secondDateTime = new DateTime(secondDateArr[0], secondDateArr[1], secondDateArr[2]);

            return Math.Abs((firstDateTime-secondDateTime).Days);
        }
    }
}
