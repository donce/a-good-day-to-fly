BOOK_NAME    := main
PASS_1_FLAGS := -output-directory=./
PASS_2_FLAGS := $(PASS_1_FLAGS) -interaction=batchmode

VERSION_STRING := $(shell git rev-parse --short HEAD)
FINAL_CONTENT  := \newcommand{\versionString}{$(VERSION_STRING)}\input{$(BOOK_NAME)}
DRAFT_CONTENT  := \newcommand{\compilingInDraftMode}{}$(FINAL_CONTENT)

draft:
	xelatex $(PASS_1_FLAGS) '$(DRAFT_CONTENT)'

final:
	xelatex $(PASS_1_FLAGS) '$(FINAL_CONTENT)'
	xelatex $(PASS_2_FLAGS) '$(FINAL_CONTENT)'
	xelatex $(PASS_2_FLAGS) '$(FINAL_CONTENT)'

clean:
	rm -f *.aux *.bbl *.bcf *.blg *.log *.out *.run.xml *.toc

clear: clean
	rm -f *.pdf

.PHONY: draft final clean clear
