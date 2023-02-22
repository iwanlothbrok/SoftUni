#include <iostream>
#include <sstream>
#include <string>

using namespace std;
const int maxSize = 100;


int main()
{
	int arr[maxSize];
	int arrSize;

	cin >> arrSize;

	for (int i = 0; i < arrSize; i++)
	{
		cin >> arr[i];
	}

	int absRecord = INT8_MAX;
	int absMin;

	for (int i = 0; i < arrSize; i++) {
		for (int k = 0; k < arrSize; k++) {

			if (i != k) {
				absMin = abs(arr[i] - arr[k]);


				if (absMin < absRecord) {
					absRecord = absMin;
				}
			}
		}
	}

	if (arrSize > 1) {
		cout << absRecord << endl;
	}
	else {
		cout << 0 << endl;
	}


	return 0;
}

