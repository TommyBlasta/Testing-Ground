using System;
using TestingGround;
using NUnit.Framework;

namespace TestingGround.UnitTests
{

        [TestFixture]
        public class ReverserTests
        {
            [Test]
            public void Reverse_ValidString_ReturnsReversedString()
            {
                //Arrange - initialize objects
                Reverser reverser = new Reverser();
                //Act
                var result = reverser.Reverse("abcdef");
                //Assert
                Assert.AreEqual("fedcba", result);

            }
            [Test]
            public void Reverse_InvalidString_ReturnsNull()
            {
                //Arrange - initialize objects
                Reverser reverser = new Reverser();
                //Act
                var result = reverser.Reverse(null);
                //Assert
                Assert.AreEqual(null, result);
            }
            [Test]
            public void ReverseAndNot_ValidInt_ReturnsReversedAndOriginal()
            {
                //Arrange - initialize objects
                Reverser reverser = new Reverser();
                //Act
                var result = reverser.ReverseAndNot(1234);
                //Assert
                Assert.That("43211234" == result);
            }
            [Test]
            public void ReverseAndNot_MaxInt32_ReturnsReversedAndOriginal()
            {
                //Arrange - initialize objects
                Reverser reverser = new Reverser();
                //Act
                var result = reverser.ReverseAndNot(Int32.MaxValue);
                //Assert
                Assert.AreEqual("74638474122147483647", result);
            }
    }
}
