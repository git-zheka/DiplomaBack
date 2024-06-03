﻿namespace VoloLearn.Models.Entities
{
    public class Assignment : BaseEntiti
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public DateTime EventDate { get; set;}
        public int Goal { get; set; }
        public int Reward { get; set; }
    }
}