﻿namespace UserJournal.Models
{
        public class Name
        {
            public string title { get; set; }
            public string first { get; set; }
            public string last { get; set; }

        public override string ToString()
        {
            return $"{title} {first} {last}";
        }
    }


}