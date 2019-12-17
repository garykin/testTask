using System.Collections.Generic;

namespace test_task
{
    public class ParsingResultDto
    {
        public ParsingResultDto()
        {
            IncorrectLinesNumbers = new List<int>();
        }

        public List<int> IncorrectLinesNumbers { get; set; }
        public int MaxSumLineNumber { get; set; }
        public double MaxSum { get; set; }
    }
}