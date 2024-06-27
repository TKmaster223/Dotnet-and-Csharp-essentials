// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Creating and Deleting Files

const string filename = "TestFile.txt";

// TODO: Create a new file - this will overwrite any existing file
// Use the "using" construct to automatically close the file stream
using (StreamWriter sw = File.CreateText(filename)) {
sw.WriteLine("This is a text file.");
}

// TODO: Determine if a file exists

Console.WriteLine(File.Exists(filename));
if (File.Exists(filename)) {
// The Delete function deletes a file
File.Delete(filename);
}
else {
using (StreamWriter sw = File.CreateText(filename)) {
sw.WriteLine("This is a text file.");
}
}
Console.WriteLine(File.Exists(filename));