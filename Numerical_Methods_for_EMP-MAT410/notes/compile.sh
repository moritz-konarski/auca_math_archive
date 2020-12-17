#!/bin/bash

pandoc ./src/*.md -o num_methods_for_pde.pdf  \
    --toc --toc-depth=3             \
    --pdf-engine=xelatex -s         \
    --highlight-style=espresso      \
    -V monofont="DejaVu Sans Mono" 
