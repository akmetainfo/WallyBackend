using System;
using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace Usol.Wally.Domain.Models
{
    /// <summary>
    /// Tests for <see cref="Transaction"/>
    /// </summary>
    public class TransactionTest
    {
        [Test]
        public void DefaultCtor_DoesntThrows()
        {
            Assert.DoesNotThrow(() => new Transaction());
        }

        [Test]
        public void FullCtor_DoesntThrows()
        {
            const int id = 42;
            var created = DateTime.Now;
            const int amountSource = 7;
            const int amountDestination = 9;
            const int sourceId = 14;
            var source = new Account();
            const int destinationId = 15;
            var destination = new Account();
            const bool @checked = true;
            const string comment = "comment";
            var transactionCategories = new List<TransactionCategory>();

            Assert.DoesNotThrow(() => new Transaction(id, created, amountSource, amountDestination,
                                                      sourceId, source, destinationId, destination,
                                                      @checked, comment, transactionCategories));
        }

        [Test]
        public void SimpleCtor_DoesntThrows()
        {
            const int id = 42;
            var created = DateTime.Now;
            const int amountSource = 7;
            const int amountDestination = 9;
            const int sourceId = 14;
            var source = new Account();
            const int destinationId = 15;
            var destination = new Account();
            const bool @checked = true;
            const string comment = "comment";

            Assert.DoesNotThrow(() => new Transaction(id, created, amountSource, amountDestination,
                                                      sourceId, source, destinationId, destination,
                                                      @checked, comment));
        }

        [Test]
        public void AnyPropery_CanBeSet()
        {
            const int id = 42;
            var created = DateTime.Now;
            const int amountSource = 7;
            const int amountDestination = 9;
            const int sourceId = 14;
            var source = new Account();
            const int destinationId = 15;
            var destination = new Account();
            const bool @checked = true;
            const string comment = "comment";
            var transactionCategories = new List<TransactionCategory>();

            var transaction = new Transaction(id, created, amountSource, amountDestination,
                                                      sourceId, source, destinationId, destination,
                                                      @checked, comment, transactionCategories);

            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(created, transaction.Created);
            Assert.AreEqual(amountSource, transaction.AmountSource);
            Assert.AreEqual(amountDestination, transaction.AmountDestination);
            Assert.AreEqual(sourceId, transaction.SourceId);
            Assert.AreEqual(source, transaction.Source);
            Assert.AreEqual(destinationId, transaction.DestinationId);
            Assert.AreEqual(destination, transaction.Destination);
            Assert.AreEqual(@checked, transaction.Checked);
            Assert.AreEqual(comment, transaction.Comment);
            Assert.AreEqual(transactionCategories, transaction.TransactionCategories);
        }

        [Test]
        public void Comment_Throws_WhenTooLong()
        {
            const int id = 42;
            var created = DateTime.Now;
            const int amountSource = 7;
            const int amountDestination = 9;
            const int sourceId = 14;
            var source = new Account();
            const int destinationId = 15;
            var destination = new Account();
            const bool @checked = true;
            var comment = new string(A.Dummy<char>(), Transaction.CommentMaxLength + 1);
            var transactionCategories = new List<TransactionCategory>();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Transaction(id, created, amountSource, amountDestination,
                                                                                      sourceId, source, destinationId, destination,
                                                                                      @checked, comment, transactionCategories));

            StringAssert.AreEqualIgnoringCase("Length for Comment can't exceed 150.\r\nParameter name: value", ex.Message);
        }
    }
}