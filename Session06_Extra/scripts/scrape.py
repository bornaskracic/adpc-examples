import argparse
import json

import requests
from bs4 import BeautifulSoup

parser = argparse.ArgumentParser()
parser.add_argument("--output-file", dest="output_file", required=True)
args = parser.parse_args()

url = "https://en.wikipedia.org/wiki/NATO_phonetic_alphabet"
headers = {
    "User-Agent": "User-Agent: CoolBot/0.0 (https://example.org/coolbot/; coolbot@example.org) generic-library/0.0"
}
response = requests.get(url, headers=headers)
soup = BeautifulSoup(response.text, "html.parser")

wikitables = soup.find_all("table")
target_table = wikitables[2]

rows = target_table.find_all("tr")

call_symbols = {}

for row in rows[2:]:
    symbol = row.find("th").text.strip()
    code_word = row.find("td").text.strip()
    call_symbols[symbol] = code_word
    
with open(args.output_file, "w") as f:
    json.dump(call_symbols, f)
    