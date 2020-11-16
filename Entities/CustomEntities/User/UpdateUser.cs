using System.ComponentModel.DataAnnotations;

namespace Entities.CustomEntities.User
{
    public class UpdateUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    
    }
}
