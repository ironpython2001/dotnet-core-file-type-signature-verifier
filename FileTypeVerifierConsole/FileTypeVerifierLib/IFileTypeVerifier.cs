using System.IO;

namespace FileTypeVerifierLib
{
    public interface IFileTypeVerifier
    {
        bool IsOfFileType(string fileType, FileInfo fi);
        string Recognize(FileInfo fi);
    }
}
