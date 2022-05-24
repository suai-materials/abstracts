#include <iostream>
#include <time.h>

#define N 100000

using namespace std;




void shakerSort(int arr[N]) {
    int control = N - 1;
    int left  = 0;
    int right = N - 1;
    int temp;
    do {
        for (int i = left; i < right; i++) {
            if (arr[i] > arr[i + 1]) {
                std::swap(arr[i], arr[i + 1]);
                control = i;
            }
        }
        right = control;
        for (int i = right; i > left; i--) {
            if (arr[i] < arr[i - 1]) {
                std::swap(arr[i], arr[i - 1]);
                control = i;
            }
        }
        left = control;
    } while (left < right);
}

void selection_sort(int arr[N])
{
    for (int i = 0; i < N - 1; i++)
    {
        int min_index = i;
        for (int j = i + 1; j < N; j++)
        {
            if (arr[j] < arr[min_index])
            {
                min_index = j;
            }
        }
        if (min_index != i)
        {
            swap(arr[i], arr[min_index]);
        }
    }
}

void print_array(int arr[N]){
    for (int i = 0; i < N; i++)
        cout << arr[i] << " ";
    cout << endl;
}

int main() {
    int arr[N];
    for (int i = 0; i < N; i++) {
        arr[i] = rand() % N;
        cout << arr[i] << " ";
    }
    cout << endl;
    int copy_arr[N];
    copy(begin(arr), end(arr), begin(copy_arr));
    clock_t start = clock();
    selection_sort(arr);
    clock_t end = clock();
    double sec = (double)(end - start) / CLOCKS_PER_SEC;
    cout << "Selection sorting: " << sec << " sec. " << endl;
    start = clock();
    shakerSort(copy_arr);
    end = clock();
    sec = (double)(end - start) / CLOCKS_PER_SEC;
    cout << "Shaker sorting: " << sec << " sec. ";
}
