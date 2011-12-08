using Microsoft.Web.Samples;
using NUnit.Framework;

namespace Stratsys.SpriteIt.Tests
{
    [TestFixture]
    public class CssNameHelperUT
    {
        [Test]
        public void TestCssNameWithValidStartChar_ReturnsSameChar()
        {
            Assert.AreEqual("-abc", CssNameHelper.GenerateSelector("-abc"));
            Assert.AreEqual("abc", CssNameHelper.GenerateSelector("abc"));
            Assert.AreEqual("ABC", CssNameHelper.GenerateSelector("ABC"));
            Assert.AreEqual("_abc", CssNameHelper.GenerateSelector("_abc"));
        }

        [Test]
        public void TestCssNameNonAsciiStartChar_ReturnsSameChar()
        {
            Assert.AreEqual("éabc", CssNameHelper.GenerateSelector("éabc"));
            Assert.AreEqual("çbc", CssNameHelper.GenerateSelector("çbc"));
        }

        [Test]
        public void TestCssNameSpecialStartChar_ReturnsEscapeChar()
        {
            Assert.AreEqual("\\31 abc", CssNameHelper.GenerateSelector("1abc"));
            Assert.AreEqual("\\31 Abc", CssNameHelper.GenerateSelector("1Abc"));
            Assert.AreEqual("\\31 1bc", CssNameHelper.GenerateSelector("11bc"));
            Assert.AreEqual("\\31gbc", CssNameHelper.GenerateSelector("1gbc"));
            Assert.AreEqual("\\e95 abc", CssNameHelper.GenerateSelector("ຕabc"));
        }

        [Test]
        public void TestCssNameShortStartChar()
        {
            Assert.AreEqual("\\31", CssNameHelper.GenerateSelector("1"));
            Assert.AreEqual("a", CssNameHelper.GenerateSelector("a"));
            Assert.AreEqual("\\e95", CssNameHelper.GenerateSelector("ຕ"));
            Assert.AreEqual("-", CssNameHelper.GenerateSelector("-"));
            Assert.AreEqual("_", CssNameHelper.GenerateSelector("_"));
        }

        [Test]
        public void TestCssNameWithValidChar_ReturnsSameChar()
        {
            Assert.AreEqual("a1", CssNameHelper.GenerateSelector("a1"));
            Assert.AreEqual("aA", CssNameHelper.GenerateSelector("aA"));
            Assert.AreEqual("a-", CssNameHelper.GenerateSelector("a-"));
            Assert.AreEqual("a_", CssNameHelper.GenerateSelector("a_"));
        }

        [Test]
        public void TestCssNameNonAsciiChar_ReturnsSameChar()
        {
            Assert.AreEqual("aé", CssNameHelper.GenerateSelector("aé"));
            Assert.AreEqual("aà", CssNameHelper.GenerateSelector("aà"));
        }

        [Test]
        public void TestCssNameSpecialChar_ReturnsEscapeChar()
        {
            Assert.AreEqual("a\\e95", CssNameHelper.GenerateSelector("aຕ"));
            Assert.AreEqual("a\\e95 a", CssNameHelper.GenerateSelector("aຕa"));
            Assert.AreEqual("a\\e95 A", CssNameHelper.GenerateSelector("aຕA"));
            Assert.AreEqual("a\\e95 5", CssNameHelper.GenerateSelector("aຕ5"));
            Assert.AreEqual("a\\e95z", CssNameHelper.GenerateSelector("aຕz"));
            Assert.AreEqual("a\\100z", CssNameHelper.GenerateSelector("a" + (char)256 + "z"));
            Assert.AreEqual("a\\e95\\e95z", CssNameHelper.GenerateSelector("aຕຕz"));
        }

        [Test]
        public void TestCssNameSimpleChar_ReturnsSimpleEscapeChar()
        {
            Assert.AreEqual("hello\\.jpg", CssNameHelper.GenerateSelector("hello.jpg"));
            Assert.AreEqual("hello\\$jpg", CssNameHelper.GenerateSelector("hello$jpg"));
            Assert.AreEqual("hello-jpg", CssNameHelper.GenerateSelector("hello jpg"));
            Assert.AreEqual("crazyfile\\^\\$\\[\\]\\.\\=\\'\\~\\(\\)\\+jpg", CssNameHelper.GenerateSelector("crazyfile^$[].='~()+jpg"));
        } 
    }
}