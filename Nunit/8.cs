/*8. Testing File Handling Methods
Problem:
Create a class FileProcessor with the following methods:
WriteToFile(string filename, string content): Writes content to a file.
ReadFromFile(string filename): Reads content from a file.
Write unit tests to check if:
✅ The content is written and read correctly.
✅ The file exists after writing.
✅ Handling of IOException when the file does not exist.
*/

using System;
using System.IO;

public class FileProcessor
{
    public void WriteToFile(string filename, string content)
    {
        File.WriteAllText(filename, content);
    }

    public string ReadFromFile(string filename)
    {
        if (!File.Exists(filename))
            throw new IOException("File not found.");

        return File.ReadAllText(filename);
    }
}
//Test Cases
using NUnit.Framework;
using System;
using System.IO;

[TestFixture]
public class FileProcessorTests
{
    private FileProcessor _fileProcessor;
    private string _testFile;

    [SetUp]
    public void Setup()
    {
        _fileProcessor = new FileProcessor();
        _testFile = "testfile.txt";
    }

    [TearDown]
    public void Cleanup()
    {
        if (File.Exists(_testFile))
            File.Delete(_testFile);
    }

    [Test]
    public void WriteToFile_FileShouldExist()
    {
        _fileProcessor.WriteToFile(_testFile, "Hello, World!");
        Assert.IsTrue(File.Exists(_testFile));
    }

    [Test]
    public void ReadFromFile_ShouldReturnCorrectContent()
    {
        string content = "Unit testing file operations!";
        _fileProcessor.WriteToFile(_testFile, content);
        string readContent = _fileProcessor.ReadFromFile(_testFile);

        Assert.AreEqual(content, readContent);
    }

    [Test]
    public void ReadFromFile_FileDoesNotExist_ShouldThrowIOException()
    {
        Assert.Throws<IOException>(() => _fileProcessor.ReadFromFile("nonexistent.txt"));
    }
}

