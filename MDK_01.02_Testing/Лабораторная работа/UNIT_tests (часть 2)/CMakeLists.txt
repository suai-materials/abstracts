cmake_minimum_required(VERSION 3.14)

project(UNIT_tests)

add_subdirectory(.\\googletest)
include_directories(${gtest_SOURCE_DIR}\\include ${gtest_SOURCE_DIR})
set(CMAKE_CXX_STANDARD 17)

enable_testing()

add_executable(
        my_test
        tests.cpp
)
target_link_libraries(
        my_test
        gtest
        gtest_main
)
target_link_libraries(
        my_test
        gmock
        gmock_main
)