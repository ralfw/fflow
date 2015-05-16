#!/bin/bash
rm -rf $1
mkdir $1
cp -r ../samples/$1/* $1
tree $1