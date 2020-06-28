using System;
using SQLite;

namespace HRApp
{
    public class Job
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string JobTitle { get; set; }

        public string OpenPositions { get; set; }

        public string RequiredExperience { get; set; }

        public string SkillSet { get; set; }

        public string ExpectedNoticePeriod { get; set; }

        public string JobDescription { get; set; }
    }
}
