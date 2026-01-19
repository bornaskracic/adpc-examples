Before running the examples, first create the virtual environment:

```bash
cd Session06_Extra
python -m venv ./venv
./venv/scripts/Activate
```

Then install the required packages:
```bash
pip install -r requirements.txt
```

### Web Scrapping
A simple approach to scraping static html sites using `BeautifulSoup` HTML parser is shown. In short, using the parser object, different HTML elements can be found using `select` or `find` methods. This elements will be encapsulated in the navigational objects that contain information about specific HTML tag.

If there is a need to parse more complex, dynamic sites, tools like `Playwright` or `Selenium` should be used.


In this session's example, web scraping is used to retrieve information from the website. Then, the data is processed using a simple method and both scripts are orchestrated using Snakemake.

### Snakemake
For `snakemake` to work, there needs to be `Snakefile` defined in the top level directory. Similarly to `Makefile` used in `make` tool (well known to c programmers), in `Snakefile` different rules for producing files are defined:
```bash
rule scrape:
    output:
        "data/call_symbols.json"
    shell:
        "python scripts/scrape.py --output-file={output}"

rule process:
    input: 
        "data/call_symbols.json"
    output: 
        "data/translated.txt"
    shell:
        "python scripts/process.py --input-file={input} --output-file={output} --input-string=FGHX"
```
It is clear to see that to produce `translated.txt`, `call_symbols.json` needs to exist. If it does not exist, it will be created by utilizing `scrape` rule shell process. If `Snakefile` contains only these rules, `snakemake` will not care if the `translated.txt` exists since it is not a requirement for any rule in the process. To make that file the final (or main) target of our process, one catch-all rule needs to be defined:
```bash
rule all:
    input:
        "data/translated.txt"
```
Finally, to run the `Snakemake` process, run (it is mandatory to define the number of CPU cores that will be used):
```bash
snakemake --cores 1
```

