#include "gtest/gtest.h"
#include "factorial.h"
#include "fraction.h"
#include "string"

TEST(FractionAddTest, ReduceCheckToOne) {
    Fraction fr1(2, 3);
    Fraction fr2(1, 3);
    Fraction fr3 = fr1 + fr2;
    EXPECT_EQ(fr3.numerator, 1);
    EXPECT_EQ(fr3.denominator, 1);
}

TEST(FractionAddTest, VariousDenominator) {
    Fraction fr1(2, 3);
    Fraction fr2(1, 9);
    Fraction fr3 = fr1 + fr2;
    EXPECT_EQ(fr3.numerator, 7);
    EXPECT_EQ(fr3.denominator, 9);
}

TEST(FractionAddTest, VariousDenominatorReduce) {
    Fraction fr1(2, 4);
    Fraction fr2(2, 5);
    Fraction fr3 = fr1 + fr2;
    EXPECT_EQ(fr3.numerator, 9);
    EXPECT_EQ(fr3.denominator, 10);
}

TEST(FractionAddTest, ImproperFractionResult) {
    Fraction fr1(2, 3);
    Fraction fr2(2, 3);
    Fraction fr3 = fr1 + fr2;
    EXPECT_EQ(fr3.numerator, 4);
    EXPECT_EQ(fr3.denominator, 3);
}

TEST(DisplayTest, OneToOneBadTest) {
    Fraction fr(1, 1);
    stringstream ss;
    ss <<
       fr;
    EXPECT_STREQ(" 1\n--- (1)\n 1\n", ss.str().c_str());
}

TEST(DisplayTest, OneToOneGoodTest) {
    Fraction fr(1, 1);
    stringstream ss;
    ss << fr;
    EXPECT_STREQ(" 1\n--- (1)\n 1\n\r\r", ss.str().c_str());
}

TEST(DisplayTest, IrrationalFraction) {
    Fraction fr(1, 3);
    stringstream ss;
    ss << fr;
    EXPECT_STREQ(" 1\n--- (0.333333)\n 3\n\r\r", ss.str().c_str());
}

TEST(FractionMultiplyTest, Multiply) {
    Fraction fr1(2, 3);
    Fraction fr2(2, 3);
    Fraction fr3 = fr1 * fr2;
    EXPECT_EQ(fr3.numerator, 4);
    EXPECT_EQ(fr3.denominator, 9);
}

TEST(FractionMultiplyTest, MultiplyAndReduce) {
    Fraction fr1(2, 3);
    Fraction fr2(1, 2);
    Fraction fr3 = fr1 * fr2;
    EXPECT_EQ(fr3.numerator, 1);
    EXPECT_EQ(fr3.denominator, 3);
}

TEST(FractionMultiplyTest, MultiplyWithNumber) {
    Fraction fr1(2, 3);
    Fraction fr3 = fr1 * 3;
    EXPECT_EQ(fr3.numerator, 2);
    EXPECT_EQ(fr3.denominator, 1);
}

TEST(FactorialBaseTest, ZeroFactorial){
    EXPECT_EQ(factorial(0), 1);
}

TEST(FactorialBaseTest, LessTenFactorial){
    EXPECT_EQ(factorial(1), 1);
    EXPECT_EQ(factorial(5), 120);
    EXPECT_EQ(factorial(9), 362880);
}

TEST(FactorialBaseTest, BigFactorial){
    EXPECT_STREQ(to_string(factorial(20)).c_str(), "2432902008176640000");
}
TEST(FactorialBaseTest_BigFactorial_Test, BadTest){
    EXPECT_STREQ(to_string(factorial(21)).c_str(), "51090942171709440000");
}

TEST(FactorialEvenSum, NUMS_EQUALS){
    EXPECT_EQ(even_sum_fact(0, 0), 1);
    EXPECT_EQ(even_sum_fact(1, 1), 0);
    EXPECT_EQ(even_sum_fact(2, 2), 2);
}

TEST(FactorialEvenSum, NUMS_NOT_EQUALS){
    EXPECT_EQ(even_sum_fact(0, 10), 3669867);
}

TEST(FactorialEvenSum_NUMS_NOT_EQUALS_Test, BIGGEST_NUMS){
    EXPECT_EQ(even_sum_fact(0, 20), 2439325392333218667);
}

