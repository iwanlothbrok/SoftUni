using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<TFirst,TSecond,TThird>
    {
        public Threeuple(TFirst firstI , TSecond secondI , TThird thirdI )
        {
            FirstItem = firstI;
            SecondItem = secondI;
            ThirdItem = thirdI;
        }



        public TFirst FirstItem { get; set; }
        public TSecond SecondItem { get; set; }
        public TThird ThirdItem { get; set; }


        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
