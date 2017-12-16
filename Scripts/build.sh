#! /bin/sh

echo "Attempting to build Towerdefense for Windows"
  /opt/Unity/Editor/Unity \
    -batchmode \
    -nographics \
#    -silent-crashes \
#    -projectPath $(pwd) \
     -projectPath ./ \
    -buildWindowsPlayer "./Build/windows/$project.exe" \
-quit

echo "Attempting to build Towerdefense for Linux"
  /opt/Unity/Editor/Unity \
    -batchmode \
    -nographics \
    -silent-crashes \
    -logFile $(pwd)/unity.log \
#   -projectPath $(pwd)
    -projectPath ./ \
    -buildLinuxUniversalPlayer "$(pwd)/Build/linux/$project.exe" \
-quit

exit $?
