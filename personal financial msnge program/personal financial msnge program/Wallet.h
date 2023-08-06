#include "card.h"

class wallet
{
private:
	string ID{};
	short* password{};
	WalletBalance* balance{};

public:
	short* cardsCount = new short{};
	card** cards = new card * [10];
	HumanPersonalData* data{};
	string email{};
	string mobilePhone{};
	string currency{};
	short* dailySpendingLimit{};
	Tranzaction** Transactions = new Tranzaction * [50] {};
	short* tranasctionCount = new short{};

	wallet(HumanPersonalData&, string&, string&, string&, string&, short&, WalletBalance&);

	friend ostream& operator << (ostream& os, const wallet _wallet)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< *_wallet.data
				<< _wallet.email << endl
				<< _wallet.mobilePhone << endl
				<< _wallet.ID << endl
				<< *_wallet.password << endl
				<< _wallet.currency << endl
				<< *_wallet.balance << endl;
			for (size_t i = 0; i < *_wallet.cardsCount; i++)
			{
				os << _wallet.cards[i]->getCardNumber();
			}return os;
		}
		os
			<< *_wallet.data
			<< "Owner email: " << _wallet.email << endl
			<< "Owner phone: " << _wallet.mobilePhone << endl
			<< "Wallet ID: " << _wallet.ID << endl
			<< "Wallet security code: " << *_wallet.password << endl
			<< "Wallet currency: " << _wallet.currency << endl
			<< "Balance: " << *_wallet.balance
			<< "Cards in wallet: " << endl;
		for (size_t i = 0; i < *_wallet.cardsCount; i++)
		{
			os << "Card number: " << _wallet.cards[i]->getCardNumber();
		}
		return os;
	}

	friend istream& operator>>(istream& is, wallet& _wallet)
	{
		is >> *_wallet.data >> _wallet.mobilePhone >> _wallet.ID >> *_wallet.password >> _wallet.currency >> *_wallet.balance;
	}

	void addCard();
	void cardReplenishment();
	void walletReplenishment();

	WalletBalance getBalance() const;
	string getID() const;
	short getPassword() const;
};