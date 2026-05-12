#!/bin/bash
# Build script for TinySoundFont library for Android
# Usage: ./build-tsf-android.sh [abi] [build_type]
# Example: ./build-tsf-android.sh arm64-v8a Release
# Supported ABIs: arm64-v8a, armeabi-v7a, x86_64

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
TSF_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
CMAKE_DIR="$SCRIPT_DIR"

ANDROID_ABI="${1:-arm64-v8a}"
BUILD_TYPE="${2:-Release}"
BUILD_DIR="$TSF_DIR/build-android-$ANDROID_ABI"

echo "=========================================="
echo "Building TinySoundFont for Android"
echo "ABI: $ANDROID_ABI"
echo "Build Type: $BUILD_TYPE"
echo "=========================================="

if [ -z "$ANDROID_NDK" ]; then
    if [ -z "$ANDROID_NDK_HOME" ]; then
        echo "Error: ANDROID_NDK or ANDROID_NDK_HOME environment variable not set"
        exit 1
    fi
    ANDROID_NDK="$ANDROID_NDK_HOME"
fi

if [ ! -d "$ANDROID_NDK" ]; then
    echo "Error: Android NDK not found at: $ANDROID_NDK"
    exit 1
fi

echo "Using Android NDK: $ANDROID_NDK"

ANDROID_NATIVE_API_LEVEL="${ANDROID_NATIVE_API_LEVEL:-26}"
echo "API Level: $ANDROID_NATIVE_API_LEVEL"

mkdir -p "$BUILD_DIR"
cd "$BUILD_DIR"

cmake "$CMAKE_DIR" \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK/build/cmake/android.toolchain.cmake" \
    -DANDROID_ABI="$ANDROID_ABI" \
    -DANDROID_NATIVE_API_LEVEL="$ANDROID_NATIVE_API_LEVEL" \
    -DANDROID_STL=c++_shared \
    -DANDROID_ARM_NEON=TRUE \
    -DCMAKE_BUILD_TYPE="$BUILD_TYPE"

cmake --build . --config "$BUILD_TYPE" -- -j$(nproc)

OUTPUT_LIB="$BUILD_DIR/libtsf.so"
if [ -f "$OUTPUT_LIB" ]; then
    echo "✓ Successfully built libtsf.so for $ANDROID_ABI"
    ls -lh "$OUTPUT_LIB"

    OUTPUT_DIR="$TSF_DIR/libs/android/$ANDROID_ABI/$(echo "$BUILD_TYPE" | tr '[:upper:]' '[:lower:]')"
    mkdir -p "$OUTPUT_DIR"
    cp "$OUTPUT_LIB" "$OUTPUT_DIR/"

    if [ "$BUILD_TYPE" = "Release" ]; then
        NDK_STRIP=$(find "$ANDROID_NDK/toolchains/llvm/prebuilt" -name "llvm-strip" 2>/dev/null | head -1)
        if [ -n "$NDK_STRIP" ]; then
            "$NDK_STRIP" --strip-unneeded "$OUTPUT_DIR/libtsf.so"
            echo "✓ Stripped debug symbols"
        fi
    fi

    echo "=========================================="
    echo "✓ Copied to: $OUTPUT_DIR/libtsf.so"
    echo "=========================================="
else
    echo "✗ Failed to build libtsf.so"
    exit 1
fi
