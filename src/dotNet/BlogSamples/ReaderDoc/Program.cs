using System;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

// Replace with the actual path to your .doc file
string docFilePath = "./data/TestMickey.doc";

// Create a new .docx file
string docxFilePath = Path.ChangeExtension(docFilePath, ".docx");

using WordprocessingDocument docx = WordprocessingDocument.Create(docxFilePath, WordprocessingDocumentType.Document);
MainDocumentPart mainPart = docx.AddMainDocumentPart();
mainPart.Document = new Document(new Body());

// Read the content from the .doc file
string docContent = File.ReadAllText(docFilePath);

Console.WriteLine(docContent);
