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
        public async void CanCreateHobbyTest()
        {
            var sut = new HobbyService(_fakeHobbyRepository);
            var result = await sut.CreateHobbyAsync("NewHobby");

            result.IsSuccess.Should().Be(true);
            result.Value.Should().NotBeEmpty();
            A.CallTo(() => _fakeHobbyRepository.Save(A<Hobby>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Test]
        [Description("Не должен создавать хобби с одинаковыми названиями.")]
        public async void CantCreateHobbyWithExistingNameTest()
        {
            var sut = new HobbyService(_fakeHobbyRepository);
            var result = await sut.CreateHobbyAsync("ExistingHobby");

            result.IsFailure.Should().Be(true);
            A.CallTo(() => _fakeHobbyRepository.Save(A<Hobby>.Ignored)).MustNotHaveHappened();
        }
    }
}
