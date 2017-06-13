using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPlaces.Helper
{
    /// <summary>
    /// Constants strings.
    /// </summary>
    public class Constants
    {
        public const string PlaceAppApiKey = "AIzaSyBBqOBjbfc0dtMpMJhTnXLhbeZF5WcOlx0"; //Note: This is for testing purpose only.
        public const string PlaceApiHostURL = "https://maps.googleapis.com/maps/api/place/textsearch/json?query={0}&key={1}&pagetoken={2}";

        /// <summary>
        /// Generate server url to fetch places
        /// </summary>
        /// <param name="nextPageToken">Next page token.</param>
        /// <returns></returns>
        public static string GetServerURL(string query, string nextPageToken)
        {
            return string.Format(PlaceApiHostURL, query, PlaceAppApiKey, nextPageToken);
        }

        //Titles
        public const string DialogTitle = "App Says";
        public const string CancelButton = "Sure";
        public const string Ok = "Hmm, Ok";
    }

    /// <summary>
    /// Application messages.
    /// </summary>
    public class Messages
    {
        public const string QueryRequired = "Please enter query to perform search.";
        public const string WentWrong = "Ohh Dear! Something went wrong, please try again.";
        public const string DefaultStatus = "Please wait, searching world...";
        public const string LoadingMore = "Hungry!! Wait, loading more...";
        public const string NoResult = "I'm free, What to do?";
    }
}
