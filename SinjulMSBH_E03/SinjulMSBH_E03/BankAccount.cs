using System;

namespace SinjulMSBH_E03
{
	public class BankAccount
	{
		private string m_customerName;

		private double m_balance;

		private bool m_frozen = false;

		public BankAccount ( )
		{
		}

		public BankAccount ( string customerName , double balance )
		{
			m_customerName = customerName;
			m_balance = balance;
		}

		public string CustomerName
		{
			get { return m_customerName; }
		}

		public double Balance
		{
			get { return m_balance; }
		}

		public void Debit ( double amount )
		{
			if ( m_frozen )
			{
				throw new Exception( "Account frozen" );
			}

			if ( amount > m_balance )
			{
				throw new ArgumentOutOfRangeException( "amount" );
			}

			if ( amount < 0 )
			{
				throw new ArgumentOutOfRangeException( "amount" );
			}

			//m_balance += amount;
			m_balance -= amount;
		}

		public void Credit ( double amount )
		{
			if ( m_frozen )
			{
				throw new Exception( "Account frozen" );
			}

			if ( amount < 0 )
			{
				throw new ArgumentOutOfRangeException( "amount" );
			}

			m_balance += amount;
		}

		public void FreezeAccount ( )
		{
			m_frozen = true;
		}

		public void UnfreezeAccount ( )
		{
			m_frozen = false;
		}
	}
}