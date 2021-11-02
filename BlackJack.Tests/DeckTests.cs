using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJack.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void DeckShouldExist()
        {
            // arrange
            var deck = new Deck(1, new TestRandom());

            //act

            // assert
            Assert.IsNotNull(deck);

        }


        [TestMethod]
        public void ShouldDrawCard()
        {
            // arrange
            var deck = new Deck(1, new TestRandom());
            var expected = new Card(1, SuitType.Club);

            // act
            var actual = deck.Draw();

            // assert 
            Assert.AreEqual(expected, actual); 
        }



    }
}
