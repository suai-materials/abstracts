#include<iostream>
#include<string>
#include <gtest/gtest.h>

using namespace std;

class Fraction{
private:
  
  void reduce(){
    int max = denominator > numerator? denominator: numerator;
    if (max == 1)
      return;
    for (int i = 2; i < max / 2 + 1; i++){
	if (numerator % i == 0 && denominator % i == 0){
	  numerator /= i;
	  denominator /= i;
	  reduce();
	}
      }
    if (numerator % max == 0 && denominator % max == 0){
	  numerator /= max;
	  denominator /= max;
	  reduce();
	}
    }
  
public:
  // Могут быть приватными, но для облегчения тестов лежат здесь. 
  int numerator; // числитель
  int denominator; // знаменатель
  Fraction(int numerator, int denominator = 1){
    this->numerator = numerator;
    this->denominator = denominator;
    reduce();
  }

  friend ostream& operator << (ostream& os, Fraction& fr){
    string num_str = to_string(fr.numerator);
    string den_str = to_string(fr.denominator);
    // os << " " << num_str << " " << endl;
    
    if (den_str.size() > num_str.size()){
      for (int i = 0; i < den_str.size() / 2 + 1 - (num_str.size() % 2 == 0 ? num_str.size() / 2: num_str.size() / 2 + 1); i++)
	os << " ";
      os << num_str << endl;
      os << "-";
      for (auto ch: den_str)
	os << "-";
      os << "-" << " (" << (fr.numerator / 1.0f) / fr.denominator << ")" << endl;
      os << " " << den_str << endl; 
    } else {
      os << " " << num_str << endl;
      os << "-";
      for (auto ch: num_str)
	os << "-";
      os << "-" << " (" << (fr.numerator / 1.0f) / fr.denominator << ")" << endl;
      for (int i = 0; i < num_str.size() / 2 + 1 - den_str.size() / 2; i++)
	os << " ";
      os << den_str << endl; 
    }
    os << '\r' << '\r';
    return os;
  }

  Fraction& operator *=(Fraction &frac1){
    this->numerator *= frac1.numerator;
    this->denominator *= frac1.denominator;
    reduce();
    return *this;
  }
  Fraction& operator *=(int num){
    Fraction fr(num, 1);
    *this *= fr;
    return *this;
  }
  Fraction operator *(Fraction &frac1){
    return Fraction(numerator * frac1.numerator, denominator *= frac1.denominator) ;
  }
  Fraction operator *(int num){
    return Fraction(numerator * num, denominator) ;
  }

  Fraction& operator +=(Fraction &frac1){
    numerator *= frac1.denominator;
    frac1.numerator *= denominator; 
    this->numerator += frac1.numerator;
    this->denominator *= frac1.denominator;
    reduce();
    return *this;
  }
  Fraction operator +(Fraction &frac1){
    Fraction fr(numerator, denominator);
    fr += frac1;
    return fr;
  }
};



// int main(){
//    int a, b;
//    cout << "Write numerator" << endl;
//    cin >> a;
//    cout << "Write denominator" << endl;
//    cin >> b;
//    Fraction fr(a, b);
//    Fraction fr2 = fr;
//    cout << fr2;
//    fr2 += fr;
//    cout << fr2;
//    Fraction fr3 = fr2 + fr2;
//    cout << fr3;
//    string str = "123";
// }

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

TEST(FractionAddTest, ImproperFractionResult){
  Fraction fr1(2, 3);
  Fraction fr2(2, 3);
  Fraction fr3 = fr1 + fr2;
  EXPECT_EQ(fr3.numerator, 4);
  EXPECT_EQ(fr3.denominator, 3);
}

TEST(DisplayTest, OneToOneBadTest){
  Fraction fr(1, 1);
  stringstream ss;
  ss << fr;
  EXPECT_STREQ(" 1\n--- (1)\n 1\n", ss.str().c_str());
}

TEST(DisplayTest, OneToOneGoodTest){
  Fraction fr(1, 1);
  stringstream ss;
  ss << fr;
  EXPECT_STREQ(" 1\n--- (1)\n 1\n\r\r", ss.str().c_str());
}

TEST(DisplayTest, IrrationalFraction){
  Fraction fr(1, 3);
  stringstream ss;
  ss << fr;
  EXPECT_STREQ(" 1\n--- (0.333333)\n 3\n\r\r", ss.str().c_str());
}

TEST(FractionMultiplyTest, Multiply){
  Fraction fr1(2, 3);
  Fraction fr2(2, 3);
  Fraction fr3 = fr1 * fr2;
  EXPECT_EQ(fr3.numerator, 4);
  EXPECT_EQ(fr3.denominator, 9);
}

TEST(FractionMultiplyTest, MultiplyAndReduce){
  Fraction fr1(2, 3);
  Fraction fr2(1, 2);
  Fraction fr3 = fr1 * fr2;
  EXPECT_EQ(fr3.numerator, 1);
  EXPECT_EQ(fr3.denominator, 3);
}

TEST(FractionMultiplyTest, MultiplyWithNumber){
  Fraction fr1(2, 3);
  Fraction fr3 = fr1 * 3;
  EXPECT_EQ(fr3.numerator, 2);
  EXPECT_EQ(fr3.denominator, 1);
}
