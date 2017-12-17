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
mkdir -p ~/Library/Unity/Certificates
 kdir -p ~/.local/share/unity3d/Certificates/
cp $(pwd)/Builds/CACerts.pem ~/Library/Unity/Certificates/
cp $(pwd)/Builds/CACerts.pem ~/.local/share/unity3d/Certificates/
/opt/Unity/Editor/Unity -quit -batchmode -username $username -password $password -logfile
cat ~/Library/Logs/Unity/Editor.log
/opt/Unity/Editor/Unity -quit -batchmode -returnlicense -logfile
echo "travis_fold:end:install_licence"