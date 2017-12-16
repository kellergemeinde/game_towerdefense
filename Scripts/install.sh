#! /bin/sh

echo $(pwd)
echo $(ls -lah)
echo 'Installing Unity on Linux'

echo "travis_fold:start:install_unity"
echo 'Installing Unity'
# latest Linux Unity details can be found at https://forum.unity3d.com/threads/unity-on-linux-release-notes-and-known-issues.350256/
curl -o unity.deb http://beta.unity3d.com/download/ee86734cf592/unity-editor_amd64-2017.2.0f3.deb
# from http://askubuntu.com/a/841240/310789
sudo dpkg -i unity.deb
echo "travis_fold:end:install_unity"

echo "travis_fold:start:install_missing_dependencies"
echo 'Installing missing dependencies'
sudo apt-get install -f
echo "travis_fold:end:install_missing_dependencies"