#!/bin/bash
# Build script for TinySoundFont library for Web/Emscripten
# Usage: ./build-tsf-web.sh [build_type]
# Example: ./build-tsf-web.sh Release

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
TSF_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
CMAKE_DIR="$SCRIPT_DIR"

# Use local emsdk when available (same as miniaudio convention)
WORKSPACE_ROOT="$(cd "$TSF_DIR/../.." && pwd)"
LOCAL_EMSDK_ENV="$WORKSPACE_ROOT/tools/emsdk/emsdk_env.sh"
if [ -f "$LOCAL_EMSDK_ENV" ]; then
    echo "Sourcing local emsdk: $LOCAL_EMSDK_ENV"
    source "$LOCAL_EMSDK_ENV"
fi

BUILD_TYPE="${1:-Release}"
EMSCRIPTEN_VERSION="3.1.56"

echo "=========================================="
echo "Building TinySoundFont for Web/Emscripten"
echo "Build Type: $BUILD_TYPE"
echo "Emscripten Version: $EMSCRIPTEN_VERSION"
echo "=========================================="

BUILD_TYPE_LOWER=$(echo "$BUILD_TYPE" | tr '[:upper:]' '[:lower:]')
BUILD_DIR="$TSF_DIR/build-emscripten-$BUILD_TYPE_LOWER"

echo "Cleaning build directory: $BUILD_DIR"
rm -rf "$BUILD_DIR"
mkdir -p "$BUILD_DIR"
cd "$BUILD_DIR"

emcmake cmake "$CMAKE_DIR" \
    -DCMAKE_BUILD_TYPE="$BUILD_TYPE"

cmake --build . --config "$BUILD_TYPE"

OUTPUT_LIB="$BUILD_DIR/libtsf.a"
if [ -f "$OUTPUT_LIB" ]; then
    echo "✓ Successfully built libtsf.a"
    ls -lh "$OUTPUT_LIB"

    OUTPUT_DIR="$TSF_DIR/libs/emscripten/x86/$BUILD_TYPE_LOWER"
    mkdir -p "$OUTPUT_DIR"
    cp "$OUTPUT_LIB" "$OUTPUT_DIR/tsf.a"

    echo "=========================================="
    echo "✓ Copied to: $OUTPUT_DIR/tsf.a"
    echo "=========================================="
else
    echo "✗ Failed to build libtsf.a"
    exit 1
fi
