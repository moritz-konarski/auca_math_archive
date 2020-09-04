#!/bin/bash

pandoc presentation.md -o _test.pdf -V papersize=a4 -V linkcolor=blue -V geometry:margin=1in -V fontsize=12pt -V numbersections=true #--toc 
