#! /bin/sh
echo 'Installing Unity on Linux'
username="Kellergemeinde"
password="Keller#12"

echo "travis_fold:start:install_unity"
echo 'Installing Unity'
curl -o unity.deb http://beta.unity3d.com/download/ee86734cf592/unity-editor_amd64-2017.2.0f3.deb
sudo dpkg -i unity.deb
echo "travis_fold:end:install_unity"

echo "travis_fold:start:install_missing_dependencies"
echo 'Installing missing dependencies'
sudo apt-get install -f
echo "travis_fold:end:install_missing_dependencies"

echo "travis_fold:start:install_licence"
echo 'Installing Licence'
ping core.cloud.unity3d.com
curl -X GET 'https://core.cloud.unity3d.com/api/login' -v
mkdir -p ~/Library/Unity/Certificates
mkdir -p ~/.local/share/unity3d/Certificates/
cp $(pwd)/Scripts/CACerts.pem ~/Library/Unity/Certificates/
cp $(pwd)/Scripts/CACerts.pem ~/.local/share/unity3d/Certificates/
/opt/Unity/Editor/Unity -quit -batchmode -nographics -username $username -password $password -logfile
cat ~/Library/Logs/Unity/Editor.log
/opt/Unity/Editor/Unity -quit -batchmode -nographics -returnlicense -logfile
echo "travis_fold:end:install_licence"