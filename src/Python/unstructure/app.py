# pip install "unstructured[all-docs]" onnx==1.16.0
# pip install "unstructured[pdf]" onnx==1.16.0

# mac/linux install
# libmagic-dev (filetype detection)
# poppler-utils (images and PDFs)
# tesseract-ocr (images and PDFs, install tesseract-lang for additional language support)
# libreoffice (MS Office docs)
# pandoc (EPUBs, RTFs and Open Office docs). Please note that to handle RTF files, you need version 2.14.2 or newer.
# Running either make install-pandoc or ./scripts/install-pandoc.sh will install the correct version for you.

import os
from dotenv import load_dotenv
from unstructured.partition.auto import partition
from unstructured.partition.text_type import sentence_count
from unstructured.documents.elements import NarrativeText
from unstructured.partition.pdf import partition_pdf
from unstructured.staging.base import convert_to_dict,elements_to_json
from unstructured.chunking.basic import chunk_elements
from unstructured.partition.html import partition_html
from langchain.document_loaders import UnstructuredURLLoader
from langchain.vectorstores.chroma import Chroma
from langchain.embeddings import OpenAIEmbeddings
from langchain.chat_models import ChatOpenAI
from langchain.chains.summarize import load_summarize_chain


# elements = partition(filename="example-docs/eml/fake-email.eml")
# print("\n\n".join([str(el) for el in elements]))

# pdfElements = partition(filename="example-docs/layout-parser-paper.pdf")
# print("\n\n".join([str(el) for el in pdfElements]))

# htmlElements = partition(filename="example-docs/example-10k.html")
# for element in htmlElements[:5]:
#     print(element)
#     print("\n")

# for element in htmlElements[:100]:
#     if isinstance(element, NarrativeText) and sentence_count(element.text) > 2:
#         print(element)
#         print("\n")

# filename = "example-docs/深圳华侨城股份有限公司2024 年第一季度报告.pdf"
# elements = partition_pdf(filename=filename, infer_table_structure=True)
# tables = [el for el in elements if el.category == "Table"]
# print(convert_to_dict(tables))
# print(tables[0].text)
# print(tables[0].metadata.text_as_html)

# jsonFilename = "outputs.json"
# elements_to_json(tables, filename=jsonFilename)

# htmlElements = partition_html(url="https://unstructured-io.github.io/unstructured/core/chunking.html");
# chunks = chunk_elements(htmlElements)
# for chunk in chunks:
#     print(chunk)
#     print("\n\n" + "-"*80)
load_dotenv()
print(os.getenv("OpenAIKey"))
cnn_lite_url = "https://lite.cnn.com/"
elements = partition_html(url=cnn_lite_url)
links = []

for element in elements:
    if element.metadata.link_urls:
        relative_link = element.metadata.link_urls[0][1:]
        print(relative_link)
        if relative_link.startswith("2024"):
            links.append(f"{cnn_lite_url}{relative_link}")

loaders = UnstructuredURLLoader(urls=links[:20], show_progress_bar=True)
docs = loaders.load()

embeddings = OpenAIEmbeddings(api_key=os.getenv("OpenAIKey"))
vectorstore = Chroma.from_documents(docs,embeddings)
query_doc = vectorstore.similarity_search( "What is behind the rapid increase in car insurance rates?",k=1)

llm = ChatOpenAI(temperature=0,api_key=os.getenv("OpenAIKey"))
chain = load_summarize_chain(llm,chain_type="stuff")

print(chain.run(query_doc))



