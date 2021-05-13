using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Autofac;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using LibraryApp_DAL;
using Moq;
using Moq.Language;
using Autofac.Extras.Moq;

namespace LibraryApp.BusinessLogic.Tests
{
    /// <summary>
    /// Summary description for BranchLogicTests
    /// </summary>
    [TestClass]
    public class BranchLogicTests
    {

        #region Constants

        public AutoMock Mock { get; set; }
        public Mock<DConnectivity> Dep { get; set; }
        public IBranchRepository BranchRep { get; set; }

        public List<Branch> Branches = new List<Branch>();

        #endregion

        [TestInitialize]
        public void TestInitialize()
        {
            Mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(new Mock<DConnectivity>()).As<Mock<DConnectivity>>());
            Dep = Mock.Create<Mock<DConnectivity>>();
        }

        private List<Branch> GetBranches()
        {

            Branch branch1 = new Branch()
            {
                ID = 1,
                Name = "Name1",
                Address = "Address1"
            };

            Branch branch2 = new Branch()
            {
                ID = 2,
                Name = "Name2",
                Address = "Address2"
            };

            Branch branch3 = new Branch()
            {
                ID = 3,
                Name = "Name3",
                Address = "Address3"
            };

            Branches.Add(branch1);
            Branches.Add(branch2);
            Branches.Add(branch3);
            return Branches;

        }


        [TestMethod]
        public void GetBranches_Returns_AllBranchesIfAny()
        {
            using (Mock)
            {

                Mock.Mock<IBranchRepository>().Setup(x => x.GetBranches()).Returns(GetBranches);
                BranchRep = Mock.Create<IBranchRepository>();

                var expected = GetBranches();
                var actual = BranchRep.GetBranches();

                Assert.IsTrue(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);

                for (var i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].ID, actual[i].ID);
                }

            }
        }

        [TestMethod]
        public void AddBranch_Returns_FalseIfTheBranchWasNull()
        {
            Branch branch = null;
            using (Mock)
            {
                Mock.Mock<IBranchRepository>().Setup(x => x.AddBranch(branch)).Returns(false);
                BranchRep = Mock.Create<IBranchRepository>();

                var actual = BranchRep.AddBranch(branch);

                Assert.IsFalse(actual);
            }
        }

        [TestMethod]
        public void AddBranch_Returns_TrueIfTheBranchWasSuccessfullyAdded()
        {
            var branch = new Branch()
            {
                ID = 4,
                Name = "Name4",
                Address = "Address4"
            };
            using (Mock)
            {
                Mock.Mock<IBranchRepository>().Setup(x => x.AddBranch(branch)).Returns(true);
                BranchRep = Mock.Create<IBranchRepository>();

                var actual = BranchRep.AddBranch(branch);

                Assert.IsTrue(actual);

            }
        }


        [TestMethod]
        public void EditBranch_Returns_TrueIfTheBranchWasSuccessfullyEdited()
        {
            var branch = new Branch()
            {
                ID = 4,
                Name = "Name4",
                Address = "Address4"
            };
            using (Mock)
            {
                Mock.Mock<IBranchRepository>().Setup(x => x.UpdateBranch(branch)).Returns(true);
                BranchRep = Mock.Create<IBranchRepository>();

                var actual = BranchRep.UpdateBranch(branch);

                Assert.IsTrue(actual);

            }

        }

        [TestMethod]
        public void EditBranch_Returns_FalseIfTheBranchWasNull()
        {
            using (Mock)
            {
                Mock.Mock<IBranchRepository>().Setup(x => x.UpdateBranch(null)).Returns(false);
                BranchRep = Mock.Create<IBranchRepository>();

                var actual = BranchRep.UpdateBranch(null);

                Assert.IsFalse(actual);

            }

        }
    }

}
