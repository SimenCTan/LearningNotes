import textract
# Replace 'path/to/your/file.doc' with the actual path to your .doc file
text = textract.process('./test.doc')

# Decode the byte string to UTF-8
decoded_text = text.decode('utf-8')

print(decoded_text)
