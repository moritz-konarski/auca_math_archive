#!/bin/bash
cd ./latex_build
latexmk -pdf ../03_project
cd ..
mv ./latex_build/03_project.pdf .

