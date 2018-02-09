using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SinjulMSBH_E03.Test
{
	public class MyBankAccountFix: IDisposable
	{
		public readonly BankAccount _bankAccount;
		public readonly BankAccount _bankAccount2;

		public MyBankAccountFix ( )
		{
			// arrange
			_bankAccount = new BankAccount( "SinjulMSBH" , 1300 );
			_bankAccount2 = new BankAccount( "SinjulMSBH" , 0 );
		}

		public void Dispose ( )
		{
		}
	}

	public class BankAccountTest: MyBankAccountFix
	{
		[Fact]
		public void Credit_FrozenTrue_GetException ( )
		{
			// act
			_bankAccount.FreezeAccount( );

			//assert
			Assert.Throws<Exception>( ( ) => _bankAccount.Credit( 1300 ) );
		}

		[Fact]
		public void Debit_FrozenTrue_GetException ( )
		{
			// act
			_bankAccount.FreezeAccount( );

			//assert
			Assert.Throws<Exception>( ( ) => _bankAccount.Debit( 1300 ) );
		}

		[Fact]
		public void Credit_WhenAmountIsThanZero_ShouldThrowArgumentOutOfRange ( )
		{
			// act
			_bankAccount2.Credit( 1300 );

			//assert
			Assert.Equal( 1300 , _bankAccount2.Balance );
		}

		[Fact]
		public void Debit_WhenAmountIsThanZero_ShouldThrowArgumentOutOfRange ( )
		{
			// act
			_bankAccount.Debit( 1300 );

			//assert
			Assert.Equal( 0 , _bankAccount.Balance );
		}

		[Fact]
		public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange ( ) =>
			Assert.Throws<ArgumentOutOfRangeException>( ( ) => _bankAccount.Credit( -1300 ) );

		[Fact]
		public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange ( ) =>
			Assert.Throws<ArgumentOutOfRangeException>( ( ) => _bankAccount.Debit( -1300 ) );

		[Fact]
		public void Debit_WithValidAmount_UpdatesBalance ( ) =>
			Assert.Throws<ArgumentOutOfRangeException>( ( ) => _bankAccount.Debit( 1700 ) );
	}
}