namespace LINQ_Dersleri.Models
{
    public class City
    {
        public string Name { get; set; }
        public long Population { get; set; }


        public City(string name, long population)
        {
            Name = name;
            Population = population;
        }
    }
}
