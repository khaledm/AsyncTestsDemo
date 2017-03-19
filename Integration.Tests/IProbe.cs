using System;
using System.IO;

namespace Integration.Tests
{
    public interface IProbe
    {
        bool IsSatisfied();

        void Sample();

        //void DescribeAcceptanceCriteriaTo(Description d);

        //void DescribeFailureTo(Description d);
    }

    public class FileLengthProbe : IProbe
    {
        private const int NOT_SET = 0;

        private long lastFileLength = NOT_SET;

        private string filePath;

        public FileLengthProbe(string filePath, Func<long,bool> matcher)
        {
            this.filePath = filePath;
            Matcher = matcher;            
        }
        public Func<long,bool> Matcher { get; private set; }

        public bool IsSatisfied()
        {
            return lastFileLength != NOT_SET && Matcher(lastFileLength);
        }

        public void Sample()
        {
            FileInfo filefUnderTest = new FileInfo(Path.Combine(filePath));            
            lastFileLength = filefUnderTest.Length;
        }
    }
}
