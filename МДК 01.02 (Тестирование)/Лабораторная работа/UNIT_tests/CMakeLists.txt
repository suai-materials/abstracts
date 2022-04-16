cmake_minimum_required(VERSION 3.14)

project(UNIT_tests)

# GoogleTest requires at least C++11
set(CMAKE_CXX_STANDARD 11)

add_executable(UNIT_tests 1.cpp)
