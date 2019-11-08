using System;
using EmployeeTestQuiz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Mock<IDataAccess> fakeDataAccess;
        MoviesBusinessLogic mbl;
        [TestInitialize]
        public void SetUp()
        {
            fakeDataAccess = new Mock<IDataAccess>();
            fakeDataAccess.Setup(m => m.GetEmplyeeSalary(It.IsAny<int>())).Returns("Argo");
            fakeDataAccess.Setup(m => m.GetTopThreeSalaries(It.IsAny<int>())).Returns("Action");
            mbl = new MoviesBusinessLogic(fakeDataAccess.Object);
        }
        [TestMethod]
        public void PrintMovieShortInfo_Test_WithMoq()
        {
            //Arrange (Handled by Initialize)                
            //Act
            var printResult = mbl.AllInfo(5);
            //Assert
            Assert.AreEqual(printResult, "The employee Argo with salary Action");
        }
    }
}
