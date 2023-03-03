#include <iostream>
#include "ReverseArr.h"
using namespace std;


int main()
{

	int arrLength;
	cin >> arrLength;


	int arr[]{};

	if (arrLength > 4 || arrLength <= 0)
	{
		cout << "Invalid number!\n";
		return 0;
	}

	cout << arr[arrLength - 1];


	return 0;
}


