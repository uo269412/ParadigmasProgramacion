using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab11 {

    class Program {

        static void Main() {
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            string[] files = Directory.GetFiles(@"..\..\..\pics", "*.jpg");
            string newDirectory = @"..\..\..\pics\rotated";
            Directory.CreateDirectory(newDirectory);
            foreach (string file in files) {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file)) {
                    Console.WriteLine("Processing the file \"{0}\".", fileName);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectory, fileName));
                }
            }
            chrono.Stop();
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", chrono.ElapsedMilliseconds);

            //THREAD VERSION
            Stopwatch chrono2 = new Stopwatch();
            chrono2.Start();
            string newDirectoryTh = @"..\..\..\pics\rotatedThread";
            Directory.CreateDirectory(newDirectoryTh);
            Parallel.ForEach(files, file =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file))
                {
                    Console.WriteLine("Processing the file \"{0}\".", fileName);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectoryTh, fileName));
                }
            });
            chrono2.Stop();
            Console.WriteLine("Thread Version -> Elapsed time: {0:N} milliseconds.", chrono2.ElapsedMilliseconds);
        }
    }

}
