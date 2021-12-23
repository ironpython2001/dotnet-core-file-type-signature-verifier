using System.Collections.Generic;

namespace FileTypeVerifierLib
{
    public class FileTypes
    {
        //https://sceweb.sce.uhcl.edu/abeysekera/itec3831/labs/FILE%20SIGNATURES%20TABLE.pdf
        //https://filesignatures.net/index.php?page=all
        public List<(string Name, byte[] Signature)> GetSignatures()
        {
            List<(string Name, byte[] Signature)>? lst = new List<(string Name, byte[] Signature)>();

            //jpg
            lst.Add(("jpg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }));
            lst.Add(("jpg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 }));
            lst.Add(("jpg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }));

            //mp3
            lst.Add(("mp3", new byte[] { 0x49, 0x44, 0x33 }));

            //png
            lst.Add(("png", new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }));

            var fileExts1 = new List<string>
            {
                "DOC", "DOT", "PPS", "PPT", "XLA", "XLS", "WIZ"
            };
            var fileSigns1 = new List<byte[]>
            {
                new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1}
            };
            fileExts1.ForEach(ext => 
            {
                fileSigns1.ForEach(sign => 
                {
                    lst.Add((ext, sign));
                });
            });

            var fileExts2 = new List<string>
            {
                "DOC"
            };
            var fileSigns2 = new List<byte[]>
            {
                new byte[] { 0xEC, 0xA5, 0xC1, 0x00 }
            };
            fileExts2.ForEach(ext =>
            {
                fileSigns2.ForEach(sign =>
                {
                    lst.Add((ext, sign));
                });
            });


            var fileExts3 = new List<string>
            {
                "XLS"
            };
            var fileSigns3 = new List<byte[]>
            {
                new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1},
                new byte[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 },
                new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x10 },
                new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x1F },
                new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x22 },
                new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x23 },
                new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x28 },
                new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x29 }
            };
            fileExts3.ForEach(ext =>
            {
                fileSigns3.ForEach(sign =>
                {
                    lst.Add((ext, sign));
                });
            });


            var fileExts4 = new List<string>
            {
                "XLSX"
            };
            var fileSigns4 = new List<byte[]>
            {
                new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 }
            };
            fileExts4.ForEach(ext =>
            {
                fileSigns4.ForEach(sign =>
                {
                    lst.Add((ext, sign));
                });
            });

            return lst;
        }
    }

}
