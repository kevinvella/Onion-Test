using EFCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Data.Models;

namespace EFCore.Services
{
    public class ItemService : IItemService
    {
        public void Add(tb_Item obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(tb_Item obj)
        {
            throw new NotImplementedException();
        }

        public List<tb_Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public tb_Item GetSingle(int pk)
        {
            throw new NotImplementedException();
        }

        public tb_Item GetSingle(Guid uniqueIdentifier)
        {
            throw new NotImplementedException();
        }

        public tb_Item GetSingle(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(tb_Item obj)
        {
            throw new NotImplementedException();
        }
    }
}
