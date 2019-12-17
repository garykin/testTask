using System;
using System.IO;

namespace UnitTests
{
    public class TestsFixture : IDisposable
    {
        private const string FILE_PATH = @"C:\test\fileForTests.txt";

        public TestsFixture()
        {
            if (!File.Exists(FILE_PATH))
            {
                File.Create(FILE_PATH).Dispose();

                using (var tw = new StreamWriter(FILE_PATH, true))
                {
                    tw.WriteLine("1,2,3,4,5");
                    tw.WriteLine("#.5,5.5");
                    tw.WriteLine("1,2,3,f,4");
                    tw.WriteLine("");
                    tw.WriteLine("1,2,3,4,5,6");
                    tw.WriteLine("100");
                }
            }
        }

        public string FilePath => FILE_PATH;


        public void Dispose()
        {
            File.Delete(FILE_PATH);
        }
    }
}
