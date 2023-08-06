#include "Card.h"

card::card(HumanPersonalData& _ownerData, string& _cardNumber, short& _CVV, WalletBalance& _balance, Term& _term)
{
	this->ownerData = new HumanPersonalData(_ownerData);
	this->cardNumber = _cardNumber;
	this->CVV = new short{ _CVV };
	this->term = new Term(_term);
	this->balance = new WalletBalance{ _balance };
}

std::string card::getCardNumber() const
{
	return this->cardNumber;
}

short card::getCVV() const
{
	return *this->CVV;
}

WalletBalance card::getBalance() const
{
	return *this->balance;
}