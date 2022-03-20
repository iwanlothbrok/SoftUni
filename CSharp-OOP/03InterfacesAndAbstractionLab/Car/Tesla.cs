namespace Cars
{
    public class Tesla : Car , ICar,IElectricCar
    {
        public Tesla(string model,string color,int battery) 
            :base( model, color)
        {
            Battery = battery;
        }

        public int Battery {  get;protected set; }
}
}
