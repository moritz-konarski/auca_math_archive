#!/bin/bash
cd ./latex_build
latexmk -pdf ../report.tex
cd ..
mv ./latex_build/report.pdf ./_report.pdf

