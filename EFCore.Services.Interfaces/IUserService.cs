﻿using EFCore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Services.Interfaces
{
    public interface IUserService : IBaseService<tb_User>
    {
        void Add(tb_User user, tb_File userPhoto);
    }
}
