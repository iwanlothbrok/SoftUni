#include <iostream>
using namespace std;


int main()
{
	int arrLength;
	cout << "Insert value.\n";


	cin >> arrLength;


	int arr[arrLength] = {};

	if (arrLength > 4 || arrLength <= 0)
	{
		cout << "Invalid number!\n";
		return 0;
	}

	cout << arr[arrLength - 1];


	return 0;
}


