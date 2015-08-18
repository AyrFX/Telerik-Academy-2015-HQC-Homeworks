using System;

public class SimpleMathExam : Exam
{
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

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved <= 1)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved <= 3)
        {
            return new ExamResult(3, 2, 6, "Average result: almost nothing done.");
        }
        else if (this.ProblemsSolved <= 5)
        {
            return new ExamResult(4, 2, 6, "Average result: half problems solved.");
        }
        else if (this.ProblemsSolved <= 7)
        {
            return new ExamResult(5, 2, 6, "Average result: more than half problems solved.");
        }
        else
        {
            return new ExamResult(6, 2, 6, "Good result: almost all problems solved.");
        }
    }
}
