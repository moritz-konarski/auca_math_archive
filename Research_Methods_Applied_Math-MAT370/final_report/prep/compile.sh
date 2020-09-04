#!/bin/bash

cd ./build
latexmk ../03_source_summary.tex -pdf
cd ..
mv ./build/03_source_summary.pdf ./_03_source_summary.pdf
