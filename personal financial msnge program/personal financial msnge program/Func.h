#include "Wallet.h"
#include <sstream>
#include <string>

namespace functions
{
	template<typename T>
	void saveInFile(T data, string fileName)
	{
		fileName += ".txt";

		ofstream file(fileName, ios::app);

		if (file.is_open())
			file << data;
		else throw invalid_argument("File not found!");

		file.close();
	}

	template <typename T>
	void loadFromFile(T**& downloadData, string fileName)
	{
		fileName += ".txt";

		ifstream file("fileName", ios::in);

		string data{};
		stringstream ss;

		if (file.is_open())
		{
			while (getline(file, data))
			{
				ss << data;
			}

		}

		else throw invalid_argument("File not found!");
	}

	void formationOfRatings(wallet wallets);
	void top3cost(wallet wallets);
	void top3category(wallet wallets);
	int getCurrentYear();
	void myCheck(string& str, regex regexCheck);

	wallet* addWallet();
	Tranzaction* addTransaction();
	HumanPersonalData* addPersonalData();
	Term* addDateOfExpiry();
};