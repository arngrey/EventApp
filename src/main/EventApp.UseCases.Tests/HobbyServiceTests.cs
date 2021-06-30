using EventApp.Entities;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EventApp.UseCases.Tests
{
    [TestFixture]
    public class HobbyServiceTests
    {
        private IHobbyRepository _fakeHobbyRepository;
        private Hobby _existingHobby;

        [SetUp]
        public void Setup()
        {
            _existingHobby = new Hobby
            {
                Id = Guid.NewGuid(),
                Name = "ExistingHobby"
            };

            var hobbies = new List<Hobby> { _existingHobby };

            _fakeHobbyRepository = A.Fake<IHobbyRepository>();
            A.CallTo(() => _fakeHobbyRepository.GetAll()).Returns(hobbies);
        }

        [Test]
        [Description("Должен уметь создавать новое хобби.")]
        public void CanCreateHobbyTest()
        {
            var sut = new HobbyService(_fakeHobbyRepository);
            var result = sut.CreateHobby("NewHobby");

            result.IsSuccess.Should().Be(true);
            A.CallTo(() => _fakeHobbyRepository.Save(A<Hobby>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Test]
        [Description("Не должен создавать хобби с одинаковыми названиями.")]
        public void CantCreateHobbyWithExistingNameTest()
        {
            var sut = new HobbyService(_fakeHobbyRepository);
            var result = sut.CreateHobby("ExistingHobby");

            result.IsFailure.Should().Be(true);
            A.CallTo(() => _fakeHobbyRepository.Save(A<Hobby>.Ignored)).MustNotHaveHappened();
        }

        [Test]
        [Description("Должен уметь получать хобби по имени.")]
        public void CanGetHobbyByNameTest()
        {
            var sut = new HobbyService(_fakeHobbyRepository);
            var result = sut.GetHobbyByName("ExistingHobby");

            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(_existingHobby);
        }

        [Test]
        [Description("Не должен возвращать несуществующее хобби.")]
        public void CantGetNonExistingHobbyTest()
        {
            var sut = new HobbyService(_fakeHobbyRepository);
            var result = sut.GetHobbyByName("NonExistingHobby");

            result.IsFailure.Should().Be(true);
        }
    }
}
