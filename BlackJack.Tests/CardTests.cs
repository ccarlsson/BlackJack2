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
    }
}
