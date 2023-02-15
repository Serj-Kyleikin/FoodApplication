using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sport.Application.Controller.Tests 
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var username = Guid.NewGuid().ToString();
            var gender = "m";
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 180;

            // Act
            var controller = new UserController(username);
            controller.SetNewUserData(username, gender, birthDate, weight, height);

            // Assert
            Assert.AreEqual(username, controller.CurrentUser.Name);
            Assert.AreEqual(gender, controller.CurrentUser.Gender);
            Assert.AreEqual(birthDate, controller.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller.CurrentUser.Weight);
            Assert.AreEqual(height, controller.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var username = Guid.NewGuid().ToString();

            // Act
            var controller = new UserController(username);

            // Assert
            Assert.AreEqual(username, controller.CurrentUser.Name);
        }
    }
}