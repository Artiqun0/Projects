# include <iostream>
#include <fstream>

using namespace std;

class Term {
private:
	short* monthOfTerm{};
	short* yearOfTerm{};

public:
	Term(short& _monthOfTerm, short& _yearOfTerm);

	friend ostream& operator << (ostream& os, Term _dateOfTerm)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< *_dateOfTerm.monthOfTerm << endl
				<< *_dateOfTerm.yearOfTerm << endl;
		}
		os << "Date of Expiry: " << *_dateOfTerm.monthOfTerm << '.' << *_dateOfTerm.yearOfTerm << endl;
		return os;
	}

	friend istream& operator>>(istream& is, Term& _dateOfTerm)
	{
		is >> *_dateOfTerm.monthOfTerm >> *_dateOfTerm.yearOfTerm;
		return is;
	}

	short getMonthOfTerm() const;
	short getYearOfTerm() const;
	
	~Term();
};
