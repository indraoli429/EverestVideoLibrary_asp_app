using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EverestVideoLibraryApp.Models
{
    public class PartialClasses
    {
    }

    [MetadataType(typeof(ArtistMetadata))]
    public partial class Artist { }

    [MetadataType(typeof(DVDCopyMetadata))]
    public partial class DVDCopy { }

    [MetadataType(typeof(LoanMetadata))]
    public partial class Loan { }

    [MetadataType(typeof(MemberMetadata))]
    public partial class Member { }

    [MetadataType(typeof(MemberCategoryMetadata))]
    public partial class MemberCategory { }

    [MetadataType(typeof(UserMetadata))]
    public partial class User { }
}