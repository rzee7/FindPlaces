﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPlaces.Helper
{
    public class Constants
    {
        public const string PlaceAppApiKey = "AIzaSyBBqOBjbfc0dtMpMJhTnXLhbeZF5WcOlx0"; //Note: This is only for testing purpose
        public const string PlaceApiHostURL = "https://maps.googleapis.com/maps/api/place/textsearch/json?query={0}&key={1}";
    }
}