// 02.LongestSequence.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

int main()
{
	int arr[100];
	int arrSize;

	cin >> arrSize;

	for (int i = 0; i < arrSize; i++)
	{
		cin >> arr[i];
	}
	int counter = 0;

	for (int i = arrSize - 1; i >= 0; i--)
	{
		if (i == 0)
		{
			break;
		}
		int current = arr[i];
		int nextN = arr[i - 1];

		if (nextN == current)
		{
			cout << current << " " << nextN;
			counter++;
			break;
		}
	}

	if (counter == 0)
	{
		cout << arr[arrSize - 1];
	}
}
