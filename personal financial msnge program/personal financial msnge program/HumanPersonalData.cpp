# include "HumanPersonalData.h"

HumanPersonalData :: HumanPersonalData(string& _name, string& _surname, string& _patronomic,
	const short& _dayOfBirth, const short& _monthOfBirth, const short& _yearOfBirth){

	this->name = _name;
	this->surname = _surname;
	this->patronomic = _patronomic;
	*this->dayOfBirth = _dayOfBirth;
	*this->monthOfBirth = _monthOfBirth;
	*this->yearOfBirth = _yearOfBirth;
}

string HumanPersonalData :: getName() const{

	return this->name;

}

string HumanPersonalData :: getSurname() const {

	return this->surname;

}

string HumanPersonalData :: getPatronomic() const {

	return this->patronomic;

}

short HumanPersonalData :: getDayOfBirth() const {

	return *this->dayOfBirth;
}

short HumanPersonalData::getMonthOfBirth() const {

	return *this->monthOfBirth;
}

short HumanPersonalData::getYearOfBirth() const {

	return *this->yearOfBirth;
}