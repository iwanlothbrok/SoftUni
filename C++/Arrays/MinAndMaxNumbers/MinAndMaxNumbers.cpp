#include <iostream>
#include <sstream>
#include <string>

using namespace std;

int main()
{
	//declare
	int n;
	cin >> n;

	int maxValue = INT16_MIN;
	//min max 
	int maxValue2 = INT32_MIN;
	int minValue = INT32_MAX;


	for (int i = 0; i < n; i++)
	{
		int number;
		cin >> number;

		//check for max value
		if (number > maxValue) {
			maxValue = number;
		}

		//check for min value 
		if (number < minValue) {
			minValue = number;
		}
	}
	cout << minValue << endl;
	cout << maxValue << endl;


	return 0;
}

