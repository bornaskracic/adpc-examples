import argparse
import json

parser = argparse.ArgumentParser()
parser.add_argument("--input-string", dest="input_string", required=True)
parser.add_argument("--input-file", dest="input_file", required=True)
parser.add_argument("--output-file", dest="output_file", required=True)
args = parser.parse_args()

# reading json object
with open(args.input_file) as f:
    call_symbols = json.load(f)

# translated_string = ""
# for symbol in input_string:  
#     translated_string += "-" + call_symbols[symbol] # G -> Golf
    
# list comperhension trick
translated_string = "-".join([call_symbols[symbol] for symbol in args.input_string])

with open(args.output_file, 'w') as f:
    f.write(translated_string)