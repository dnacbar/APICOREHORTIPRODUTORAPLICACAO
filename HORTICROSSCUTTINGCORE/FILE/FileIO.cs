using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace CROSSCUTTINGCOREHORTI.FILE
{
    public static class FileIO
    {
        public static void CreateImage(string strPath, byte[] byteImage)
        {
            using (var image = Image.FromStream(new MemoryStream(byteImage)))
            {
                image.Save(strPath);
            }
        }
    }
}
