using System.Diagnostics.Metrics;
using System.IO.Pipes;
using System.Numerics;

namespace Lab7.Purple
{
  public class Task3
  {
    public struct Participant
    {
      // Поля
      private string _name;
      private string _surname;
      private double[] _marks;
      private int[] _places;
      private int _topPlace;
      private double _totalMark;

      // Свойства
      public string Name => _name;
      public string Surname => _surname;
      public double[] Marks => _marks.ToArray();
      public int[] Places
      {
        get
        {
          return new int[0];
        }
      }
      public int TopPlace => _topPlace;
      public double TotalMark => _totalMark;
      public int Score
      {
        get
        {
          return 0;
        }
      }

      // Конструкторы
      public Participant(string name, string surname)
      {
        _name = name;
        _surname = surname;
        _marks = new double[7] { 0, 0, 0, 0, 0, 0, 0 };
        _places = new int[7];
        _topPlace = 0;
        _totalMark = 0;
      }

      // Методы
      int counterMarks = 0;
      public void Evaluate(double result)
      {
        _marks[counterMarks++] = result;
      }
      public static void SetPlaces(Participant[] participants)
      {
        /*
         * Использовать матрицу
         * строки это судьи
         * столбцы спортсмены 
         */
        int[,] arrayPlaces = new int[7, participants.Length];
        for (int i = 0; i < participants.Length; i++)
        {
          double[] partMarks = participants[i]._marks;
          double limit = 7;
          for (int j = 0; j < 7; j++)
          {
            int mxi = 0;
            double mx = int.MinValue;
            for (int k = 0; k < 7; k++)
              if ((partMarks[k] > mx) && (mx < limit))
                (mx, mxi) = (partMarks[k], k);
            limit = mx;
            Console.WriteLine($"{mx}  {mxi}  {limit}");
            arrayPlaces[j, i] = 7 - mxi;
          }
        }
        for (int i = 0; i < arrayPlaces.GetLength(0); i++)
        {
          for (int j = 0; j < arrayPlaces.GetLength(1); j++)
            Console.Write(arrayPlaces[i, j] + " ");
          Console.WriteLine();
        }
        Console.WriteLine();
      }
      public static void Sort(Participant[] array)
      {

      }
      public void Print()
      {
        Console.Write($"------------\nName:{_name}  Surname:{_surname}\nMarks:");
        for (int i = 0; i < _marks.Length; i++)
          Console.Write(_marks[i] + " ");
        Console.Write("\nPlaces:");
        for (int i = 0; i < _places.Length; i++)
          Console.Write(_places[i] + " ");
        Console.WriteLine($"\nTopPlace:{_topPlace}  totalMark:{_totalMark}\n------------");
      }
    }
  }
}
