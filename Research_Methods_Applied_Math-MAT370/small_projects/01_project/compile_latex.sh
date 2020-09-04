#!/bin/bash
cd ./latex_build
latexmk -pdf ../01_project
cd ..
mv ./latex_build/01_project.pdf .

