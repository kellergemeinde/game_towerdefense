#! /bin/sh
# move to travis-ci env vars
SERVER=51.15.74.95
USERNAME=www-data
PASSWORD=Keller#12
PATH=/var/www/html/master/

uploadBuilds() {
	plattform=$1
	deploypath=$USERNAME:$PASSWORD@$SERVER:$PATH/Builds/$1/
	echo $deploypath
	scp -r $(pwd)/Builds/$1/* $deploypath
}

echo "travis_fold:start:upload_build"
	echo 'Upload windows build'
	uploadBuilds "Windows"
echo "travis_fold:end:upload_build"