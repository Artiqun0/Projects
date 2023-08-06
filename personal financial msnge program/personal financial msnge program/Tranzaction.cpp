#include "Tranzaction.h"

Tranzaction :: Tranzaction(string& _senderID, string& _recipientID, short& _sendDay, short& _sendMonth, short& _sendYear,
	WalletBalance& _sendAmount, short& _category)
{
	this->senderID = _senderID;
	this->recipientID = _recipientID;
	this->sendDay = new short{ _sendDay };
	this->sendMonth = new short{ _sendMonth };
	this->sendYear = new short{ _sendYear };
	this->sendAmount = new WalletBalance{ _sendAmount };
	this->category = new short{ _category };
}

string Tranzaction :: getSenderID() const
{
	return this->senderID;
}

string Tranzaction :: getRecipientID() const
{
	return this->recipientID;
}

short Tranzaction :: getSendDay() const
{
	return *this->sendDay;
}

short Tranzaction :: getSendMonth() const
{
	return *this->sendMonth;
}

short Tranzaction :: getSendYear() const
{
	return *this->sendYear;
}

WalletBalance* Tranzaction :: getSendAmount() const
{
	return this->sendAmount;
}

short Tranzaction :: getCategory() const
{
	return *this->category;
}