#include <iostream>
#include "WalletBalence.h"

class Tranzaction
{
private:
	string senderID{};
	string recipientID{};
	short* sendDay{};
	short* sendMonth{};
	short* sendYear{};
	WalletBalance* sendAmount{};
	short* category{};
public:
	string categories[8]{ "Food", "Education", "Transport", "Health", "Utilities", "Clothes", "Entertainments", "Communications" };

	Tranzaction(string&, string&, short&, short&, short&, WalletBalance&, short&);

	friend ostream& operator << (ostream& os, const Tranzaction _Tranzaction)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< _Tranzaction.senderID << endl
				<< _Tranzaction.recipientID << endl
				<< *_Tranzaction.sendDay << endl
				<< *_Tranzaction.sendMonth << endl
				<< *_Tranzaction.sendYear << endl
				<< *_Tranzaction.sendAmount
				<< *_Tranzaction.category << endl;
			return os;
		}
		os
			<< "Sender ID: " << _Tranzaction.senderID << endl
			<< "Recipient ID: " << _Tranzaction.recipientID << endl
			<< "Date transaction: " << *_Tranzaction.sendDay << '.' << *_Tranzaction.sendMonth << '.' << *_Tranzaction.sendYear << endl
			<< "Send amount: " << *_Tranzaction.sendAmount << endl
			<< "Category: " << _Tranzaction.categories[*_Tranzaction.category - 1] << endl;
		return os;
	}

	friend istream& operator>>(istream& is, Tranzaction& _Transaction)
	{
		is >> _Transaction.senderID >> _Transaction.recipientID >> *_Transaction.sendDay >> *_Transaction.sendMonth >> *_Transaction.sendYear >>
			*_Transaction.sendAmount >> *_Transaction.category;
		return is;
	}

	string getSenderID() const;
	string getRecipientID() const;
	short getSendDay() const;
	short getSendMonth() const;
	short getSendYear() const;
	WalletBalance* getSendAmount() const;
	short getCategory() const;
};
