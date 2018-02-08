using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (FileStream stream = new FileStream("picture.png", FileMode.Open))
            using (FileStream writeStream = new FileStream("pictureCopyed.png", FileMode.Create))
            {
                
                byte[] buffer = new Byte[4096];
                

               
                while (true)
                {
                    var readBytesCount = stream.Read(buffer, 0, buffer.Length);
                    if (readBytesCount == 0)
                    {
                        break;
                    }
                    writeStream.Write(buffer, 0, readBytesCount);
                    
                }
            }
        }
    }
}
