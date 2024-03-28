from pymongo import MongoClient
from langchain_community.document_loaders.pdf import PyPDFLoader
from langchain_text_splitters import RecursiveCharacterTextSplitter
from langchain_community.vectorstores.mongodb_atlas import MongoDBAtlasVectorSearch
from langchain_openai import OpenAIEmbeddings
from langchain.prompts import PromptTemplate
from langchain.chains import RetrievalQA
from langchain_openai import OpenAI
import key_param

# initialize the MongoClient
client = MongoClient(key_param.Mongo_URI)
db_name = "langchain_db"
collection_name = "answerapp"
atlas_vector_search_index_name = "ansindex"
mongodb_collection = client[db_name][collection_name]

# load the pdf
# loader = PyPDFLoader(file_path="./data/answerapp.pdf")
# data = loader.load()
# text_splitter = RecursiveCharacterTextSplitter(chunk_size=1000,chunk_overlap=100)
# docs = text_splitter.split_documents(data)
# print(docs[0])

# insert the documents in MongoDB Atlas with their embedding
# vector_search = MongoDBAtlasVectorSearch.from_documents(
#     documents=docs,
#     embedding=OpenAIEmbeddings(api_key=key_param.openai_api_key),
#     collection=mongodb_collection,
#     index_name=atlas_vector_search_index_name,
# )

# get vector_search


query = "who is the author of i have a dream"
vector_search = MongoDBAtlasVectorSearch.from_connection_string(
    key_param.Mongo_URI,
    db_name+"."+collection_name,
    OpenAIEmbeddings(api_key=key_param.openai_api_key,disallowed_special=()),
    index_name=atlas_vector_search_index_name,
)
# results = vector_search.similarity_search(query)
# print(results[0].page_content)

# results = vector_search.similarity_search_with_score(query=query,k=5,pre_filter={"page":{"$eq":1}})

# results = vector_search.similarity_search_with_score(
#     query=query,
#     k=5,
# )

qa_retriever = vector_search.as_retriever(
    search_type="similarity",
    search_kwargs={"k": 25},
)

prompt_template ="""
Use the following pieces of context to answer the question at the end. If you don't know the answer, just say that you don't know, don't try to make up an answer.

{context}

Question: {question}
"""
Prompt = PromptTemplate(template=prompt_template,input_variables=["context","question"])

qa = RetrievalQA.from_chain_type(
    llm=OpenAI(api_key=key_param.openai_api_key),
    chain_type="stuff",
    retriever=qa_retriever,
    return_source_documents=True,
    chain_type_kwargs={"prompt":Prompt},
)

docs = qa.invoke({"query":query})

print(docs["result"])
#print(docs["source_documents"])

# Display results
# for result in results:
#     print(result)


