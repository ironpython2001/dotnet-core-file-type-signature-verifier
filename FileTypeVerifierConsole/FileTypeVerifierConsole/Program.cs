var fileName = string.Empty;

for (; ; )
{
    Console.WriteLine("Enter Full FilePath");
    fileName = Console.ReadLine();
    if (string.IsNullOrEmpty(fileName))
        continue;
    else if (File.Exists(fileName))
        break;
    else
    {
        Console.WriteLine($"File Not found at {fileName}");
        Environment.Exit(0);
    }
}

var ftv = new FileTypeVerifierLib.FileTypeVerifier();
Console.WriteLine(ftv.Recognize(new FileInfo(fileName)));
Console.WriteLine(ftv.IsOfFileType("jpg", new FileInfo(fileName)));

