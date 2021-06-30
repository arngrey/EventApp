﻿using EventApp.Entities;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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

            var users = new List<User> { _existingUser };

            _fakeUserRepository = A.Fake<IUserRepository>();
            A.CallTo(() => _fakeUserRepository.GetAll()).Returns(users);
        }

        [Test]
        [Description("Должен уметь создавать новго пользователя.")]
        public void CanCreateUserTest()
        {
            var sut = new UserService(_fakeUserRepository);
            var result = sut.CreateUser("NewUser");

            result.IsSuccess.Should().Be(true);
            A.CallTo(() => _fakeUserRepository.Save(A<User>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Test]
        [Description("Не должен создавать пользователей с одинаковыми именами.")]
        public void CantCreateUserWithExistingNameTest()
        {
            var sut = new UserService(_fakeUserRepository);
            var result = sut.CreateUser("ExistingUser");

            result.IsFailure.Should().Be(true);
            A.CallTo(() => _fakeUserRepository.Save(A<User>.Ignored)).MustNotHaveHappened();
        }

        [Test]
        [Description("Должен уметь получать пользователя по имени.")]
        public void CanGetUserByNameTest()
        {
            var sut = new UserService(_fakeUserRepository);
            var result = sut.GetUserByName("ExistingUser");

            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(_existingUser);
        }

        [Test]
        [Description("Не должен возвращать несуществующего пользователя.")]
        public void CantGetNonExistingUserTest()
        {
            var sut = new UserService(_fakeUserRepository);
            var result = sut.GetUserByName("NonExistingUser");

            result.IsFailure.Should().Be(true);
        }
    }
}
