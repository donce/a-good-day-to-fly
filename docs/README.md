# Failų išdėstymas

Dokumentai direktorijose išdėstyti taip:

* [proposal/](proposal) - projekto pasiūlymas.
* [design/](design) - žaidimo projekto ir dizaino dokumentacija.
* [prototype/](prototype) - prototipo dokumentacija.

Kiekvienas dokumentas turi tokius failus:

* `main.tex` - pagrindinis (šakninis) dokumento failas.
* `title.tex` - titulinis lapas.

Dokumente naudojami vaizdai saugomi subdirektorijoje `images/` šalia to dokumento.

# Komandos dokumentuose

Visuose dokumentuose galima naudoti tokias papildomas LaTeX komandas:

* `\TODO{tekstas}` žymi nebaigtas dokumento dalis. Galutiniame dokumente jų neturėtų likti.
* `\versionString{}` - dokumento versija (ji imama iš Git).
* `\insertPicture[dydis]{failo-pavadinimas-be-plėtinio}{trumpas vaizdo apibūdinimas}` įterpia vaizdą su žyme. Žymės pavadinimas sutampa su perduodamu failo pavadinimu. Apibūdinimas naudojamas kaip antraštė. Vaizdai turi būti subdirektorijoje `images/`.
* `\referToPicture{failo-pavadinimas-be-plėtinio}` - tekstinė nuoroda į vaizdą, įterptą su `\insertPicture`.
* `\trademark{pavadinimas}` žymi įmonės pavadinimą arba produkto/paslaugos pavadinimą.

# Priklausomybės

Dokumentų kompiliavimui reikalingus paketus Ubuntu 13.04 operacinėje sistemoje galima instaliuoti komanda:

```bash
sudo apt-get install make git texlive-full fonts-freefont-otf
```

# Kompiliavimas

Dokumentai kompiliuojami su komanda:

```bash
make target
```

`target` turi būti vienas iš kompiliavimo taikinių:

* `draft` - nebaigtas dokumento variantas. Jame galima naudoti komandą `\TODO{tekstas}`. Šis taikinys naudojamas pagal nutylėjimą.
* `final` - galutinis dokumento variantas. Iš karto sugeneruojamas turinys ir nuorodos. `\TODO{}` komanda neveikia.
* `todo` - iš direktorijoje esančių failų išrenka eilutes su teksto fragmentais `TODO:`, `UNKNOWN:`, `FIXME:`.
* `clean` - pašalina tarpinius XeLaTeX sukurtus failus.
* `clear` - pašalina tarpinius XeLaTeX sukurtus failus ir galutinį PDF'ą.
