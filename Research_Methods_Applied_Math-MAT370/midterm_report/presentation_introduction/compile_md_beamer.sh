#!/bin/bash

pandoc presentation.md -o _presentation.pdf -t beamer -V fontsize=12pt
