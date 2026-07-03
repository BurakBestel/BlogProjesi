namespace BlogProjesi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public DateTime Publishdate { get; set; }
        public string Tags { get; set; }
        public int like { get; set; }
        public int comment { get; set; }
        public int viewcount { get; set; }
        public int status { get; set; }
    }
}
