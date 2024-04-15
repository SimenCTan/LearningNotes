using System;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Text.RegularExpressions;
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

// Clean invalid XML characters
string cleanedContent = CleanInvalidXmlChars(docContent);

// Add the content to the .docx file
mainPart.Document?.Body?.Append(new Paragraph(new Run(new Text(cleanedContent))));

Console.ReadLine();

static string CleanInvalidXmlChars(string text)
{
    // Remove invalid XML characters
    string pattern = @"[^\x09\x0A\x0D\x20-\uD7FF\uE000-\uFFFD\u10000-\u10FFFF]";
    return Regex.Replace(text, pattern, "");
}

