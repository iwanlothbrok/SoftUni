// IwansWork.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;


bool AreEqual(int firstArr[], int firstArrSize, int secondArr[], int secondArrSize);

int main()
{
	int firstArr[100];
	int secondArr[100];


	int firstArrSize;
	int secondArrSize;

	cout << "Write size of arr:";
	cin >> firstArrSize;

	for (int i = 0; i < firstArrSize; i++)
	{
		cout << "Write number ";
		cin >> firstArr[i];
	}

	cout << "Write size of the second arr:";
	cin >> secondArrSize;

	for (int i = 0; i < secondArrSize; i++)
	{
		cout << "Write number of " << i;
		cin >> secondArr[i];
	}

	AreEqual(firstArr, firstArrSize, secondArr, secondArrSize);
}


bool AreEqual(int firstArr[], int firstArrSize, int secondArr[], int secondArrSize)
{
	if (firstArrSize != secondArrSize)
	{
		return false;
	}

	for (int i = 0; i < firstArrSize; i++)
	{
		if (firstArr[i] != secondArr[i])
		{
			return false;
		}
	}
}