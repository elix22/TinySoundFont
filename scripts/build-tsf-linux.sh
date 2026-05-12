#!/bin/bash
# Build script for TinySoundFont library on Linux
# Usage: ./build-tsf-linux.sh [build_type]
# Example: ./build-tsf-linux.sh Release

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
TSF_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
CMAKE_DIR="$SCRIPT_DIR"
BUILD_DIR="$TSF_DIR/build-linux"

BUILD_TYPE="${1:-Release}"

echo "=========================================="
echo "Building TinySoundFont for Linux"
echo "Build Type: $BUILD_TYPE"
echo "=========================================="

if command -v clang &>/dev/null; then
    C_COMPILER="clang"
else
    C_COMPILER="${CC:-cc}"
fi
echo "Compiler: $C_COMPILER"

mkdir -p "$BUILD_DIR"
cd "$BUILD_DIR"

cmake "$CMAKE_DIR" \
    -DCMAKE_BUILD_TYPE="$BUILD_TYPE" \
    -DCMAKE_C_COMPILER="$C_COMPILER"

cmake --build . --config "$BUILD_TYPE" -- -j$(nproc)

OUTPUT_LIB="$BUILD_DIR/libtsf.so"
if [ -f "$OUTPUT_LIB" ]; then
    echo "✓ Successfully built libtsf.so"
    file "$OUTPUT_LIB"

    ARCH="X64"
    OUTPUT_DIR="$TSF_DIR/libs/linux/$ARCH/$(echo "$BUILD_TYPE" | tr '[:upper:]' '[:lower:]')"
    mkdir -p "$OUTPUT_DIR"
    cp "$OUTPUT_LIB" "$OUTPUT_DIR/"

    if [ "$BUILD_TYPE" = "Release" ]; then
        strip --strip-unneeded "$OUTPUT_DIR/libtsf.so"
        echo "✓ Stripped debug symbols"
    fi

    echo "=========================================="
    echo "✓ Copied to: $OUTPUT_DIR/libtsf.so"
    echo "=========================================="
else
    echo "✗ Failed to build libtsf.so"
    exit 1
fi
