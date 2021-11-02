using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJack.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CardShouldExist()
        {
            // Arrange
            // Act
            Card c = new Card(5, SuitType.Club);

            // Assert
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void FiveOfClubShouldTellCorrect()
        {
            // Arrange
            Card c = new Card(5, SuitType.Club);
            string expected = "5 of Club";
            // Act
            string actual = c.ToString();
            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void OneOfSpaceShouldTellCorrect()
        {
            // Arrange
            Card c = new Card(1, SuitType.Spade);
            string expected = "Ace of Spade";
            // Act
            string actual = c.ToString();
            // Assert
            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void NonCardShouldNotBeEqual()
        {
            // Arrange
            var cardone = new Card(1, SuitType.Diamond);
            var cardtwo = new Player();

            // act
            var areEqual = cardone.Equals(cardtwo);

            // Assert

            Assert.IsFalse(areEqual);
        }


        [TestMethod]
        public void DiffrentCardShouldNotBeEqual()
        {
            // Arrange
            var cardone = new Card(1, SuitType.Diamond);
            var cardtwo = new Card(1, SuitType.Club);

            // act
            var areEqual = cardone.Equals(cardtwo);

            // Assert

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void EqualCardShouldBeEqual()
        {
            // Arrange
            var cardone = new Card(1, SuitType.Diamond);
            var cardtwo = new Card(1, SuitType.Diamond);

            // act
           

            // Assert

            Assert.IsTrue(cardone == cardtwo);
        }
    }
}
