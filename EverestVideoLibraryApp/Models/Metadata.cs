using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EverestVideoLibraryApp.Models
{
    public class Metadata
    {
    }
    public class ArtistMetadata
    {
        [Display(Name = "First Name")]
        public string FirstName;

        [Display(Name = "Last Name")]
        public string LastName;
    }
    public class DVDCopyMetadata
    {
        [Display(Name = "DVDCopyId")]
        public int DCopyId;
    }

    public class LoanMetadata
    {
        [Display(Name = "Due Amount")]
        public string DueAmount;
        [Display(Name = "Fine Amount")]
        public string FineAmount;
    }

    public class MemberMetadata
    {
        [Display(Name = "First Name")]
        public string FirstName;
        [Display(Name = "Last Name")]
        public string LastName;
    }

    public class MemberCategoryMetadata
    {
        [Display(Name = "Total Days")]
        public int TotalDays;
        [Display(Name = "Total Loan")]
        public int TotalLoan;
        [Display(Name = "Fine Amount Per day")]
        public int FineAmountPerDay;
    }

    public class UserMetadata
    {
        [Display(Name = "Full Name")]
        public string FullName;
    }
}