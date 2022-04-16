#include<iostream>
#include<string>

using namespace std;

class Fraction{
private:
  int numerator; // числитель
  int denominator; // знаменатель
  void reduce(){
    int max = denominator > numerator? denominator: numerator;
    for (int i = 2; i < max / 2 + 1; i++){
	if (numerator % i == 0 && denominator % i == 0){
	  numerator /= i;
	  denominator /= i;
	  reduce();
	}
      }
    }
public:
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



int main(){
  int a, b;
  cout << "Write numerator" << endl;
  cin >> a;
  cout << "Write denominator" << endl;
  cin >> b;
  Fraction fr(a, b);
  Fraction fr2 = fr;
  cout << fr2;
  fr2 += fr;
  cout << fr2;
  Fraction fr3 = fr2 + fr2;
  cout << fr3;
  string str = "123";
}
