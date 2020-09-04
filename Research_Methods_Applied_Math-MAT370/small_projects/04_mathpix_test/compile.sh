#!/bin/bash

cd ./build
latexmk -pdf ../test_doc.tex
cd ..
cp ./build/test_doc.pdf ./_test_doc.pdf
