using System.Collections.Generic;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.UserControls;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class NewsDetailViewModel : BaseViewModel
    {
        private FeedRssItem _article;

        public FeedRssItem Article
        {
            get => _article;
            set
            {
                RaisePropertyChanged(nameof(Article), _article, value);
                _article = value;

                var list = new List<string>()
                {
                    "PiccoloPrincipe.jpg",
                    "PiccoloPrincipe.jpg",
                    "PiccoloPrincipe.jpg",
                    "PiccoloPrincipe.jpg",
                    "PiccoloPrincipe.jpg",
                    "PiccoloPrincipe.jpg"
                };

                Images = list;

                //foreach (var image in list)
                //{
                //    var img = new Image {Source = image};
                //    ChildrenImage.Add(img);
                //}
            }
        }

        private List<string> _images;

        public List<string> Images
        {
            get => _images;
            set
            {
                RaisePropertyChanged(nameof(Images), _images, value);
                _images = value;
            }
        }

        public NewsDetailViewModel()
        {
        }
    }
}