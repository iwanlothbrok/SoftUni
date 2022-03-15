using System;
using System.Collections;


namespace CustomRandomList
{
    public class RandomList : ArrayList
    {
        private Random rnd;

        public RandomList()
        {
            this.rnd = new Random();
        }
        public int RandomInteger()
        {
            return rnd.Next();
        }
        public int RandomString() => this.RandomInteger();
    }
}
