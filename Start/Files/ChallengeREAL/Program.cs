// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Linq;


string directoryPath = "FileCollection";
string resultsFilePath = "results.txt";

// Step 1: Setup Directory and File Paths
// Create the directory if it doesn't exist
if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}

// Step 3: Initialize Counters and Variables
int excelCount = 0, wordCount = 0, pptCount = 0;
long excelSize = 0, wordSize = 0, pptSize = 0;

// Step 4: Directory Info Object
DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);

// Step 5: Enumerate Files
foreach (FileInfo file in dirInfo.GetFiles())
{
    if (IsOfficeFile(file))
    {
        switch (file.Extension.ToLower())
        {
            case ".xlsx":
                excelCount++;
                excelSize += file.Length;
                break;
            case ".docx":
                wordCount++;
                wordSize += file.Length;
                break;
            case ".pptx":
                pptCount++;
                pptSize += file.Length;
                break;
        }
    }
}

// Step 6: Write Results to File
using (StreamWriter writer = new StreamWriter(resultsFilePath))
{
    writer.WriteLine($"Excel files: {excelCount}, Total size: {excelSize} bytes");
    writer.WriteLine($"Word files: {wordCount}, Total size: {wordSize} bytes");
    writer.WriteLine($"PowerPoint files: {pptCount}, Total size: {pptSize} bytes");
}

Console.WriteLine("Summary written to results.txt");


// Step 2: Create Helper Function
static bool IsOfficeFile(FileInfo file)
{
string[] officeExtensions = { ".xlsx", ".docx", ".pptx" };
return officeExtensions.Contains(file.Extension.ToLower());
}
