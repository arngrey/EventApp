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
    public class HobbyServiceTests
    {
        private IRepository<Hobby> _fakeHobbyRepository;
        private Hobby _existingHobby;
        private IList<Hobby> _existingHobbies;

        [SetUp]
        public void Setup()
        {
            _existingHobby = new Hobby
            {
                Id = Guid.NewGuid(),
                Name = "ExistingHobby"
            };

            _existingHobbies = new List<Hobby> { _existingHobby };

            _fakeHobbyRepository = A.Fake<IRepository<Hobby>>();
            A.CallTo(() => _fakeHobbyRepository.GetAllAsync()).Returns(Task.FromResult(_existingHobbies));
        }

        [Test]
        [Description("Должен уметь создавать новое хобби.")]
        public async Task CanCreateHobbyTest()
        {
            var sut = new HobbyService(_fakeHobbyRepository);
            var result = await sut.CreateHobbyAsync("NewHobby");

            result.IsSuccess.Should().Be(true);
            result.Value.Should().NotBeEmpty();
            A.CallTo(() => _fakeHobbyRepository.SaveAsync(A<Hobby>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Test]
        [Description("Не должен создавать хобби с одинаковыми названиями.")]
        public async Task CantCreateHobbyWithExistingNameTest()
        {
            var sut = new HobbyService(_fakeHobbyRepository);
            var result = await sut.CreateHobbyAsync("ExistingHobby");

            result.IsFailure.Should().Be(true);
            A.CallTo(() => _fakeHobbyRepository.SaveAsync(A<Hobby>.Ignored)).MustNotHaveHappened();
        }

        [Test]
        [Description("Должен уметь получать список всех хобби.")]
        public async Task CanGetAllHobbiesTest()
        {
            var sut = new HobbyService(_fakeHobbyRepository);
            var result = await sut.GetAllAsync();

            result.IsSuccess.Should().Be(true);
            result.Value.Should().Equal(_existingHobbies);
        }
    }
}
