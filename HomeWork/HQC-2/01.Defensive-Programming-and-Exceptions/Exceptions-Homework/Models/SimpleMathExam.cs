namespace ExceptionsHomework.Models
{
    using System;

    using Contracts;

    public class SimpleMathExam : Exam
    {
        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            if (problemsSolved < 0)
            {
                problemsSolved = 0;
            }

            if (problemsSolved > 10)
            {
                problemsSolved = 10;
            }

            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Solved problems must be between 0 and 10!");
                }

                this.problemsSolved = value;
            }
        }

        public override ExamResult GetExamResult()
        {
            if (this.ProblemsSolved < 3)
            {
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            }
            else if (this.ProblemsSolved <= 3 && this.ProblemsSolved <= 6)
            {
                return new ExamResult(4, 2, 6, "Average result: There is hope.");
            }
            else
            {
                return new ExamResult(6, 2, 6, "Excelent result: You will become master one day.");
            }
        }
    }
}