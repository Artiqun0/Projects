#include "WalletBalence.h"

WalletBalance :: WalletBalance(short _left, short _right)
{
    this->left = _left;
    this->right = _right;
}

WalletBalance* WalletBalance :: checkAmount(string amount)
{
    int checkRightLeft[3]{};

    size_t i = 0;
    for (; amount[i + 1] != '\0'; i++)
    {
        checkRightLeft[checkRightLeft[2]] += amount[i] - 48;
        if (amount[i + 1] == '.')
        {
            checkRightLeft[2]++;
            i++;
        }
        else
            checkRightLeft[checkRightLeft[2]] *= 10;
    }
    checkRightLeft[1] += amount[i] - 48;

    WalletBalance* balance = new WalletBalance(checkRightLeft[0], checkRightLeft[1]);

    return balance;
}