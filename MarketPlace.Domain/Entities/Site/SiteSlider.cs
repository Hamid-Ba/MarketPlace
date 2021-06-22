using System;
using Framework.Domain;

namespace MarketPlace.Domain.Entities.Site
{
    public class SiteSlider : EntityBase
    {
        public string FirstHeader { get; private set; }
        public string SecondHeader { get; private set; }
        public string Description { get; private set; }
        public string TextButton { get; private set; }
        public string Link { get; private set; }
        public string ImageName { get; private set; }
        public bool IsDisplay { get; private set; }

        public SiteSlider(string firstHeader, string secondHeader, string description, string textButton, string link, string imageName,bool isDisplay)
        {
            FirstHeader = firstHeader;
            SecondHeader = secondHeader;
            Description = description;
            TextButton = textButton;
            Link = link;
            ImageName = imageName;
            IsDisplay = isDisplay;
        }

        public void Edit(string firstHeader, string secondHeader, string description, string textButton, string link, string imageName)
        {
            FirstHeader = firstHeader;
            SecondHeader = secondHeader;
            Description = description;
            TextButton = textButton;
            Link = link;

            if (!string.IsNullOrWhiteSpace(imageName))
                ImageName = imageName;

            LastUpdateDate = DateTime.Now;
        }

        public void TurnSliderOnOrNot(bool choice)
        {
            IsDisplay = choice;
            LastUpdateDate = DateTime.Now;
        }

        public void Delete()
        {
            IsDelete = true;
            DeletionDate = DateTime.Now;
        }
    }
}