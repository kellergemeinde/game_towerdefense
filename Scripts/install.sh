#! /bin/sh
BASE_URL=http://netstorage.unity3d.com/unity
HASH=94bf3f9e6b5e
VERSION=2017.2.1f1
PLATFORM=osx

installPackage() {
	package=$1
	url="$BASE_URL/$HASH/$package"
	echo "Downloading from $url: "
	curl -o `basename "$package"` "$url"
	echo "Installing "`basename "$package"`
	sudo installer -dumplog -package `basename "$package"` -target /
}

echo $BASE_URL/$HASH/unity-$VERSION-$PLATFORM.ini
echo "travis_fold:start:install_unity"
	echo 'Installing Unity $VERSION'
	installPackage "MacEditorInstaller/Unity-$VERSION.pkg"
echo "travis_fold:end:install_unity"

echo "travis_fold:start:install_targets"
	echo 'Installing Targets'
	installPackage "MacEditorTargetInstaller/UnitySetup-Windows-Support-for-Editor-$VERSION.pkg"
	installPackage "MacEditorTargetInstaller/UnitySetup-Mac-Support-for-Editor-$VERSION.pkg"
	installPackage "MacEditorTargetInstaller/UnitySetup-Linux-Support-for-Editor-$VERSION.pkg"
echo "travis_fold:end:install_targets"