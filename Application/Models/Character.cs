namespace Repository.Models
{
    public class Character
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public object origin { get; set; }
        public object location { get; set; }
        public string image { get; set; }
        public string[] episode { get; set; }
        public string url { get; set; }
        public string created { get; set; }
    }
}
