#!/bin/bash

pandoc *.md -o notes_pde.pdf -V papersize=a4 -V linkcolor=blue -V geometry:margin=1in -V numbersections=true --toc --toc-depth=5 -V fontsize=12pt
