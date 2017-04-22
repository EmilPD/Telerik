namespace ExceptionsHomework.Models
{
    using System;

    using Contracts;

    public class CSharpExam : Exam
    {
        private const int MinGrade = 0;
        private const int MaxGrade = 100;
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < MinGrade || value > MaxGrade)
                {
                    throw new ArgumentException($"Score must be a value between {MinGrade} and {MaxGrade}!");
                }

                this.Score = value;
            }
        }

        public override ExamResult GetExamResult()
        {
            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}