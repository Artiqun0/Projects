# include <iostream>
# include <string>
# include <fstream>
using namespace std;

class HumanPersonalData
{
private:
	string name{};
	string surname{};
	string patronomic{};
	short* dayOfBirth = new short{};
	short* monthOfBirth = new short{};
	short* yearOfBirth = new short{};

public:
	HumanPersonalData(string& _name, string& _surname, string& _patronomic, const short& _dayOfBirth, const short& _monthOfBirth, const short& _yearOfBirth);

	string getName() const;

	friend ostream& operator <<(ostream& os, const HumanPersonalData _personalData)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< _personalData.name << endl
				<< _personalData.surname << endl
				<< _personalData.patronomic << endl
				<< *_personalData.dayOfBirth << endl
				<< *_personalData.monthOfBirth << endl
				<< *_personalData.yearOfBirth << endl;
			return os;
		}
		os
			<< "Owner name: " << _personalData.name << endl
			<< "Owner surname: " << _personalData.surname << endl
			<< "Owner patronomic: " << _personalData.patronomic << endl
			<< "Owner date of birth: " << *_personalData.dayOfBirth << '.' << *_personalData.monthOfBirth << '.' << *_personalData.yearOfBirth << endl;
		return os;
	}

	friend istream& operator>>(istream& is, HumanPersonalData& _personalData)
	{
		is >> _personalData.name >> _personalData.surname >> _personalData.patronomic >> *_personalData.dayOfBirth >> *_personalData.monthOfBirth >> *_personalData.yearOfBirth;
		return is;
	}

	string getName()  ;
	string getSurname() const ;
	string getPatronomic() const ;
	short getDayOfBirth() const ;
	short getMonthOfBirth() const ;
	short getYearOfBirth() const ;

	~HumanPersonalData();
};