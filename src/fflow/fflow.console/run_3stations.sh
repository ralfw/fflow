#!/bin/bash
rm -rf 3stations
mkdir 3stations
cp -r ../samples/3stations/* 3stations
/usr/bin/mono fflow.console.exe open -w=3stations