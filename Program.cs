//http://stackoverflow.com/questions/6777340/how-to-join-2-or-more-wav-files-together-programatically

using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wavemerge
{
    class Program
    {
        static void Main(string[] args)
        {
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_01.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 01"));
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_02.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 02"));
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_03.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 03"));
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_04.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 04"));
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_05.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 05"));
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_06.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 06"));
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_07.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 07"));
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_08.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 08"));
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_09.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 09"));
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_10.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 10"));
            Concatenate(@"C:\Users\christopher.harvey\Music\Lee Child\Echo_Burning_Disk_11.wav", System.IO.Directory.GetFiles(@"C:\Users\christopher.harvey\Music\Lee Child\Echo Burning Disk 11"));

        }

        public static void Concatenate(string outputFile, IEnumerable<string> sourceFiles)
        {
            byte[] buffer = new byte[1024];
            WaveFileWriter waveFileWriter = null;

            try
            {
                foreach (string sourceFile in sourceFiles)
                {
                    System.Console.WriteLine(sourceFile);
                    using (WaveFileReader reader = new WaveFileReader(sourceFile))
                    {
                        if (waveFileWriter == null)
                        {
                            // first time in create new Writer
                            waveFileWriter = new WaveFileWriter(outputFile, reader.WaveFormat);
                        }
                        else
                        {
                            if (!reader.WaveFormat.Equals(waveFileWriter.WaveFormat))
                            {
                                throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                            }
                        }

                        int read;
                        while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            /*
                             * waveFileWriter.WriteData(buffer, 0, read);//obsolete
                             */
                            waveFileWriter.Write(buffer, 0, read);
                        }
                    }
                }
            }
            finally
            {
                if (waveFileWriter != null)
                {
                    waveFileWriter.Dispose();
                }
            }
        }
    }
}
