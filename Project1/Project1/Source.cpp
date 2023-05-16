#include "Header.h"

int lengh(char* object)
{
	int i{};
	while (object[i] != '\n')
	{
		i++;
	}
	return i;
}



