using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Registrations
    {
        
        /// <summary>
        /// Id primary key 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [Required(ErrorMessage = "The FirstName must be required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [Required(ErrorMessage = "The LastName must be required")]
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "The Email must be required")]
        [RegularExpression("^(.+)@(.+)$", ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "The Password must be required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// This flag identified data is edited or not
        /// </summary>
        public bool IsDataEdited { get; set; }
    }
}
