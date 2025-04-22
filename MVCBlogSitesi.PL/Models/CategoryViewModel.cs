namespace BlogSitesi.PL.Models
{
    public class CategoryViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public ICollection<ArticleViewModel> Articles { get; set; }
    }
}
