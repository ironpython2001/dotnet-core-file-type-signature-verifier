using System;
using System.IO;
using System.Linq;

namespace FileTypeVerifierLib
{
    public class FileTypeVerifier:IFileTypeVerifier
    {
        public bool IsOfFileType(string fileType, FileInfo fi)
        {
            var ft = new FileTypes();

            var fileSign = ft.GetSignatures()
                .Where(x => x.name.ToUpper().Equals(fileType.ToUpper()))
                .FirstOrDefault();

            var matched = false;

            foreach (var sign in fileSign.Signatures)
            {
                using var fileStream = File.OpenRead(fi.FullName);

                fileStream.Position = 0;
                var reader = new BinaryReader(fileStream);
                var headerBytes = reader.ReadBytes(sign.Length);

                matched = headerBytes
                    .Take(sign.Length)
                    .SequenceEqual<byte>(sign);

                if (matched)
                {
                    break;
                }
            }
            return matched;
        }

        public string Recognize(FileInfo fi)
        {
            var result = string.Empty;
            var ft = new FileTypes();

            var fileSigns = ft.GetSignatures()
                .ToList();

            foreach (var fileSign in fileSigns)
            {
                if( IsOfFileType(fileSign.name,fi))
                {
                    result = fileSign.name;
                    break;
                }
            }
            return result ;
        }
    }
}
