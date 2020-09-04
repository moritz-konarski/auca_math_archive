#!/bin/bash

cd ./build/
latexmk ../presentation.tex -pdf
cd ..
mv ./build/presentation.pdf ./_presentation.pdf
