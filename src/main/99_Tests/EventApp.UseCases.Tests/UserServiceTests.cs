using EventApp.Entities;
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
        private IUserRepository _fakeUserRepository;
        private User _existingUser;

        [SetUp]
        public void Setup() 
        {
            _existingUser = new User
            {
                Id = Guid.NewGuid(),
                Name = "ExistingUser"
            };

             var users = (IList<User>)new List<User> { _existingUser };

            _fakeUserRepository = A.Fake<IUserRepository>();
            A.CallTo(() => _fakeUserRepository.GetAllAsync()).Returns(Task.FromResult(users));
        }

        [Test]
        [Description("Должен уметь создавать новго пользователя.")]
        public async Task CanCreateUserTest()
        {
            var sut = new UserService(_fakeUserRepository);
            var result = await sut.CreateUserAsync("NewUser");

            result.IsSuccess.Should().Be(true);
            result.Value.Should().NotBeEmpty();
            A.CallTo(() => _fakeUserRepository.SaveAsync(A<User>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Test]
        [Description("Не должен создавать пользователей с одинаковыми именами.")]
        public async Task CantCreateUserWithExistingNameTest()
        {
            var sut = new UserService(_fakeUserRepository);
            var result = await sut.CreateUserAsync("ExistingUser");

            result.IsFailure.Should().Be(true);
            A.CallTo(() => _fakeUserRepository.SaveAsync(A<User>.Ignored)).MustNotHaveHappened();
        }
    }
}
