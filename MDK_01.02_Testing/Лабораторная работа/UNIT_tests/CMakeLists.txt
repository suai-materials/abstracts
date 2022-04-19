cmake_minimum_required(VERSION 3.14)

project(UNIT_tests)



include(FetchContent)
FetchContent_Declare(
  googletest
  URL https://github.com/google/googletest/archive/609281088cfefc76f9d0ce82e1ff6c30cc3591e5.zip
)
# For Windows: Prevent overriding the parent project's compiler/linker settings
set(gtest_force_shared_crt ON CACHE BOOL "" FORCE)
FetchContent_MakeAvailable(googletest)

set(CMAKE_CXX_STANDARD 17)

enable_testing()

add_executable(
  my_test
  1.cpp
)
target_link_libraries(
  my_test
  gtest_main
)

include(GoogleTest)
gtest_discover_tests(my_test)