using Challenges.BobsRentalChallenge;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.UnitTests
{
    internal class BobsRentalTests
    {
        private Mock<IBobsRepository> _repository;
        private BobsRental _bob;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IBobsRepository>();
            _bob = new BobsRental(_repository.Object);
        }

        [Test]
        public void RentalPrice_ZeroDays_ReturnZero()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2023-05-28");
            int numberOfDays = 0;
            _repository.Setup(r => r.GetPrice(5, 0)).Returns(52);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(0));
        }

        [Test]
        public void RentalPrice_ThreeDaysNoMonthSwap_ReturnAnswer()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2023-05-21");
            int numberOfDays = 3;
            _repository.Setup(r => r.GetPrice(5, 0)).Returns(52);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(156));
        }

        [Test]
        public void RentalPrice_ThreeDaysWithMonthSwap_ReturnAnswer()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2023-09-30");
            int numberOfDays = 3;
            _repository.Setup(r => r.GetPrice(9, 0)).Returns(52);
            _repository.Setup(r => r.GetPrice(10, 0)).Returns(51);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(154));
        }

        [Test]
        public void RentalPrice_FiveDaysNoMonthSwap_ReturnAnswer()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2023-05-20");
            int numberOfDays = 5;
            _repository.Setup(r => r.GetPrice(5, 1)).Returns(51);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(255));
        }

        [Test]
        public void RentalPrice_FiveDaysWithMonthSwap_ReturnAnswer()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2023-05-28");
            int numberOfDays = 5;
            _repository.Setup(r => r.GetPrice(5, 1)).Returns(51);
            _repository.Setup(r => r.GetPrice(6, 1)).Returns(54);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(258));
        }

        [Test]
        public void RentalPrice_TwelveDaysNoMonthSwap_ReturnAnswer()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2023-05-05");
            int numberOfDays = 12;
            _repository.Setup(r => r.GetPrice(5, 2)).Returns(50);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(600));
        }

        [Test]
        public void RentalPrice_TwelveDaysWithMonthSwap_ReturnAnswer()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2023-05-28");
            int numberOfDays = 12;
            _repository.Setup(r => r.GetPrice(5, 2)).Returns(50);
            _repository.Setup(r => r.GetPrice(6, 2)).Returns(53);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(624));
        }

        [Test]
        public void RentalPrice_ThrityOneDaysNoMonthSwap_ReturnAnswer()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2023-12-01");
            int numberOfDays = 31;
            _repository.Setup(r => r.GetPrice(12, 3)).Returns(52);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(1612));
        }

        [Test]
        public void RentalPrice_ThrityOneDaysWithMonthSwap_ReturnAnswer()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2023-12-02");
            int numberOfDays = 31;
            _repository.Setup(r => r.GetPrice(12, 3)).Returns(52);
            _repository.Setup(r => r.GetPrice(1, 3)).Returns(45);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(1605));
        }

        [Test]
        public void RentalPrice_SixtyDaysLeapYear_ReturnAnswer()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2024-02-15");
            int numberOfDays = 60;
            _repository.Setup(r => r.GetPrice(2, 3)).Returns(45);
            _repository.Setup(r => r.GetPrice(3, 3)).Returns(45);
            _repository.Setup(r => r.GetPrice(4, 3)).Returns(48);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(2742));
        }

        [Test]
        public void RentalPrice_SixtyDaysNonLeapYear_ReturnAnswer()
        {
            //Arrange
            DateTimeOffset startingDate = DateTimeOffset.Parse("2023-02-15");
            int numberOfDays = 60;
            _repository.Setup(r => r.GetPrice(2, 3)).Returns(45);
            _repository.Setup(r => r.GetPrice(3, 3)).Returns(45);
            _repository.Setup(r => r.GetPrice(4, 3)).Returns(48);

            //Act
            var answer = _bob.RentalPrice(startingDate, numberOfDays);

            //Assert
            Assert.That(answer, Is.EqualTo(2745));
        }
    }
}
