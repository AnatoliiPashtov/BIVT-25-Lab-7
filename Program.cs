using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp13
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Human human1 = new Human("Dimka", 17);
      Student student1 = new Student("Vovka", 18, "Misis");

      Human hiddenStudent = new Student("Lerka", 19, "Misis");

      hiddenStudent.Simple();
      hiddenStudent.Print();

      //human1.Simple();
      //human1.Print();

      //student1.Simple();
      //student1.Print();

      Human[] queue = new Human[] {human1, student1, hiddenStudent};
      for (int i = 0; i < queue.Length; i++)
      {
        //if (queue[i] is Student)
        //{
        //  Console.WriteLine(s.Unik);
        //  Student s = queue[i] as Student;
        //}
        Student s = queue[i] as Student;
        if (s != null)
        {
          Console.WriteLine(s.Unik);
        }
      }
    }
  }

  public class Human
  {
    protected string _name;
    protected int _age;

    public Human(string name, int age)
    {
      _name = name;
      _age = age;
    }
    public void Simple()
    {
      Console.WriteLine("Human Method");
    }
    public virtual void Print()
    {
      Console.WriteLine($"Human:  Name:{_name}  Age:{_age}");
    }
  }

  public class Student : Human
  {
    private string _unik;

    public string Unik => _unik;

    public Student(string name, int age, string unik) : base(name, age)
    {
      _unik = unik;
    }
    public new void Simple() // Специальное скрытие метода
    {
      Console.WriteLine("Student Method");
    }
    public override void Print()
    {
      Console.WriteLine($"Student:  Name:{_name}  Age:{_age}  Unik:{_unik}");
    }
  }
}