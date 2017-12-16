#! /bin/sh

echo "Attempting to build $project for Windows"
  /opt/Unity/Editor/Unity \
    -batchmode \
    -nographics \
#    -silent-crashes \
    -projectPath $(pwd) \
    -buildWindowsPlayer "$(pwd)/Build/windows/$project.exe" \
-quit

exit $?
