using System;
using FakeItEasy;
using NUnit.Framework;

namespace Usol.Wally.Domain.Models
{
    /// <summary>
    /// Tests for <see cref="TransactionCategory"/>
    /// </summary>
    public class TransactionCategoryTest
    {
        [Test]
        public void DefaultCtor_DoesntThrows()
        {
            Assert.DoesNotThrow(() => new TransactionCategory());
        }

        [Test]
        public void FullCtor_DoesntThrows()
        {
            const int id = 42;
            const int transactionId = 22;
            var transaction = new Transaction();
            const int categoryId = 22;
            var category = new Category();
            const int amount = 9;
            const string comment = "comment";

            Assert.DoesNotThrow(() => new TransactionCategory(id, transactionId, transaction,
                                                              categoryId, category, amount, comment));
        }

        [Test]
        public void AnyPropery_CanBeSet()
        {
            const int id = 42;
            const int transactionId = 22;
            var transaction = new Transaction();
            const int categoryId = 22;
            var category = new Category();
            const int amount = 9;
            const string comment = "comment";

            var transactionCategory = new TransactionCategory(id, transactionId, transaction,
                                                              categoryId, category, amount, comment);

            Assert.AreEqual(id, transactionCategory.Id);
            Assert.AreEqual(transactionId, transactionCategory.TransactionId);
            Assert.AreEqual(transaction, transactionCategory.Transaction);
            Assert.AreEqual(categoryId, transactionCategory.CategoryId);
            Assert.AreEqual(category, transactionCategory.Category);
            Assert.AreEqual(amount, transactionCategory.Amount);
            Assert.AreEqual(comment, transactionCategory.Comment);
        }

        [Test]
        public void Comment_Throws_WhenTooLong()
        {
            const int id = 42;
            const int transactionId = 22;
            var transaction = new Transaction();
            const int categoryId = 22;
            var category = new Category();
            const int amount = 9;
            var comment = new string(A.Dummy<char>(), TransactionCategory.CommentMaxLength + 1);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new TransactionCategory(id, transactionId, transaction,
                                                                                              categoryId, category, amount, comment));

            StringAssert.AreEqualIgnoringCase("Length for Comment can't exceed 90.\r\nParameter name: value", ex.Message);
        }
    }
}