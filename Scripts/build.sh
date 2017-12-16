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

exit $?
