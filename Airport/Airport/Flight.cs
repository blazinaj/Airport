namespace Airport
{
    public class Flight
    {
        private string aname;
        private string orig;
        private string dest;
        private int year;
        private int month;
        private int day;
        private string id;

        public Flight(string aname, string orig, string dest, int year, int month, int day, string id)
        {
            this.aname = aname;
            this.orig = orig;
            this.dest = dest;
            this.year = year;
            this.month = month;
            this.day = day;
            this.id = id;
        }
    }
}