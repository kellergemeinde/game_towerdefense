#! /bin/sh

# Example build script for Unity3D project. See the entire example: https://github.com/JonathanPorta/ci-build

# Change this the name of your project. This will be the name of the final executables as well.
project="Kellermächte-TD"
logFile=$(pwd)/Builds/build.log
username="Kellergemeinde"
password="Keller#12"
echo $username
echo $password

echo "travis_fold:start:build_win64"
echo "Attempting to build $project for Windows"
echo $(ls -la /opt/Unity/Editor/Unity)
/opt/Unity/Editor/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $logFile \
  -projectPath $(pwd) \
  -buildWindows64Player  "$(pwd)/Builds/Windows/$project.64x.exe" \
  -force-free \
  -username "$username"
  -pasword "$password"
  -quit

echo 'Logs from latest build'
cat $logFile
echo "travis_fold:end:build_win64"