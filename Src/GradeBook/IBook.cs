namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatisitcs();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
}