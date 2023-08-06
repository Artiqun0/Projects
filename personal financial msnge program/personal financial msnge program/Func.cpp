#pragma warning(disable : 4996)
#include "Func.h"
#include <ctime>

void functions::formationOfRatings(wallet wallet)
{
	string startDay = "0", startMonth = "0", endDay = "0", endMonth = "0";

	do {
		cout << "Enter start day: "; cin >> startDay;
		cout << "Enter start month: "; cin >> startMonth;
		functions::myCheck(startDay, regex("[0-9]{1,2}"));
		functions::myCheck(startMonth, regex("[0-9]{1,2}"));
	} while (stoi(startDay) <= 0 || :stoi(startDay) > 31 || stoi(startMonth) <= 0 || stoi(startMonth) > 12);

	do {
		cout << "Enter end day: "; cin >> endDay;
		cout << "Enter end month: "; cin >> endMonth;
		functions::myCheck(endDay, regex("[0-9]{1,2}"));
		functions::myCheck(endMonth, regex("[0-9]{1,2}"));
	} while (stoi(endDay) <= 0 || stoi(endDay) > 31 || stoi(endMonth) <= 0 || stoi(endMonth) > 12);

	WalletBalance amounts[8]{};
	for (size_t i = 0; i < *wallet.tranasctionCount; i++)
	{
		if (wallet.Transactions[i]->getSendDay() >= stoi(startDay) && wallet.Transactions[i]->getSendDay() <= stoi(endDay) &&
			wallet.Transactions[i]->getSendMonth() >= stoi(startMonth) && wallet.Transactions[i]->getSendMonth() <= stoi(endMonth))
		{
			amounts[wallet.Transactions[i]->getCategory() - 1] += *wallet.Transactions[i]->getSendAmount();
		}
	}

	for (size_t i = 0; i < 8; i++)
	{
		cout << wallet.Transactions[0]->categories[i] << ' ' << amounts[i] << endl;
	}
}

void functions::top3cost(wallet wallets)
{
	string startDay = "0", startMonth = "0", endDay = "0", endMonth = "0";

	do {
		cout << "Enter start day: "; cin >> startDay;
		cout << "Enter start month: "; cin >> startMonth;
		functions::myCheck(startDay, regex("[0-9]{1,2}"));
		functions::myCheck(startMonth, regex("[0-9]{1,2}"));
	} while (stoi(startDay) <= 0 || stoi(startDay) > 31 || stoi(startMonth) <= 0 || stoi(startMonth) > 12);

	do {
		cout << "Enter end day: "; cin >> endDay;
		cout << "Enter end month: "; cin >> endMonth;
		functions::myCheck(endDay, regex("[0-9]{1,2}"));
		functions::myCheck(endMonth, regex("[0-9]{1,2}"));
	} while (stoi(endDay) <= 0 || stoi(endDay) > 31 || stoi(endMonth) <= 0 || stoi(endMonth) > 12);

	WalletBalance top3[3]{};

	for (size_t i = 0; i < *wallets.tranasctionCount; i++)
	{
		if (wallets.Transactions[i]->getSendDay() >= stoi(startDay) && wallets.Transactions[i]->getSendDay() <= stoi(endDay) &&
			wallets.Transactions[i]->getSendMonth() >= stoi(startMonth) && wallets.Transactions[i]->getSendMonth() <= stoi(endMonth))
		{
			if (*wallets.Transactions[i]->getSendAmount() > top3[0])
			{
				top3[2] = top3[1];
				top3[1] = top3[0];
				top3[0] = *wallets.Transactions[i]->getSendAmount();
			}
			else if (*wallets.Transactions[i]->getSendAmount() > top3[1])
			{
				top3[2] = top3[1];
				top3[1] = *wallets.Transactions[i]->getSendAmount();
			}
			else if (*wallets.Transactions[i]->getSendAmount() > top3[2])
				top3[2] = *wallets.Transactions[i]->getSendAmount();
		}
	}

	for (size_t i = 0; i < 3; i++)
	{
		cout << i + 1 << ' ' << top3[i] << endl;
	}
}

void functions::top3category(wallet wallets)
{
	string startDay = "0", startMonth = "0", endDay = "0", endMonth = "0";

	do {
		cout << "Enter start day: "; cin >> startDay;
		cout << "Enter start month: "; cin >> startMonth;
		functions::myCheck(startDay, regex("[0-9]{1,2}"));
		functions::myCheck(startMonth, regex("[0-9]{1,2}"));
	} while (stoi(startDay) <= 0 || stoi(startDay) > 31 || stoi(startMonth) <= 0 || stoi(startMonth) > 12);

	do {
		cout << "Enter end day: "; cin >> endDay;
		cout << "Enter end month: "; cin >> endMonth;
		functions::myCheck(endDay, regex("[0-9]{1,2}"));
		functions::myCheck(endMonth, regex("[0-9]{1,2}"));
	} while (stoi(endDay) <= 0 || stoi(endDay) > 31 || stoi(endMonth) <= 0 || stoi(endMonth) > 12);

	WalletBalance amounts[8]{};

	for (size_t i = 0; i < *wallets.tranasctionCount; i++)
	{
		if (wallets.Transactions[i]->getSendDay() >= stoi(startDay) && wallets.Transactions[i]->getSendDay() <= stoi(endDay) &&
			wallets.Transactions[i]->getSendMonth() >= stoi(startMonth) && wallets.Transactions[i]->getSendMonth() <= stoi(endMonth))
		{
			amounts[wallets.Transactions[i]->getCategory() - 1] += *wallets.Transactions[i]->getSendAmount();
		}
	}

	int index{};
	for (size_t i = 0; i < 3; i++)
	{
		WalletBalance max{};
		for (size_t j = 0; j < 8; j++)
		{
			if (amounts[j] > max)
			{
				max = amounts[j];
				index = j;
			}
		}
		amounts[index] = WalletBalance{};
		cout << i + 1 << '.' << wallets.Transactions[0]->categories[index] << endl;
	}
}

int functions::getCurrentYear()
{
	time_t now = time(nullptr);
	tm* timeinfo = localtime(&now);
	int currentYear = timeinfo->tm_year + 1900;

	return currentYear;
}

void functions::myCheck(string& str, regex regexCheck)
{
	while (true)
	{
		if (!regex_match(str, regexCheck)) {
			cout << "Invalid input!" << endl;
			cout << "Please re-enter: " << endl; cin >> str;
			continue;
		}
		break;
	}
}

wallet* functions::addWallet()
{
	string ownerEmail{}, ownerPhone{}, currency{}, ID{};

	string checkData[3];

	HumanPersonalData* person = functions::addPersonalData();

	cout << "Enter owner email: " << endl; cin >> ownerEmail;
	functions::myCheck(ownerEmail, regex(R"(([a-zA-Z0-9](.|_)?)+([a-zA-Z0-9])+@([a-zA-Z0-9])+((.)[a-zA-Z]{2,})+)"));

	cout << "Enter owner phone: " << endl; cin >> ownerPhone;
	functions::myCheck(ownerPhone, regex("^[+]994[0-9]{9}$"));

	cout << "Enter wallet currency: " << endl; cin >> currency;
	functions::myCheck(currency, regex("[A-Z]{2,20}"));

	cout << "Enter wallet id: " << endl; cin >> ID;
	functions::myCheck(ID, regex("[0-9]{8}"));

	cout << "Enter security code: "; cin >> checkData[1];
	functions::myCheck(checkData[1], regex("[0-9]{4}"));
	short securityCode = stoi(checkData[1]);

	cout << "Enter balance: " << endl; cin >> checkData[2];
	functions::myCheck(checkData[2], regex("[0-9]{1,4}[.]?([0-9]{1,2})?"));
	WalletBalance* balance{};
	balance = balance->checkAmount(checkData[2]);

	wallet* w = new wallet(*person, ownerEmail, ownerPhone, currency, ID, securityCode, *balance);

	return w;
}

Tranzaction* functions::addTransaction()
{
	string senderID, recipientID{}, checkSendDay{}, checkSendMonth{}, checkSendYear{}, checkSendAmount{}, checkCategory{};
	short sendDay{}, sendMonth{}, sendYear = functions::getCurrentYear(), category{};
	WalletBalance* sendAmount{};

	cout << "Enter sender ID: " << endl; cin >> senderID;
	functions::myCheck(senderID, regex("[0-9]{8}|[0-9]{16}"));

	do {
		cout << "Enter recipient ID: " << endl; cin >> recipientID;
		functions::myCheck(recipientID, regex("[0-9]{8}|[0-9]{16}"));
	} while (senderID == recipientID);

	while (sendDay > 31 || sendDay <= 0)
	{
		cout << "Enter send day: " << endl; cin >> checkSendDay;
		functions::myCheck(checkSendDay, regex("[0-9]{1,2}"));
		sendDay = stoi(checkSendDay);
	}

	while (sendMonth > 12 || sendMonth <= 0)
	{
		cout << "Enter send month: " << endl; cin >> checkSendMonth;
		functions::myCheck(checkSendMonth, regex("[0-9]{1,2}"));
		sendMonth = stoi(checkSendMonth);
	}

	cout << "Enter amount for replenishment: "; cin >> checkSendAmount;
	functions::myCheck(checkSendAmount, regex("[0-9]{1,4}[.]?[0-9]{1,2}"));
	sendAmount = new WalletBalance(*sendAmount->checkAmount(checkSendAmount));

	cout
		<< "Enter category: " << endl
		<< "1. Food" << endl
		<< "2. Utilities" << endl
		<< "3. Transport" << endl
		<< "4. Health" << endl
		<< "5. Education" << endl
		<< "6. Entertaiments" << endl
		<< "7. Clothes" << endl
		<< "8. Communications" << endl;
	cin >> checkCategory;
	functions::myCheck(checkCategory, regex("[1-8]"));
	category = stoi(checkCategory);

	Tranzaction* t = new Tranzaction (senderID, recipientID, sendDay, sendMonth, sendYear, *sendAmount, category);

	return t;
}

HumanPersonalData* functions::addPersonalData()
{
	string name{}, surname{}, patronomic{}, checkDayOfBirth{}, checkMonthOfBirth{}, checkYearOfBirth{};
	uint16_t dayOfBirth{}, monthOfBirth{}, yearOfBirth{};

	cout << "Enter the owner's name: " << endl; cin >> name;
	functions::myCheck(name, regex("[A-Z]{2,20}"));

	cout << "Enter owner surname: " << endl; :cin >> surname;
	functions::myCheck(surname, regex("[A-Z]{2,20}"));

	cout << "Enter the patronymic of the owner: " << endl; :cin >> patronomic;
	functions::myCheck(patronomic, regex("[A-Z]{2,20}"));

	while (dayOfBirth == 0 || dayOfBirth > 31)
	{
		cout << "Enter the owner's birthday: " << endl; :cin >> checkDayOfBirth;
		functions::myCheck(checkDayOfBirth, regex("[0-9]{1,2}"));
		dayOfBirth = :stoi(checkDayOfBirth);
	}

	while (monthOfBirth == 0 || monthOfBirth > 12)
	{
		cout << "Enter the owner's month of birth: " << endl; cin >> checkMonthOfBirth;

		functions::myCheck(checkMonthOfBirth, regex("[0-9]{1,2}"));
		monthOfBirth = stoi(checkMonthOfBirth);
	}

	int currentYear = functions::getCurrentYear();

	while (yearOfBirth == 0 || currentYear - yearOfBirth < 18)
	{
		cout << "Enter the owner's year of birth: " << endl; cin >> checkYearOfBirth;
		functions::myCheck(checkYearOfBirth, regex("[0-9]{4}"));
		yearOfBirth = stoi(checkYearOfBirth);
	}

	HumanPersonalData* p = new HumanPersonalData(name, surname, patronomic, dayOfBirth, monthOfBirth, yearOfBirth);

	return p;
}

Term* functions::addDateOfExpiry()
{
	short monthOfExpiry{}, yearOfExpiry{};
	string checkMonthOfExpiry{}, checkYearOfExpiry{};

	int currentYear = functions::getCurrentYear();

	while (monthOfExpiry == 0 || monthOfExpiry > 12)
	{
		cout << "Enter month of expiry: " << endl; cin >> checkMonthOfExpiry;
		functions::myCheck(checkMonthOfExpiry, regex("[0-9]{1,2}"));
		monthOfExpiry = stoi(checkMonthOfExpiry);
	}

	while (yearOfExpiry == 0 || currentYear - yearOfExpiry > 10)
	{
		cout << "Enter year of expiry: " << endl; cin >> checkYearOfExpiry;
		functions::myCheck(checkYearOfExpiry, regex("[0-9]{4}"));
		yearOfExpiry = stoi(checkYearOfExpiry);
	}

	Term* d = new Term(monthOfExpiry, yearOfExpiry);

	return d;
}