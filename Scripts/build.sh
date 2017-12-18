#! /bin/sh
# Example build script for Unity3D project. See the entire example: https://github.com/JonathanPorta/ci-build

# Change this the name of your project. This will be the name of the final executables as well.
project="Kellermächte-TD"
logFile=$(pwd)/Builds/build.log
username="Kellergemeinde"
password="Keller#12"

buildPlayer() {
    build=$1
    output=$2
    echo "Attempting to build $project for $build"
    /Applications/Unity/Unity.app/Contents/MacOS/Unity \
        -batchmode \
        -nographics \
        -silent-crashes \
        -logFile "$logFile" \
        -projectPath $(pwd) \
        -$build "$(pwd)/Builds/Windows/$project.$output" \
        -force-free \
        -quit
    echo 'Logs from latest build'
    cat $logFile
}

echo "travis_fold:start:build_win64"
    buildPlayer "buildWindows64Player" "64x.exe"
echo "travis_fold:end:build_win64"