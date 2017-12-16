#! /bin/sh

# Example build script for Unity3D project. See the entire example: https://github.com/JonathanPorta/ci-build

# Change this the name of your project. This will be the name of the final executables as well.
project="ci-build"
logFile=$(pwd)/Builds/build.log

echo "Attempting to build $project for Windows"
echo $(ls -lah ./Applications/Unity/Unity.app/Contents)
./Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $logFile \
  -projectPath $(pwd) \
  -buildWindowsPlayer "$(pwd)/Build/windows/$project.exe" \
  -quit

echo 'Logs from build'
cat $logFile