namespace DataModel.PagingModel
{
    public class PagingModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string KeyWord { get; set; }

        public PagingModel()
        {
            PageNumber = 1;
            PageSize = 10;
            KeyWord = string.Empty;
        }
    }
}