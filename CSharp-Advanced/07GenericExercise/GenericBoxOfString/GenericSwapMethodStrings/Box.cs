

using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
    {
        public Box(List<T> names)
        {
            this.GetT = names;
        }
        public List<T> GetT { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.GetT)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }

        public void Swap(List<T> names, int firstIndex, int secondIndex)
        {
            T firstSwap = names[firstIndex];
            names[firstIndex] = names[secondIndex];
            names[secondIndex] = firstSwap;

        }
    }
}
