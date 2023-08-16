using System.ComponentModel.DataAnnotations;

namespace mobileInfo_Assignment03.Models
{
    public class mobileInfo
    {
        [Key]
        public int mobileId { get; set; }

        public required string mobileModel { get; set; }

        public required string mobileCompany { get; set; }

        public required string manufacturedYear { get; set; }

        public required string mobileStorage { get; set; }

        public required string mobileColour { get; set; }
    }
}
