using System;
using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace Usol.Wally.Domain.Models
{
    /// <summary>
    /// Tests for <see cref="Category"/>
    /// </summary>
    public class CategoryTest
    {
        [Test]
        public void DefaultCtor_DoesntThrows()
        {
            Assert.DoesNotThrow(() => new Category());
        }

        [Test]
        public void FullCtor_DoesntThrows()
        {
            const int id = 42;
            const string title = "title";
            var transactionCategories = new List<TransactionCategory>();

            Assert.DoesNotThrow(() => new Category(id, title, transactionCategories));
        }

        [Test]
        public void SimpleCtor_DoesntThrows()
        {
            const int id = 42;
            const string title = "title";

            Assert.DoesNotThrow(() => new Category(id, title));
        }

        [Test]
        public void AnyPropery_CanBeSet()
        {
            const int id = 42;
            const string title = "title";
            var transactionCategories = new List<TransactionCategory>();

            var category = new Category(id, title, transactionCategories);

            Assert.AreEqual(id, category.Id);
            Assert.AreEqual(title, category.Title);
            Assert.AreEqual(transactionCategories, category.TransactionCategories);
        }

        [Test]
        public void Title_Throws_WhenTooLong()
        {
            const int id = 42;
            var title = new string(A.Dummy<char>(), Category.TitleMaxLength + 1);
            var transactionCategories = new List<TransactionCategory>();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Category(id, title, transactionCategories));

            StringAssert.AreEqualIgnoringCase("Length for Title can't exceed 50.\r\nParameter name: value", ex.Message);
        }
    }
}