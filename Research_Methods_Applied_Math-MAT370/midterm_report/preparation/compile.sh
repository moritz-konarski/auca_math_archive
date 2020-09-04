#!/bin/bash

pandoc 06_presentation_outline.md -o _06_presentation_outline.pdf -V papersize=a4 -V linkcolor=blue -V geometry:margin=1in -V fontsize=12pt -V numbersections=true --toc 
