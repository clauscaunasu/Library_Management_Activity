using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Autofac;
using Autofac.Extras.Moq;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using LibraryApp.DataModel.Annotations;
using LibraryApp_DAL;
using Moq;


namespace LibraryApp.BusinessLogic.Tests
{
    /// <summary>
    /// Summary description for UserLogicTests
    /// </summary>
    [TestClass]
    public class UserLogicTests
    {
        #region Constants

        public AutoMock Mock { get; set; }
        public Mock<DConnectivity> Dep { get; set; }
        public IUserRepository Cls { get; set; }
        #endregion

        [TestInitialize]
        public void TestInitialize()
        {
            Mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(new Mock<DConnectivity>()).As<Mock<DConnectivity>>());
            Dep = Mock.Create<Mock<DConnectivity>>();
        }


        [TestMethod]
        public void GetClients_Returns_AllUsers()
        {
            using (Mock)
            {

                Mock.Mock<IUserRepository>().Setup(x => x.GetClients()).Returns(GetClients);
                Cls = Mock.Create<IUserRepository>();

                var expected = GetClients();
                var actual = Cls.GetClients();

                Assert.IsTrue(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);

                for (var i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Username, actual[i].Username);
                }

            }

        }


        [TestMethod]
        public void EditMember_Returns_FalseIfTheMemberWasNotEditedSuccessfully()
        {
            using (Mock)
            {
                Mock.Mock<IUserRepository>()
                    .Setup(x => x.EditMember(It.IsAny<Client>()))
                    .Returns(false);

                Cls = Mock.Create<IUserRepository>();
                var result = Cls.EditMember(It.IsAny<Client>());

                Assert.IsFalse(result);
            }
        }



        [TestMethod]
        public void EditMember_Returns_TrueIfTheMemberWasEditedSuccessfully()
        {
            using (Mock)
            {
                Mock.Mock<IUserRepository>()
                    .Setup(x => x.EditMember(It.IsAny<Client>()))
                    .Returns(true);

                Cls = Mock.Create<IUserRepository>();
                var result = Cls.EditMember(It.IsAny<Client>());

                Assert.IsTrue(result);


            }
        }

        [TestMethod]
        public void AddUser_Returns_TrueIfTheUserWasAddedSuccessfully()
        {
            using (Mock)
            {
                Mock.Mock<IUserRepository>()
                    .Setup(x => x.Add(It.IsAny<Client>()))
                    .Returns(true);
                Cls = Mock.Create<IUserRepository>();
                var result = Cls.Add(It.IsAny<Client>());

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AddUser_Returns_FalseIfTheUserWasNotAddedSuccessfully()
        {
            using (Mock)
            {
                Mock.Mock<IUserRepository>()
                    .Setup(x => x.Add(It.IsAny<Client>()))
                    .Returns(false);
                Cls = Mock.Create<IUserRepository>();
                var result = Cls.Add(null);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void DeleteUser_Returns_TrueIfSuccessfully()
        {
            using (Mock)
            {
                Mock.Mock<IUserRepository>()
                    .Setup(x => x.DeleteMember(It.IsAny<Client>()))
                    .Returns(true);
                Cls = Mock.Create<IUserRepository>();
                var result = Cls.DeleteMember(It.IsAny<Client>());

                Assert.IsTrue(result);
            }
        }

        private List<Client> GetClients()
        {
            var output = new List<Client>
            {
                new Client()
                {
                    ID = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Address = "address@gmail.com",
                    Telephone = "0000000",
                    Duty = "client",
                    Username = "Username1",
                    Password = "Password1",
                    Desired = true

                },
                new Client()
                {
                    ID = 2,
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    Address = "address@gmail.com",
                    Telephone = "0000000",
                    Duty = "client",
                    Username = "Username2",
                    Password = "Password2",
                    Desired = true

                },
                new Client()
                {
                    ID = 3,
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    Address = "address@gmail.com",
                    Telephone = "0000000",
                    Duty = "client",
                    Username = "Username3",
                    Password = "Password3",
                    Desired = true

                }
            };
            return output;
        }

    }


}
