using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace FileTypeVerifierLib
{
    public class FileTypeVerifier : IFileTypeVerifier
    {
        public bool IsOfFileType(string fileType, IFormFile file)
        {
            var ft = new FileTypes();

            var fileSigns = ft.GetSignatures()
                .Where(x => x.Name.ToUpper().Equals(fileType.ToUpper()))
                .Select(x => x)
                .ToList();

            var matched = false;

            foreach (var fs in fileSigns)
            {
                using var fileStream = file.OpenReadStream();
                fileStream.Position = 0;
                var reader = new BinaryReader(fileStream);
                var headerBytes = reader.ReadBytes(fs.Signature.Length);

                matched = headerBytes.SequenceEqual(fs.Signature);

                if (matched)
                {
                    break;
                }
            }

            return matched;
        }

        public bool IsOfFileType(string fileType, FileInfo fi)
        {
            var ft = new FileTypes();

            var fileSigns = ft.GetSignatures()
                .Where(x => x.Name.ToUpper().Equals(fileType.ToUpper()))
                .Select(x => x)
                .ToList();

            var matched = false;

            foreach (var fs in fileSigns)
            {
                using var fileStream = File.OpenRead(fi.FullName);

                fileStream.Position = 0;
                var reader = new BinaryReader(fileStream);
                var headerBytes = reader.ReadBytes(fs.Signature.Length);

                matched = headerBytes.SequenceEqual<byte>(fs.Signature);

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
                if (IsOfFileType(fileSign.Name, fi))
                {
                    result = fileSign.Name;
                    break;
                }
            }
            return result;
        }
    }
}
