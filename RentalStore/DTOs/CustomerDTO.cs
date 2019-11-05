using System.ComponentModel.DataAnnotations;

namespace mvc2019.DTOs
{
    public class CustomerDTO
    {
        public int id { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Insert Client´s name!")]
        public string name { get; set; }
        public bool isSubscribe { get; set; }
        public int? membershipTypeId { get; set; }
        public MembershipDTO membershipType { get; set; }
    }
}