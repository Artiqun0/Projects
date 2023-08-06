#include "Func.h"

int main()
{
	short walletsCount{};
	wallet** wallets = new wallet * [10] {};

	string choice{}, currentWallet = "0";

	if (wallets[0] == nullptr)
	{
		wallets[0] = functions::addWallet();
		functions::saveInFile(*wallets[0], "wallets");
		walletsCount++;
		system("cls");
	}
	else
	{
		while (true)
		{
			cout << "Enter current wallet: " << endl;
			for (size_t i = 0; i < walletsCount; i++)
			{
				cout << i + 1 << ". " << wallets[i]->getID() << endl;
			}
			while (stoi(currentWallet) <= 0 || stoi(currentWallet) > walletsCount)
			{
				cin >> currentWallet;
				functions::myCheck(currentWallet, regex("[0-9]{1,}"));
			}
			string security{};
			cout << "Enter security code: "; cin >> security;
			functions::myCheck(security, regex("[0-9]{4}"));

			if (wallets[stoi(currentWallet)]->getPassword() == stoi(security))
				break;
			system("cls");
			continue;
		}
	}

	while (true)
	{
		cout
			<< "1. Add Wallet" << endl
			<< "2. Add card" << endl
			<< "3. Wallet Replenishment" << endl
			<< "4. Card Replenishment" << endl
			<< "5. Add Transaction" << endl
			<< "6. Generating reports" << endl
			<< "7. Formation of ratings by maximum amounts" << endl
			<< "8. Formation of ratings by maximum category" << endl;
		cin >> choice;
		functions::myCheck(choice, regex("[1-8]{1}"));

		switch (stoi(choice))
		{
		case 1:
			wallets[walletsCount] = functions::addWallet();
			functions::saveInFile(*wallets[walletsCount], "wallets");
			walletsCount++;
			system("cls");
			break;
		case 2:
			wallets[stoi(currentWallet)]->addCard();
			functions::saveInFile(*wallets[stoi(currentWallet)]->cards[*wallets[stoi(currentWallet)]->cardsCount - 1], "cards");
			system("cls");
			break;
		case 3:
			wallets[stoi(currentWallet)]->walletReplenishment();
			system("cls");
			break;
		case 4:
			try {
				wallets[stoi(currentWallet)]->cardReplenishment();
			}
			catch (exception& e)
			{
				cout << e.what() << endl;
			}
			system("cls");
			break;
		case 5:
			wallets[stoi(currentWallet)]->Transactions[*wallets[stoi(currentWallet)]->tranasctionCount] = functions::addTransaction();
			functions::saveInFile(*wallets[stoi(currentWallet)]->Transactions[*wallets[stoi(currentWallet)]->tranasctionCount], "transaction");
			(*wallets[stoi(currentWallet)]->tranasctionCount)++;
			system("cls");
			break;
		case 6:
			functions::formationOfRatings(*wallets[stoi(currentWallet)]);
			system("cls");
			break;
		case 7:
			functions::top3cost(*wallets[stoi(currentWallet)]);
			break;
		case 8:
			functions::top3category(*wallets[stoi(currentWallet)]);
			break;
		}
	}

	return 0;
}