namespace BlogProjesi.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int  TotalBLogCount  { get; set; }
        public int TotalViewCount { get; set; }
        public Blog MostViewedBlog {  get; set; }
        public Blog LatestBlog { get; set; }
        public int TotalCommentCount { get; set; }
        public Blog MostCommentedBlog { get; set; }
        public int TodayCommentCount { get; set; }
    }
}
