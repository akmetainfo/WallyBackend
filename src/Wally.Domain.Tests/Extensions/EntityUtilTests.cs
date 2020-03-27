using System;
using NUnit.Framework;

namespace Usol.Wally.Domain.Extensions
{
    public class EntityUtilTests
    {
        [Test]
        public void Set_ReturnsValue_WhenStringHasCorrectLength()
        {
            const int maxLength = 2;
            const string value = "12";
            const string propertyTitle = "somePropertyTitle";

            Assert.DoesNotThrow(() => EntityUtil.Set(value, maxLength, propertyTitle));
        }

        [Test]
        public void Set_Throws_WhenStringTooLong()
        {
            const int maxLength = 2;
            const string value = "123";
            const string propertyTitle = "somePropertyTitle";

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => EntityUtil.Set(value, maxLength, propertyTitle));
            StringAssert.AreEqualIgnoringCase($"Length for {propertyTitle} can't exceed {maxLength}.\r\nParameter name: {nameof(value)}", ex.Message);
        }
    }
}