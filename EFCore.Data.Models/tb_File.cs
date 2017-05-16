using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Data.Models
{
    public class tb_File
    {
        [Key]
        public int fl_Pk { get; set; }

        public Guid fl_Guid { get; set; }

        public int fl_ftyp_fk { get; set; }

        [StringLength(100)]
        public string fl_Name { get; set; }

        [StringLength(1000)]
        public string fl_Path { get; set; }

        [StringLength(300)]
        public string fl_Description { get; set; }

        public bool fl_IsPrimary { get; set; }
    }
}
