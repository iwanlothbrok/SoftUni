using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {

        public Box(List<T> nums)
        {
            Value = nums;
        }

        public List<T> Value { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Value)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }

        public void Swap(List<T> nums,int firstIndex,int secondIndex)
        {
            T swapper = nums[firstIndex];
            nums[firstIndex] = nums[secondIndex];
            nums[secondIndex] = swapper;
        }
    }
}
