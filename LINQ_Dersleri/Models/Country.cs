namespace LINQ_Dersleri.Models
{
    public class Country
    {
        public string Name { get; set; }
        public double Area { get; set; }
        public long Population { get; set; }
        public List<City> Cities { get; set; }

        public Country( string name, double area, long population, List<City> cities)
        {
            Name = name;
            Area = area;
            Population = population;
            Cities = cities;
        }
    }
}
