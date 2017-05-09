using EFCore.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repo.Maps
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<tb_User> entitybuilder)
        {
            entitybuilder.HasKey(t => t.usr_Pk);
        }
    }
}
