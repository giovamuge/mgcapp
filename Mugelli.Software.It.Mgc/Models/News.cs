using Mugelli.Software.It.Mgc.Extensions;

namespace Mugelli.Software.It.Mgc.Models
{
    public class News /*: BaseModel*/
    {
        private string _shortTitle;
        private string _title;

        public string Id { get; set; }

        public string Title
        {
            get => _title;
            set => _shortTitle = _title = value;
        }

        //public string Handle { get; set; }
        public string DateCreate { get; set; }

        public string HeroImage { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public string ShortTitle
        {
            get => _shortTitle.Truncate(200, true);
            set => _shortTitle = value;
        }
    }
}