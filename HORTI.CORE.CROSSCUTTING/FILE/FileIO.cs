using System.Drawing;
using System.IO;

namespace HORTI.CORE.CROSSCUTTING.FILE
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
