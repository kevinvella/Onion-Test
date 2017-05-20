using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFCore.Repo.Interfaces;
using EFCore.Repo;
using EFCore.Data.Models;
using EFCore.Repo.Context;
using EFCore.Repo.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Services.UnitTest
{
    [TestClass]
    public class UserServiceUnitTest
    {
        ApplicationContext context;

        GenericRepository<tb_User> userRepo;
        GenericRepository<tb_File> fileRepo;

        IUnitOfWork unitOfWork;

        UserService userService;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase<ApplicationContext>()
                .Options;

            context = new ApplicationContext(options);

            unitOfWork = new UnitOfWork(context);

            userRepo = new GenericRepository<tb_User>(context);
            fileRepo = new GenericRepository<tb_File>(context);

            userService = new UserService(userRepo, fileRepo, unitOfWork);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddValidUnitTest()
        {
            
            userService.Add(new tb_User()
            {
                usr_Email = "kevin3vel@hotmail.com",
                usr_Firstname = "Kevin",
                usr_LastName = "Vella",
                usr_Password = "testing1234567890!"
            });

            tb_User usr = userService.GetSingle("Kevin");

            Assert.IsNull(usr);
        }
    }
}
