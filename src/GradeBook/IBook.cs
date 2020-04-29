using System.Diagnostics.Tracing;

namespace GradeBook
{
    public interface IBook
    {
        public void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;

    }
}