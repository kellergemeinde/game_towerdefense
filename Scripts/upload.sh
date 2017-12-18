#! /bin/sh
# move to travis-ci env vars
SERVER=51.15.74.95
USERNAME=www-data
PASSWORD=Keller#12
PATH=/var/www/html/master/

uploadBuilds() {
	plattform=$1
	rsync -avr $(pwd)/Builds/$1/** $USERNAME:$PASSWORD@$SERVER:$PATH/Builds/$1/*
}

apt-get install rsync
echo $BASE_URL/$HASH/unity-$VERSION-$PLATFORM.ini
echo "travis_fold:start:upload_build"
	echo 'Installing Unity'
	uploadBuild "Windows"
echo "travis_fold:end:upload_build"