﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<TFirst, TSecond>
    {
        public Tuple(TFirst firstItem, TSecond secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }



        public TFirst FirstItem { get; set; }
        public TSecond SecondItem { get; set; }


        public  override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
