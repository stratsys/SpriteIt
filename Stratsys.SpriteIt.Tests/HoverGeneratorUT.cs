using System.Collections.Generic;
using Microsoft.Web.Samples;
using NUnit.Framework;

namespace Stratsys.SpriteIt.Tests
{
    [TestFixture]
    public class HoverGeneratorUT
    {
        /// <summary>
        /// Files
        /// c:\Srite\a.gif
        /// c:\Srite\b.gif
        /// c:\Srite\a-hover.gif
        /// 
        /// Expected
        /// c:\Srite\a.gif c:\Srite\a-hover.gif
        /// c:\Srite\b.gif
        /// </summary>
        [Test]
        public void ShouldPaitHoverIconWithOrdinaryIcon()
        {            
            var files = new List<string>
            {
                @"c:\Sprite\a.gif",
                @"c:\Sprite\b.gif",
                @"c:\Sprite\a-hover.gif",
            };

            var hoverGenerator = new HoverGenerator();
            var result = hoverGenerator.Generate(files);
            Assert.That(result, Has.Count.EqualTo(2));            
            Assert.That(result.Keys, Has.Member(@"c:\Sprite\a.gif"));
            Assert.That(result.Keys, Has.Member(@"c:\Sprite\b.gif"));
            Assert.That(result[@"c:\Sprite\a.gif"], Is.EqualTo(@"c:\Sprite\a-hover.gif"));
        }

        [Test]
        public void CanHandleDotsInPath()
        {
            var files = new List<string>
            {
                @"c:\Sprite.Net\a.gif",
                @"c:\Sprite.Net\b.gif",
            };

            var hoverGenerator = new HoverGenerator();
            var result = hoverGenerator.Generate(files);
            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result.Keys, Has.Member(@"c:\Sprite.Net\a.gif"));
            Assert.That(result.Keys, Has.Member(@"c:\Sprite.Net\b.gif"));
        }
    }
}
