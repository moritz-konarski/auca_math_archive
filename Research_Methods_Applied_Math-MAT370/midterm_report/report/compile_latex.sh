#!/bin/bash
cd ./latex_build
latexmk -pdf ../midterm_report.tex
cd ..
mv ./latex_build/midterm_report.pdf ./_midterm_report.pdf

