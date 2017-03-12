using System.Net;

namespace TPP.Concurrency.Delegates {

    public class WebPage {

        /// <summary>
        /// Web page URL
        /// </summary>
        private string url;

        public WebPage(string url) {
            this.url = url;
        }

        /// <summary>
        /// Access to the Web page and returns the number of img tags in the html code
        /// </summary>
        /// <returns>The number of img tags in the html code</returns>
        public int GetNumberOfImages() {
            WebClient client = new WebClient();
            string html = client.DownloadString(this.url);
            return Ocurrencias(html.ToLower(), "<img");
        }

        /// <summary>
        /// Returns the number of occurrences of a word in a string
        /// </summary>
        /// <param name="str">The string where a word is going to be searched in</param>
        /// <param name="word">The word to be searched</param>
        /// <returns>The number of occurrences of word in str</returns>
        private int Ocurrencias(string str, string word) {
            return (str.Length - str.Replace(word, "").Length) / word.Length;
        }

    }

}
