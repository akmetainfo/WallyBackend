using System;
using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace Usol.Wally.Domain.Models
{
    /// <summary>
    /// Tests for <see cref="Account"/>
    /// </summary>
    public class AccountTest
    {
        [Test]
        public void DefaultCtor_DoesntThrows()
        {
            Assert.DoesNotThrow(() => new Account());
        }

        [Test]
        public void FullCtor_DoesntThrows()
        {
            const int id = 42;
            const string title = "title";
            const string notes = "notes";
            const bool isActive = false;
            const bool isCorrespondent = true;
            const int currencyId = 2;
            var currency = new Currency();
            var sourceTransactions = new List<Transaction>();
            var destinationTransactions = new List<Transaction>();

            Assert.DoesNotThrow(() => new Account(id, title, notes, isActive, isCorrespondent,
                                                  currencyId, currency, sourceTransactions, destinationTransactions));
        }

        [Test]
        public void SimpleCtor_DoesntThrows()
        {
            const int id = 42;
            const string title = "title";
            const string notes = "notes";
            const bool isActive = false;
            const bool isCorrespondent = true;
            const int currencyId = 2;
            var currency = new Currency();

            Assert.DoesNotThrow(() => new Account(id, title, notes, isActive, isCorrespondent, currencyId, currency));
        }

        [Test]
        public void AnyPropery_CanBeSet()
        {
            const int id = 42;
            const string title = "title";
            const string notes = "notes";
            const bool isActive = false;
            const bool isCorrespondent = true;
            const int currencyId = 2;
            var currency = new Currency();
            var sourceTransactions = new List<Transaction>();
            var destinationTransactions = new List<Transaction>();

            var account = new Account(id, title, notes, isActive, isCorrespondent,
                                      currencyId, currency, sourceTransactions, destinationTransactions);

            Assert.AreEqual(id, account.Id);
            Assert.AreEqual(title, account.Title);
            Assert.AreEqual(notes, account.Notes);
            Assert.AreEqual(isActive, account.IsActive);
            Assert.AreEqual(isCorrespondent, account.IsCorrespondent);
            Assert.AreEqual(currencyId, account.CurrencyId);
            Assert.AreEqual(currency, account.Currency);
            Assert.AreEqual(sourceTransactions, account.SourceTransactions);
            Assert.AreEqual(destinationTransactions, account.DestinationTransactions);
        }

        [Test]
        public void Title_Throws_WhenTooLong()
        {
            const int id = 42;
            var title = new string(A.Dummy<char>(), Account.TitleMaxLength + 1);
            const string notes = "notes";
            const bool isActive = false;
            const bool isCorrespondent = true;
            const int currencyId = 2;
            var currency = new Currency();
            var sourceTransactions = new List<Transaction>();
            var destinationTransactions = new List<Transaction>();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Account(id, title, notes, isActive, isCorrespondent,
                                                                                  currencyId, currency, sourceTransactions, destinationTransactions));

            StringAssert.AreEqualIgnoringCase("Length for Title can't exceed 50.\r\nParameter name: value", ex.Message);
        }

        [Test]
        public void Notes_Throws_WhenTooLong()
        {
            const int id = 42;
            const string title = "title";
            var notes = new string(A.Dummy<char>(), Account.NotesMaxLength + 1);
            const bool isActive = false;
            const bool isCorrespondent = true;
            const int currencyId = 2;
            var currency = new Currency();
            var sourceTransactions = new List<Transaction>();
            var destinationTransactions = new List<Transaction>();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Account(id, title, notes, isActive, isCorrespondent,
                                                                                  currencyId, currency, sourceTransactions, destinationTransactions));

            StringAssert.AreEqualIgnoringCase("Length for Notes can't exceed 50.\r\nParameter name: value", ex.Message);
        }
    }
}