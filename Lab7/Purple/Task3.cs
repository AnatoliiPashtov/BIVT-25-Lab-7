using System.Collections.Generic;
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
      public int[] Places => _places.ToArray();
      public int TopPlace => _topPlace;
      public double TotalMark
      {
        get
        {
          for (int i = 0; i < _marks.Length; i++)
            _totalMark += _marks[i];
          _totalMark = Math.Round(_totalMark, 7);
          return _totalMark;
        }
      }
      public int Score
      {
        get
        {
          return _places.Sum();
        }
      }

      // Конструкторы
      public Participant(string name, string surname)
      {
        _name = name;
        _surname = surname;
        _marks = new double[7] { 0, 0, 0, 0, 0, 0, 0 };
        _places = new int[7];
        _topPlace = int.MaxValue;
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
        for (int i = 0; i < 7; i++)
        {
          participants = participants.OrderBy(p => p.Marks[i]).ToArray();
          for (int j = 0; j < participants.Length; j++)
          {
            participants[j]._places[i] = participants.Length - j;
            participants[j]._topPlace = Math.Min(participants[j].TopPlace, participants.Length - j);
          }
        }
        ///*
        // * Использовать матрицу
        // * строки это судьи
        // * столбцы спортсмены 
        // */
        //int[,] arrayPlaces = new int[7, participants.Length];

        //for (int i = 0; i < 7; i++)
        //{
        //  double limit = 7;
        //  for (int j = 0; j < participants.Length; j++)
        //  {
        //    //double partMark = participants[j]._marks[i];
        //    int mxi = 0;
        //    double mx = double.MinValue;
        //    for (int k = 0; k < participants.Length; k++)
        //      if ((participants[k]._marks[i] > mx) && (participants[k]._marks[i] < limit))
        //        (mx, mxi) = (participants[k]._marks[i], k);
        //    limit = mx;
        //    arrayPlaces[i, j] = mxi + 1;
        //    //Console.WriteLine($"{mx}  {mxi}  {limit}");
        //  }
        //  //Console.WriteLine("---");
        //}
        //for (int i = 0; i < participants.Length; i++)
        //  for (int j = 0; j < 7; j++)
        //    participants[i]._places[j] = arrayPlaces[j, i];

        //for (int i = 0; i < arrayPlaces.GetLength(0); i++)
        //{
        //  for (int j = 0; j < arrayPlaces.GetLength(1); j++)
        //    Console.Write(arrayPlaces[i, j] + " ");
        //  Console.WriteLine();
        //}
        //Console.WriteLine();

        for (int i = 0; i < participants.Length; i++)
        {
          Console.WriteLine($"{participants[i]._name}  {participants[i]._surname}");
          Console.WriteLine($"{participants[i].TotalMark}  {participants[i].TopPlace}  {participants[i]._topPlace}  {participants[i]._places.Sum()}");
          for (int j = 0; j < participants[i].Marks.Length; j++)
            Console.Write(participants[i].Marks[j] + " ");
          Console.WriteLine();
          for (int j = 0; j < participants[i]._places.Length; j++)
            Console.Write(participants[i]._places[j] + " ");
          Console.WriteLine("\n---");
        }
      }
      public static void Sort(Participant[] array)
      {
        for (int i = 0; i < array.Length; i++)
          for (int j = 0; j < array.Length - i - 1; j++)
            if (array[j].Places.Sum() > array[j + 1].Places.Sum())
              (array[j], array[j + 1]) = (array[j + 1], array[j]);
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
