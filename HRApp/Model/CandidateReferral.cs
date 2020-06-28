using System;
using SQLite;

namespace HRApp
{
    public class CandidateReferral
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string ApplyingRole { get; set; }

        public string YearsOfExperience { get; set; }

        public string CurrentCompany { get; set; }

        public string CurrentLocation { get; set; }

        public string OpenForRelocation { get; set; }

        public string UploadedFile { get; set; }
    }
}
