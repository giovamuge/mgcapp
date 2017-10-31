using Mugelli.Software.It.Mgc.Models;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class NewsDetailViewModel : BaseViewModel
    {
        private News _article;

        public News Article
        {
            get => _article;
            set
            {
                RaisePropertyChanged(nameof(Article), _article, value);
                _article = value;
            }
        }

        public NewsDetailViewModel() { }
    }
}