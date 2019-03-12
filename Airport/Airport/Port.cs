namespace Airport
{
    internal class Port
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Port(string type, string name)
        {
            Type = type;
            Name = name;
        }

        
    }
}