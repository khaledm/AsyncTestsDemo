using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Integration.Tests
{
    [TestFixture]
    public class FileLengthTests
    {
        string path;

        [SetUp]
        public void Setup()
        {
            // create an file in the executing assembly folder
            path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestFileName" + DateTime.Now.Millisecond + "txt");
            var fileUnderTest = new FileInfo(path);
            fileUnderTest.Create();
        }

        [Test]
        public void TestFileLengthProbingEndToEnd()
        {
            var probe = new FileLengthProbe(path, (lastLength) => lastLength >= 100);
            Poller.AssertEventually(probe, 1000, 100);
        }
    }
}
