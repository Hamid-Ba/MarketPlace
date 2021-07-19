namespace MarketPlace.Query.Contract.Picture
{
    public class PictureQueryVM
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ImageName { get; set; }
        public int Priority { get; set; }
    }
}
