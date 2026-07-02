namespace BlogProjesi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Isim { get; set; }
        public string Email { get; set; }
        public string Yorum { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
