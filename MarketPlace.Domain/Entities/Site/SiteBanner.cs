using System;
using Framework.Application;
using Framework.Domain;

namespace MarketPlace.Domain.Entities.Site
{
    public class SiteBanner : EntityBase
    {
        public string ImageName { get; private set; }
        public string ColSize { get; private set; }
        public string Url { get; private set; }
        public BannerPosition Position { get; private set; }

        public SiteBanner(string imageName, string colSize, string url, BannerPosition position)
        {
            ImageName = imageName;
            ColSize = colSize;
            Url = url;
            Position = position;
        }

        public void Edit(string imageName, string colSize, string url, BannerPosition position)
        {
            if (!string.IsNullOrWhiteSpace(imageName))
                ImageName = imageName;
            ColSize = colSize;
            Url = url;
            Position = position;
            LastUpdateDate = DateTime.Now;
        }

        public void Delete()
        {
            IsDelete = true;
            DeletionDate = DateTime.Now;
        }

    }
}