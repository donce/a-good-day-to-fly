BOOK_NAME    := main
SOURCE_FILES := $(wildcard *.tex *.sty *.bib)
PASS_1_FLAGS := -output-directory=./
PASS_2_FLAGS := $(PASS_1_FLAGS) -interaction=batchmode

VERSION_STRING := $(shell git rev-parse --short HEAD)
FINAL_CONTENT  := \newcommand{\versionString}{$(VERSION_STRING)}\input{$(BOOK_NAME)}
DRAFT_CONTENT  := \newcommand{\placeholder}[1]{\textbf{\textsf{\textcolor{red}{(\#1)}}}}$(FINAL_CONTENT)

draft:
	xelatex $(PASS_1_FLAGS) '$(DRAFT_CONTENT)'

final:
	xelatex $(PASS_1_FLAGS) '$(FINAL_CONTENT)'
	xelatex $(PASS_2_FLAGS) '$(FINAL_CONTENT)'
	xelatex $(PASS_2_FLAGS) '$(FINAL_CONTENT)'

todo:
	grep -Eir 'TODO:|UNKNOWN:|FIXME:' . --exclude=Makefile

clean:
	rm -f *.aux *.bbl *.bcf *.blg *.log *.out *.run.xml *.toc

clear: clean
	rm -f *.pdf

.PHONY: default draft final todo clean clear
