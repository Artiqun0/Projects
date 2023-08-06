#include "Term.h"
#include "HumanPersonalData.h"
#include "Tranzaction.h"

class card
{
protected:

	string cardNumber{};
	short* CVV{};

public:

	HumanPersonalData* ownerData{};
	Term* term{};
	WalletBalance* balance{};

	card(HumanPersonalData&, string&, short&, WalletBalance&, Term&);

	friend ostream& operator <<(ostream& os, const card _card)
	{
		if (typeid(os) == typeid(std::ofstream))
		{
			os
				<< *_card.ownerData
				<< _card.cardNumber << endl
				<< *_card.CVV << endl
				<< *_card.term
				<< *_card.balance << endl;
		}
		os
			<< *_card.ownerData
			<< "Card number: " << _card.cardNumber << endl
			<< "CVV: " << *_card.CVV << endl
			<< *_card.term
			<< "Balance: " << *_card.balance << endl;
		return os;
	}

	friend istream& operator>>(istream& is, card& _card)
	{
		is >> *_card.ownerData >> _card.cardNumber >> *_card.CVV >> *_card.term >> *_card.balance;
		return is;
	}

	string getCardNumber() const;
	short getCVV() const;
	WalletBalance getBalance() const;
};