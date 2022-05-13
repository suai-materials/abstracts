#ifndef UNIT_TESTS_FACTORIAL_H
#define UNIT_TESTS_FACTORIAL_H

unsigned long long factorial(unsigned char num){ // Максимальный факториал - 21
    if (num > 21) throw EXIT_FAILURE;
    unsigned long long rez = 1;
    for (int i = 2; i <= num; i++){
        rez *= i;
    }
    return rez;
}

unsigned long long even_sum_fact(unsigned char num, unsigned char num2){
    if (num > num2 || num2 > 20) throw EXIT_FAILURE;
    unsigned long long sum = 0;
    for (int i = num; i <= num2; i++)
        if (i % 2 == 0)
            sum += factorial(i);
    return sum;
}

#endif //UNIT_TESTS_FACTORIAL_H
