#!/bin/bash
cd ./latex_build
latexmk -pdf ../02_project
cd ..
mv ./latex_build/02_project.pdf .

