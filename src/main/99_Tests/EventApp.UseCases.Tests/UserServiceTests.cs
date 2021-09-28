using EventApp.Models;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventApp.UseCases.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private IRepository<User> _fakeUserRepository;
        private User _existingUser;

        [SetUp]
        public void Setup() 
        {
            _existingUser = new User
            {
                Id = Guid.NewGuid(),
                Login = "ExistingUser",
                Password = "ExistingPassword"
            };

             var users = (IList<User>)new List<User> { _existingUser };

            _fakeUserRepository = A.Fake<IRepository<User>>();
            A.CallTo(() => _fakeUserRepository.GetAllAsync()).Returns(Task.FromResult(users));
        }

        [Test]
        [Description("Должен уметь регистрировать новго пользователя.")]
        public async Task CanCreateUserTest()
        {
            var sut = new UserService(_fakeUserRepository);
            var result = await sut.SignUpAsync("NewUser", "NewPassword");

            result.IsSuccess.Should().Be(true);
            result.Value.Should().NotBeEmpty();
            A.CallTo(() => _fakeUserRepository.SaveAsync(A<User>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Test]
        [Description("Не должен регистрировать пользователя без пароля.")]
        public async Task CantCreateUserWithoutPasswordTest()
        {
            var sut = new UserService(_fakeUserRepository);
            var result = await sut.SignUpAsync("NewUser", "");

            result.IsFailure.Should().Be(true);
            A.CallTo(() => _fakeUserRepository.SaveAsync(A<User>.Ignored)).MustNotHaveHappened();
        }

        [Test]
        [Description("Не должен регистрировать пользователей с одинаковыми именами.")]
        public async Task CantSignUpUserWithExistingNameTest()
        {
            var sut = new UserService(_fakeUserRepository);
            var result = await sut.SignUpAsync("ExistingUser", "ExistingPassword");

            result.IsFailure.Should().Be(true);
            A.CallTo(() => _fakeUserRepository.SaveAsync(A<User>.Ignored)).MustNotHaveHappened();
        }
    }
}
