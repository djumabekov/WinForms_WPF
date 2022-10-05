﻿
namespace UserJournal.Models
{
        public class Location
        {
            public Street street { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public object postcode { get; set; }
            public Coordinates coordinates { get; set; }
            public Timezone timezone { get; set; }
        }


}
