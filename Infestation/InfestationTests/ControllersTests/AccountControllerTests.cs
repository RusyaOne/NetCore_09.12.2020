using Infestation.Controllers;
using Infestation.Models;
using Infestation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InfestationTests.ControllersTests
{
    public class AccountControllerTests
    {
        [Fact]
        public void AccountController_Register_CreateCalledOnce()
        {
            //Arrange
            Mock<UserManager<ApplicationUser>> userManager = new Mock<UserManager<ApplicationUser>>();//Нужно добавить все зависимости в конструктор
            Mock<SignInManager<ApplicationUser>> signInManager = new Mock<SignInManager<ApplicationUser>>();

            var registerViewModel = new AccountRegisterViewModel
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "testuser@gmail.com",
                Password = "password",
                ConfirmPassword = "password"
            };

            var user = new ApplicationUser
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                UserName = registerViewModel.Email,
                Email = registerViewModel.Email
            };

            userManager.Setup(x => x.CreateAsync(user, registerViewModel.Password)).ReturnsAsync(IdentityResult.Success);

            AccountController controller = new AccountController(userManager.Object, signInManager.Object);

            //Act
            controller.Register(registerViewModel);

            //Assert
            userManager.Verify(x => x.CreateAsync(user, registerViewModel.Password), Times.Once);
        }

    }
}
