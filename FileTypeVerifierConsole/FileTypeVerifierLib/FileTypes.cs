using System.Collections.Generic;

namespace FileTypeVerifierLib
{
    public class FileTypes
    {
        public List<(string name, List<byte[]> Signatures)> GetSignatures()
        {
            List<(string name, List<byte[]> Signatures)>? lst = new List<(string fileType, List<byte[]> Signatures)>();

            //jpg
            var jpg = ("jpg", new List<byte[]>
            {
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
            });
            lst.Add(jpg);

            //mp3
            var mp3 = ("mp3", new List<byte[]>
            {
                new byte[] { 0x49, 0x44, 0x33 }
            });
            lst.Add(mp3);

            //png
            var png = ("png", new List<byte[]>
            {
                new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A}
            });
            lst.Add(png);

            return lst;
        }
    }

}
