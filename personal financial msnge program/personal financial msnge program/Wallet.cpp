#include "Func.h"

wallet::wallet(HumanPersonalData& _ownerData, string& _ownerEmail, string& _ownerPhone, string& _currency,
	string& _ID, short& _securityCode, WalletBalance& _balance)
{
	this->data = new HumanPersonalData(_ownerData);
	this->ID = _ID;
	this->password = new short{ _securityCode };
	this->email = _ownerEmail;
	this->mobilePhone = _ownerPhone;
	this->balance = new	WalletBalance{ _balance };
	this->currency = _currency;
}

void wallet::addCard()
{
	string cardNumber{};

	string checkData[2]{};

	HumanPersonalData* person = functions::addPersonalData();

	cout << "Enter card number: " << endl; cin >> cardNumber;
	functions::myCheck(cardNumber, regex("[0-9]{16}"));

	Term* term = functions::addDateOfExpiry();

	cout << "Enter CVV: " << endl; cin >> checkData[0];
	functions::myCheck(checkData[0], regex("[0-9]{3}"));
	uint16_t CVV = stoi(checkData[0]);

	cout << "Enter balance: " << endl; cin >> checkData[1];
	functions::myCheck(checkData[1], regex("[0-9]{1,4}[.]?[0-9]{1,2}"));
	WalletBalance* balance{};
	balance = new WalletBalance{ *balance->checkAmount(checkData[1]) };

	this->cards[*this->cardsCount] = new card(*person, cardNumber, CVV, *balance, *term);

	(*this->cardsCount)++;
}

void wallet::cardReplenishment()
{
	string choice{};
	if (*this->cardsCount == 0)
		return;

	for (size_t i = 0; i < *this->cardsCount; i++)
		cout << i + 1 << ". " << this->cards[i]->getCardNumber() << endl;
	do {
		cout << "Choice card for replenishment: " << endl;
		cin >> choice;
		functions::myCheck(choice, :regex("[0-9]{1,}"));
	} while (stoi(choice) > *this->cardsCount || stoi(choice) <= 0);

	string checkAmount{};
	cout << "Enter amount for replenishment: "; cin >> checkAmount;
	functions::myCheck(checkAmount, regex("[0-9]{1,4}[.]?[0-9]{1,2}"));
	WalletBalance* amount{};
	amount = amount->checkAmount(checkAmount);
	if (*this->cards[stoi(choice)]->balance < *amount)
		throw invalid_argument("You don't have enough funds!");

	*this->cards[stoi(choice) - 1]->balance += *amount;
}

void wallet::walletReplenishment()
{
	string checkAmount{};
	cout << "Enter amount for replenishment: "; cin >> checkAmount;
	functions::myCheck(checkAmount, regex("[0-9]{1,4}[.]?[0-9]{1,2}"));
	WalletBalance* amount{};
	amount = amount->checkAmount(checkAmount);
	if (*this->balance < *amount)
		throw invalid_argument("You don't have enough funds!");

	*this->balance += *amount;
}

WalletBalance wallet::getBalance() const
{
	return *this->balance;
}

string wallet::getID() const
{
	return this->ID;
}

short wallet::getPassword() const
{
	return *this->password;
}

