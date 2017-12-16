#! /bin/sh

echo "Attempting to build Towerdefense for Windows"
  /opt/Unity/Editor/Unity \
    -batchmode \
    -nographics \
#    -silent-crashes \
#    -projectPath $(pwd) \
     -projectPath $(pwd)/ \
    -buildWindowsPlayer "./Build/windows/Towerdefense.exe" \
-quit

echo "Attempting to build Towerdefense for Linux"
  /opt/Unity/Editor/Unity \
    -batchmode \
    -nographics \
    -silent-crashes \
    -logFile $(pwd)/unity.log \
#   -projectPath $(pwd)
    -projectPath $(pwd)/ \
    -buildLinuxUniversalPlayer "$(pwd)/Build/linux/Towerdefense.exe" \
-quit

exit $?
