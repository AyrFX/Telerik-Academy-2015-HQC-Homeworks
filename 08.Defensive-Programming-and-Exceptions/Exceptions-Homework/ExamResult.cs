using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("The grade can be only positive value or 0!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("The minimal grade can be positive value or 0!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("The minimal grade can't exceed maximal grade!");
        }

        if (comments == null || comments == string.Empty)
        {
            throw new ArgumentNullException("No comment entered!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
