#include <iostream>
#include <fstream>

using namespace std;

class WalletBalance
{
private:
	short right{};
	short left{};
public:
	WalletBalance() = default;

	WalletBalance(short _left, short _right);

	void operator+=(const WalletBalance _WalletBalance)
	{
		this->left += _WalletBalance.left;
		this->right += _WalletBalance.right;
		if (this->right >= 100)
		{
			this->left += 1;
			this->right -= 100;
		}
	}

	void operator -=(const WalletBalance _WalletBalance)
	{
		this->left -= _WalletBalance.left;
		if (this->right <= _WalletBalance.right)
		{
			this->left -= 1;
			this->right += 100;
			this->right = this->right % 100;
		}
	}

	bool operator <(const WalletBalance _WalletBalance)
	{
		return this->left < _WalletBalance.left || this->right < _WalletBalance.right;
	}

	bool operator >(const WalletBalance _WalletBalance)
	{
		return this->left > _WalletBalance.left || this->right > _WalletBalance.right;
	}

	friend ostream& operator<<(ostream& os, const WalletBalance _WalletBalance)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< _WalletBalance.left << endl
				<< _WalletBalance.right << endl;
		}
		os << _WalletBalance.left << '.' << _WalletBalance.right;
		return os;
	}

	friend istream& operator>>(istream& is, WalletBalance& _WalletBalance)
	{
		is >> _WalletBalance.left >> _WalletBalance.right;
		return is;
	}

	WalletBalance* checkAmount(string amount);
};
