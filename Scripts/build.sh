#! /bin/sh

project="Text101"

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity 
  -batchmode 
  -nographics 
  -silent-crashes 
  -logFile $(pwd)/unity.log 
  -projectPath $(pwd) 
  -buildOSXUniversalPlayer "$(pwd)/Build/osx/$project.app" 
  -quit

echo "Logs from build"
cat $(pwd)/unity.log
