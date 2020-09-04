﻿using System;
using NUnit.Framework;
using TestingGround;

namespace TestingGround.UnitTests
{
    [TestFixture]
    public class RepeaterTests
    {
        Repeater _repeater;
        [SetUp]
        public void SetUp()
        {
            _repeater = new Repeater();
        }
        [Test]
        [TestCase("abcdef",3,"aaabbbcccdddeeefff")]
        [TestCase(".12", 3, "...111222")]
        [TestCase("abc", 0, "")]
        public void Repeat_WhenCalled_ReturnsStringWithRepeatedChars(string inputStr, int inputInteger, string excpectedResult)
        {
            //Act
            var result = _repeater.Repeat(inputStr, inputInteger);
            //Assert
            Assert.That(result.Equals(excpectedResult));
        }
        [Test]
        [TestCase("abc", int.MaxValue)]
        [TestCase("1231231231312312312312312313213213213213212312321" +
                "3213213213213213213213213213213213213123123123131231231231" +
                "2312313213213213213212312321321321321321321321321321321321" +
                "3213213123123123131231231231231231321321321321321231232132" +
                "1321321321321321321321321321321321312312312313123123123123" +
                "1231321321321321321231232132132132132132132132132132132132" +
                "1321312312312313123123123123123132132132132132123123213213" +
                "2132132132132132132132132132132131231231231312312312312312" +
                "3132132132132132123123213213213213213213213213213213213213" +
                "2131231231231312312312312312313213213213213212312321321321" +
                "3213213213213213213213213213213123123123131231231231231231" +
                "3213213213213212312321321321321321321321321321321321321321" +
                "3123123123131231231231231231321321321321321231232132132132" +
                "1321321321321321321321321321312312312313123123123123123132" +
                "1321321321321231232132132132132132132132132132132132132131" +
                "2312312313123123123123123132132132132132123123213213213213" +
                "2132132132132132132132132131231231231312312312312312313213" +
                "2132132132123123213213213213213213213213213213213213213123" +
                "1231231312312312312312313213213213213212312321321321321321" +
                "3213213213213213213213213123123123131231231231231231321321" +
                "32132132123123213213213213213213213213213213213213213" +
                "12312312313123123123123123132132132132132123123213213213213213213213213213213213213213" +
                "12312312313123123123123123132132132132132123123213213213213213213213213213213213213213", 1)]
        public void Repeat_ArgsOutOfRange_ThrowsAnException(string inputStr, int inputInteger)
        {
            //Act
            //Assert
            Assert.That(() => _repeater.Repeat(inputStr, inputInteger),
                Throws
                .Exception
                .TypeOf<ArgumentOutOfRangeException>());
                //.With.Property("paramName")
                //.EqualTo("num")); ; 
        }
    }
}
