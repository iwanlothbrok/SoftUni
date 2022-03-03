
namespace GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T element)
        {
            this.Value = element;

        }

        public T Value { get; set; }


        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }
    }
}
