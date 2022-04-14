#include<iostream>
#include<string>

using namespace std;

class Fraction{
public:
  int numerator; // числитель
  int denominator; // знаменатель
  Fraction(int numerator, int denominator = 1){
    this->numerator = numerator;
    this->denominator = denominator;
  }

  friend ostream& operator << (ostream& os, Fraction& fr){
    string num_str = to_string(fr.numerator);
    string den_str = to_string(fr.denominator);
    // os << " " << num_str << " " << endl;
    
    if (den_str.size() > num_str.size()){
      for (int i = 0; i < den_str.size() / 2 + 1 - num_str.size() / 2; i++)
	os << " ";
      os << num_str << endl;
      os << "-";
      for (auto ch: den_str)
	os << "-";
      os << "-\n";
      os << " " << den_str << endl; 
    } else {
      os << " " << num_str << endl;
      os << "-";
      for (auto ch: num_str)
	os << "-";
      os << "-\n";
      for (int i = 0; i < num_str.size() / 2 + 1 - den_str.size() / 2; i++)
	os << " ";
      os << den_str << endl; 
    }
    
    
    return os;
  }

  Fraction& operator *=(Fraction &frac1){
    this->numerator *= frac1.numerator;
    this->denominator *= frac1.denominator;
    return *this;
  }
  Fraction& operator *=(int num){
    this->numerator *= num;
    return *this;
  }
  Fraction operator *(Fraction &frac1){
    return Fraction(numerator * frac1.numerator, denominator *= frac1.denominator) ;
  }
  Fraction operator *(int num){
    return Fraction(numerator * num, denominator) ;
  }

  Fraction& operator +=(Fraction &frac1){
    this->numerator += frac1.numerator;
    this->denominator *= frac1.denominator;
    return *this;
  }
};



int main(){
  int a, b;
  cout << "Write numerator" << endl;
  cin >> a;
  cout << "Write denominator" << endl;
  cin >> b;
  Fraction fr(a, b);
  Fraction fr2 = fr * 2;
  cout << fr2;
  string str = "123";
}
