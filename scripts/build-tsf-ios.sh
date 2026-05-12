#!/bin/bash
# Build script for TinySoundFont library on iOS
# Usage: ./build-tsf-ios.sh [architecture] [build_type]
# Example: ./build-tsf-ios.sh arm64 Release

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
TSF_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
CMAKE_DIR="$SCRIPT_DIR"
BUILD_DIR="$TSF_DIR/build-xcode-ios"

ARCH="${1:-arm64}"
BUILD_TYPE="${2:-Release}"

echo "=========================================="
echo "Building TinySoundFont for iOS"
echo "Architecture: $ARCH"
echo "Build Type: $BUILD_TYPE"
echo "=========================================="

if [ "$ARCH" = "arm64" ]; then
    SDK="iphoneos"
    DEPLOYMENT_TARGET="13.0"
else
    SDK="iphonesimulator"
    DEPLOYMENT_TARGET="13.0"
fi

rm -rf "$BUILD_DIR"
mkdir -p "$BUILD_DIR"
cd "$BUILD_DIR"

cmake "$CMAKE_DIR" \
    -G Xcode \
    -DCMAKE_SYSTEM_NAME=iOS \
    -DCMAKE_OSX_ARCHITECTURES="$ARCH" \
    -DCMAKE_OSX_DEPLOYMENT_TARGET="$DEPLOYMENT_TARGET" \
    -DCMAKE_XCODE_ATTRIBUTE_DEVELOPMENT_TEAM="" \
    -DCMAKE_XCODE_ATTRIBUTE_CODE_SIGNING_ALLOWED=NO \
    -DCMAKE_BUILD_TYPE="$BUILD_TYPE"

cmake --build . --config "$BUILD_TYPE"

DEST_DIR="$TSF_DIR/libs/ios/$(echo "$BUILD_TYPE" | tr '[:upper:]' '[:lower:]')"
mkdir -p "$DEST_DIR"

OUTPUT_FRAMEWORK="$BUILD_DIR/$BUILD_TYPE-$SDK/tsf.framework"
if [ -d "$OUTPUT_FRAMEWORK" ]; then
    rm -rf "$DEST_DIR/tsf.framework"
    cp -R "$OUTPUT_FRAMEWORK" "$DEST_DIR/"
    echo "=========================================="
    echo "✓ Copied to: $DEST_DIR/tsf.framework"
    echo "=========================================="
else
    echo "✗ Failed to build tsf.framework — looking for any output:"
    find "$BUILD_DIR" -name "libtsf*" -o -name "tsf.framework" 2>/dev/null || true
    exit 1
fi
