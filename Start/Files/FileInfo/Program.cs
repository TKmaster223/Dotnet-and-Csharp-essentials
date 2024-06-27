// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Working with file information

// Make sure the example file exists
const string filename = "TestFile.txt";

if (!File.Exists(filename)) {
    using (StreamWriter sw = File.CreateText(filename)) {
        sw.WriteLine("This is a text file.");
    }
}

// TODO: Get some information about the file
Console.WriteLine("File creation time was: "+ File.GetCreationTime(filename));
Console.WriteLine("File last write time was: "+File.GetLastWriteTime(filename));
Console.WriteLine("File last access tme was: "+File.GetLastAccessTime(filename));

// TODO: We can also get general information using a FileInfo 
try{
    FileInfo fi = new FileInfo(filename);
    System.Console.WriteLine($"{fi.Length}");
}
catch (Exception e){
    Console.WriteLine($"Error: {e}");
}

// TODO: File information can also be manipulated
File.SetAttributes(filename,FileAttributes.ReadOnly);
Console.WriteLine(File.GetAttributes(filename));

DateTime dt = new DateTime(2024,6,10);
File.SetCreationTime(filename, dt);
Console.WriteLine(File.GetCreationTime(filename));