#include <iostream>;
using namespace std;

struct list {

	char* name = new char[30] {};
	char* priority = new char[20] {};
	char* description = new char[100] {};
	char* createDate = new char[10] {};
	char* executionTime = new char[15] {};

	char* toString()
	{
		char* str = new char[1500]();
		sprintf_s(str, 2000, "%s\n%s\n%s\n%s\n%s\n", name, priority, description, createDate, executionTime);
		return str;
	}

	void print()
	{
		cout << "Name: " << name << endl
			<< "Priority: " << priority << endl
			<< "Description: " << description << endl
			<< "Created Date: " << createDate << endl
			<< "Execution Time: " << executionTime << endl;
	}
};

struct lists {
	
	char* name = new char[35] {};
	list* Notes{};
	int count{};

	void writeToFile() {

		FILE* file{};
		fopen_s(&file, "lists.txt", "a+");

		if(file == nullptr)
		{
			cout << "Error" << endl;
			return;
		}

		fprintf(file, "%s", Notes->toString());

		fclose(file);

	}

};





