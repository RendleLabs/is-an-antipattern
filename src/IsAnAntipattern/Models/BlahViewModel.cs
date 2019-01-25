using System.Text.RegularExpressions;

namespace IsAnAntipattern.Models
{
    public class BlahViewModel
    {
        private static readonly Regex DotJpg = new Regex(@"\.jpg$", RegexOptions.Compiled);
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HtmlText { get; set; }
        public string ImagePath { get; set; }
        public string UnsplashLink { get; set; }

        public string OgImagePath => DotJpg.Replace(ImagePath, "-1200x630.jpg");
        public string TwitterImagePath => DotJpg.Replace(ImagePath, "-560x300.jpg");
    }
}