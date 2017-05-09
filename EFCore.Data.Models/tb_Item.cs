using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore.Data.Models
{
    public class tb_Item
    {
        public tb_Item()
        {
        }

        [Required]
        [Key]
        public int itm_Pk { get; set; }

        [Required]
        public Guid itm_Guid { get; set; }

        [Required]
        [MaxLength(50)]
        public string itm_Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string itm_Description { get; set; }

        [Required]
        public int itm_usr_fk { get; set; }

        [Required]
        public int itm_typ_fk { get; set; }
    }
}
