using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests
{
	[TestClass]
	public class BankAccountTests
	{
		// unit test code
		[TestMethod]
		public void Debit_WithValidAmount_UpdatesBalance ( )
		{
			// arrange
			double beginningBalance = 11.99;
			double debitAmount = 4.55;
			double expected = 7.44;
			BankAccountNT account = new BankAccountNT("Mr. Sinjul MSBH", beginningBalance);

			// act
			account.Debit( debitAmount );

			// assert
			double actual = account.Balance;
			Assert.AreEqual( expected , actual , 0.001 , "Account not debited correctly" );
		}

		//unit test method
		[TestMethod]
		[ExpectedException( typeof( ArgumentOutOfRangeException ) )]
		public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange ( )
		{
			// arrange
			double beginningBalance = 11.99;
			double debitAmount = -100.00;
			BankAccountNT account = new BankAccountNT("Mr. Sinjul MSBH", beginningBalance);

			// act
			account.Debit( debitAmount );

			// assert is handled by ExpectedException
		}

		[TestMethod]
		public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange ( )
		{
			// arrange
			double beginningBalance = 11.99;
			double debitAmount = 20.0;
			BankAccountNT account = new BankAccountNT("Mr. Sinjul MSBH", beginningBalance);

			// act
			try
			{
				account.Debit( debitAmount );
			}
			catch ( ArgumentOutOfRangeException e )
			{
				// assert
				StringAssert.Contains( e.Message , BankAccountNT.DebitAmountExceedsBalanceMessage );
			}
		}

		[TestMethod]
		public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange2 ( )
		{
			// arrange
			double beginningBalance = 11.99;
			double debitAmount = 20.0;
			BankAccountNT account = new BankAccountNT("Mr. Sinjul MSBH", beginningBalance);

			// act
			try
			{
				account.Debit( debitAmount );
			}
			catch ( ArgumentOutOfRangeException e )
			{
				// assert
				StringAssert.Contains( e.Message , BankAccountNT.DebitAmountExceedsBalanceMessage );
				return;
			}
			Assert.Fail( "No exception was thrown." );
		}
	}
}