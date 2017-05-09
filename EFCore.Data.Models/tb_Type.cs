using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore.Data.Models
{
    public class tb_Type
    {
        public tb_Type()
        { 
        }

        [Key]
        public int typ_Pk { get; set; }

        [Required]
        public Guid typ_Guid { get; set; }

        [Required]
        [MaxLength(50)]
        public string typ_Name { get; set; }
    }
}
