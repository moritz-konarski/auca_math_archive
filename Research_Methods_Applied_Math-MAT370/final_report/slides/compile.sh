#!/bin/bash

cd ./latex_build/
latexmk ../presentation.tex -pdf
cd ..
mv ./latex_build/presentation.pdf ./_presentation.pdf
