using System;
using FakeItEasy;
using NUnit.Framework;

namespace Usol.Wally.Domain.Models
{
    /// <summary>
    /// Tests for <see cref="Currency"/>
    /// </summary>
    public class CurrencyTest
    {
        [Test]
        public void DefaultCtor_DoesntThrows()
        {
            Assert.DoesNotThrow(() => new Currency());
        }

        [Test]
        public void FullCtor_DoesntThrows()
        {
            const int id = 42;
            var code = new string(A.Dummy<char>(), Currency.CodeMaxLength);

            Assert.DoesNotThrow(() => new Currency(id, code));
        }

        [Test]
        public void AnyPropery_CanBeSet()
        {
            const int id = 42;
            var code = new string(A.Dummy<char>(), Currency.CodeMaxLength);

            var currency = new Currency(id, code);

            Assert.AreEqual(id, currency.Id);
            Assert.AreEqual(code, currency.Code);
        }

        [Test]
        public void Code_Throws_WhenTooLong()
        {
            const int id = 42;
            var code = new string(A.Dummy<char>(), Currency.CodeMaxLength + 1);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Currency(id, code));
            StringAssert.AreEqualIgnoringCase("Length for Code can't exceed 3.\r\nParameter name: value", ex.Message);
        }
    }
}