#include<iostream>
using namespace std;

int main(){
  int arr[10];
  int min;
  cout << "Enter 10 numbers" << endl;
  for (int i = 0; i < 10; i++){
    cin >> arr[i];
  }
  min = arr[0] + arr[5];
  for (int j = 1; j < 5; j++){
     if (min > arr[j] + arr[j + 5]) min = arr[j] + arr[j + 5];
  }
  cout << endl;
  cout << "Min number by formul:" << endl;
  cout << min << endl;
}
