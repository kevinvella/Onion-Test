using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Data.Models
{
    public class tb_User
    {
        public tb_User()
        {
        }

        [Key]
        public int usr_Pk { get; set; }

        [Required]
        public Guid usr_Guid { get; set; }

        [Required]
        public string usr_Firstname { get; set; }

        [Required]
        public string usr_LastName { get; set; }

        [Required]
        public string usr_Email { get; set; }

        [Required]
        public string usr_Password { get; set; }
    }
}
