#include <iostream>
#include <Windows.h>
#include <ctime>
using namespace std;
// 22:15 17.05.2023 importing library 

void getClick(int& x, int& y)
{
	HANDLE hConsoleIn = GetStdHandle(STD_INPUT_HANDLE);
	INPUT_RECORD inputRec;
	DWORD events;
	COORD coord;
	bool clicked = false;

	DWORD fdwMode = ENABLE_EXTENDED_FLAGS | ENABLE_WINDOW_INPUT | ENABLE_MOUSE_INPUT;
	SetConsoleMode(hConsoleIn, fdwMode);

	while (!clicked) {

		ReadConsoleInput(hConsoleIn, &inputRec, 1, &events);

		if (inputRec.EventType == MOUSE_EVENT) {
			if (inputRec.Event.MouseEvent.dwButtonState == FROM_LEFT_1ST_BUTTON_PRESSED) {
				coord = inputRec.Event.MouseEvent.dwMousePosition;
				x = coord.X;
				y = coord.Y;
				clicked = true;
			}
		}
		if (GetAsyncKeyState(VK_ESCAPE)) {
			cout << "Exiting" << endl;
			break;
		}
		else if (inputRec.EventType == KEY_EVENT) {
		}
	}
}
// 22:35 17.05.2023 using function to use mouse

void createField(int*& field, int y, int size)
{
	field = new int[size] {};
	int* count = new int[size] {};

	srand(time(0));
	int random{};
	for (int i = 0; i < size; i++)
	{
		random = rand() % (size / 2) + 1;
		if (count[random - 1] < 2)
		{
			field[i] = random;
			count[random - 1]++;
		}
		else
		{
			i--;
		}
	}
}
// 22:58 17.05.2023 function to crete fields

void printField(int* field, int numbers[], int size, int choise, int& boolean)
{
	system("cls");
	for (int i = 0; i < size; i++)
	{
		if (choise == numbers[i])
		{
			if (field[i] != 20)
			{
				cout << "\t" << field[i];
				boolean = i;
			}
			else cout << "\t ";
		}
		else
		{
			if (field[i] != 20) cout << "\t* ";
			else cout << "\t ";
		}
		if ((i + 1) % 4 == 0) cout << endl;
	}
}

// 23:10 17.05.2023 function to cout fields

int main() 
{
	int* field{};
	char word{};
	bool stop = true;
	int numbers[33]{ 80, 160, 240, 320, 81, 161, 241, 321, 82, 162, 242, 322, 83, 163, 243
		, 323, 84, 164, 244, 324, 85, 165, 245, 325};
	int s{}, x{}, y{}, size{}, moveCount{}, per{}, time1 = time(0), 
		choice1{}, choice2{}, first = 50, second = 50;
	// 23:15 17.05.2023 declaration variables

	cout << "Enter field size: " << endl
		 << "1. 4x4" << endl
		 << "2. 6x6" << endl;
	getClick(x, y);
	while (y < 1 && y > 3)
	{
		cout << "Invalid input, enter again pls: " << endl;
		getClick(x, y);
	}
	while (y != 1 && y != 2)
	{
		getClick(x, y);
	}
	if (y == 1) size = 16;
	else if (y == 2) size = 32;

	createField(field, y, size);

	while (stop)
	{
		system("cls");
		for (int i = 0; i < size; i++)
		{
			if (field[i] != 20) cout << "\t* ";
			else cout << "\t ";

			if ((i + 1) % 4 == 0) cout << endl;
		}

		while (per == 0)
		{
			getClick(x, y);
			choice1 = (x *= 10) + y;
			for (int i = 0; numbers[i] != 0; i++)
			{
				if (choice1 == numbers[i])
				{
					per++;
					break;
				}
			}
		}


		printField(field, numbers, size, choice1, first);
		choice2 = choice1;
		per--;
		while (choice2 == choice1)
		{
			while (per == 0)
			{
				getClick(x, y);
				choice2 = (x *= 10) + y;
				for (int i = 0; numbers[i] != 0; i++)
				{
					if (choice2 == numbers[i])
					{
						per++;
						break;
					}
				}
			}
			per--;
		}

		printField(field, numbers, size, choice2, second);

		if (field[second] == field[first])
		{
			field[second] = 20;
			field[first] = 20;
		}
		int s{};
		for (int i = 0; i < size; i++)
		{
			if (field[i] == 20) s++;
		}
		moveCount++;
		if (s == size)
		{
			system("cls");
			cout << "You win!" << endl;
			stop = false;
			break;
		}

		cout << "Enter anything to continue: ";
		cin >> word;
	}
	
	int time2 = int(time(0)) - time1;
	cout << "You win in: " << time2 << " seconds!" << endl;
	cout << "For: " << moveCount << " moves";
	cin.ignore();

	return 0;
}
