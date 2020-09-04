#!/bin/bash

mkdir "$1"
mkdir "$1/latex_build"
touch "./$1/$1.tex" "./$1/compile_latex.sh"

echo "#!/bin/bash
cd "./latex_build"
latexmk -pdf "../$1.tex"
cd ..
mv "./latex_build/$(basename "$1" .tex).pdf" "./_$(basename "$1" .tex).pdf"
" > "./$1/compile_latex.sh"

echo "
\documentclass[12pt, a4paper, reqno]{amsart}

\usepackage{amsfonts}
\usepackage{amsmath}
\usepackage{anysize}

\marginsize{1in}{1in}{1in}{1in}

\title{tile}
\author{author}
\date{date}

\begin{document}

\maketitle

\end{document}
" > "./$1/$1.tex"
