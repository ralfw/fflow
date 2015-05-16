#!/bin/bash
rm -rf 3stations
mkdir 3stations
cp -r ../samples/3stations/* 3stations
/usr/bin/mono fflow.console.exe edit -w=3stations -s=station1 -d=doc1.txt
/usr/bin/mono fflow.console.exe push -w=3stations -s=station2 -d=doc5.txt -a=to3