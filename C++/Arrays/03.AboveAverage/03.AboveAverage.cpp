#include <iostream>
#include <sstream>
#include <string>
#include <algorithm>

using namespace std;

int main()
{
	int arr[100];
	int arrSize;

	double sum = 0.0;
	double average;

	cin >> arrSize;

	for (int i = 0; i < arrSize; i++)
	{
		cin >> arr[i];
	}

	//sort(arr, arr + arrSize);

	for (int i = 0; i < arrSize; i++)
	{
		sum += arr[i];
	}

	average = sum / arrSize - 1;

	for (int i = 0; i < arrSize; i++)
	{
		if (arr[i] >= average)
		{
			cout << arr[i] << ' ';
		}
	}
}