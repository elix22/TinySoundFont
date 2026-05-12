#!/bin/bash
# Build script for TinySoundFont library on macOS
# Usage: ./build-tsf-macos.sh [architecture] [build_type]
# Example: ./build-tsf-macos.sh arm64 Release
# Example: ./build-tsf-macos.sh x86_64 Release

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
TSF_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
CMAKE_DIR="$SCRIPT_DIR"

ARCH="${1:-arm64}"
BUILD_TYPE="${2:-Release}"
BUILD_DIR="$TSF_DIR/build-xcode-macos-$ARCH"

echo "=========================================="
echo "Building TinySoundFont for macOS"
echo "Architecture: $ARCH"
echo "Build Type: $BUILD_TYPE"
echo "=========================================="

mkdir -p "$BUILD_DIR"
cd "$BUILD_DIR"

cmake "$CMAKE_DIR" \
    -G Xcode \
    -DCMAKE_OSX_ARCHITECTURES="$ARCH" \
    -DCMAKE_OSX_DEPLOYMENT_TARGET="11.0" \
    -DCMAKE_BUILD_TYPE="$BUILD_TYPE"

cmake --build . --config "$BUILD_TYPE"

OUTPUT_LIB="$BUILD_DIR/$BUILD_TYPE/libtsf.dylib"

if [ -f "$OUTPUT_LIB" ]; then
    echo "✓ Successfully built libtsf.dylib"
    file "$OUTPUT_LIB"

    OUTPUT_DIR="$TSF_DIR/libs/macos/$ARCH/$(echo "$BUILD_TYPE" | tr '[:upper:]' '[:lower:]')"
    mkdir -p "$OUTPUT_DIR"
    cp "$OUTPUT_LIB" "$OUTPUT_DIR/"

    echo "=========================================="
    echo "✓ Copied to: $OUTPUT_DIR/libtsf.dylib"
    echo "=========================================="
    echo "Tip: to create a universal binary run both arm64 and x86_64 builds then:"
    echo "  lipo -create libs/macos/arm64/release/libtsf.dylib \\"
    echo "              libs/macos/x86_64/release/libtsf.dylib \\"
    echo "       -output libs/macos/universal/release/libtsf.dylib"
else
    echo "✗ Failed to build libtsf.dylib"
    exit 1
fi
