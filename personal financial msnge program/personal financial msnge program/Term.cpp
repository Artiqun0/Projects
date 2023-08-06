#include "Term.h"

Term :: Term(short& _monthOfTerm, short& _yearOfTerm)
{
	this->monthOfTerm = new short{ _monthOfTerm };
	this->yearOfTerm = new short{ _yearOfTerm };
}

short Term :: getMonthOfTerm() const
{
	return *this->monthOfTerm;
}

short Term :: getYearOfTerm() const
{
	return *this->yearOfTerm;
}

Term :: ~Term()
{
	delete this->monthOfTerm;
	delete this->yearOfTerm;
}