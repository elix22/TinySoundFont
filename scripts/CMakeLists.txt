cmake_minimum_required(VERSION 3.15)
project(tsf C)

set(TSF_ROOT "${CMAKE_CURRENT_SOURCE_DIR}/..")

# Emscripten produces a static lib; all other platforms produce a shared lib.
if(EMSCRIPTEN)
    add_library(tsf STATIC "${TSF_ROOT}/tsf.c")
else()
    add_library(tsf SHARED "${TSF_ROOT}/tsf.c")
endif()

target_include_directories(tsf PRIVATE "${TSF_ROOT}")

# iOS: build as a framework so code signing works on device.
if(APPLE AND CMAKE_SYSTEM_NAME STREQUAL "iOS")
    set_target_properties(tsf PROPERTIES
        FRAMEWORK TRUE
        MACOSX_FRAMEWORK_IDENTIFIER com.sokolnet.tsf
    )
endif()

# Linux / Android need the math library.
if(UNIX AND NOT APPLE)
    target_link_libraries(tsf PRIVATE m)
endif()

set_target_properties(tsf PROPERTIES OUTPUT_NAME "tsf")
