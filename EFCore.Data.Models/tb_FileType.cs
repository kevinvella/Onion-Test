using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore.Data.Models
{
    public class tb_FileType
    {
        [Key]
        public int ftyp_Pk { get; set; }

        public Guid ftyp_Guid { get; set; }

        [StringLength(50)]
        public string ftyp_Type { get; set; }
    }
}
