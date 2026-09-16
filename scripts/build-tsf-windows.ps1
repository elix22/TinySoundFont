# Build script for TinySoundFont library on Windows
# Usage: .\build-tsf-windows.ps1 [-Architecture <arch>] [-BuildType <type>]
# Example: .\build-tsf-windows.ps1 -Architecture x64 -BuildType Release
# Architectures: x64, Win32, ARM64

param(
    [string]$Architecture = "x64",
    [string]$BuildType = "Release"
)

$ErrorActionPreference = "Stop"

$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$TsfDir = Split-Path -Parent $ScriptDir
$CMakeDir = $ScriptDir
$BuildDir = Join-Path $TsfDir "build-windows-$Architecture"

Write-Host "==========================================" -ForegroundColor Cyan
Write-Host "Building TinySoundFont for Windows" -ForegroundColor Cyan
Write-Host "Architecture: $Architecture" -ForegroundColor Cyan
Write-Host "Build Type: $BuildType" -ForegroundColor Cyan
Write-Host "==========================================" -ForegroundColor Cyan

New-Item -ItemType Directory -Force -Path $BuildDir | Out-Null
Set-Location $BuildDir

Write-Host "Configuring CMake..." -ForegroundColor Yellow
# Don't hardcode the VS generator: the CI runner image's Visual Studio version moves over
# time (windows-latest was VS2022, the windows-2025 image now ships VS2026), and a stale
# "-G Visual Studio 17 2022" makes CMake fail with "could not find any instance of Visual
# Studio". Let CMake auto-select the installed Visual Studio; -A still picks the platform.
cmake $CMakeDir `
    -A $Architecture `
    -DCMAKE_BUILD_TYPE="$BuildType"

if ($LASTEXITCODE -ne 0) {
    Write-Host "✗ CMake configuration failed" -ForegroundColor Red
    exit 1
}

Write-Host "Building..." -ForegroundColor Yellow
cmake --build . --config $BuildType

if ($LASTEXITCODE -ne 0) {
    Write-Host "✗ Build failed" -ForegroundColor Red
    exit 1
}

$DllPath = Join-Path $BuildDir "$BuildType\tsf.dll"
if (Test-Path $DllPath) {
    Write-Host "✓ Successfully built tsf.dll" -ForegroundColor Green
    Get-Item $DllPath | Format-Table Name, Length, LastWriteTime

    $BuildTypeLower = $BuildType.ToLower()
    $OutputDir = Join-Path $TsfDir "libs\windows\$Architecture\$BuildTypeLower"
    New-Item -ItemType Directory -Force -Path $OutputDir | Out-Null
    Copy-Item $DllPath $OutputDir

    Write-Host "==========================================" -ForegroundColor Cyan
    Write-Host "✓ Copied to: $OutputDir\tsf.dll" -ForegroundColor Green
    Write-Host "==========================================" -ForegroundColor Cyan
} else {
    Write-Host "✗ Failed to build tsf.dll" -ForegroundColor Red
    exit 1
}
