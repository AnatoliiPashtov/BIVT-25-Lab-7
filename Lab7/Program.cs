namespace Lab7
{
  public class Program
  {
    public static void Main()
    {
      Purple.Task3.Participant p1 = new Purple.Task3.Participant("Вик", "Пол");
      double[] a = { 5.93, 5.44, 1.20, 0.28, 1.57, 1.86, 5.89 };
      for (int i = 0; i < a.Length; i++)
        p1.Evaluate(a[i]);
      Purple.Task3.Participant p2 = new Purple.Task3.Participant("ик1", "ол1");
      double[] b = { 3.27, 2.43, 0.90, 5.61, 3.12, 3.76, 3.73 };
      for (int i = 0; i < b.Length; i++)
        p2.Evaluate(b[i]);
      Purple.Task3.Participant p3 = new Purple.Task3.Participant("к2", "л2");
      double[] c = { 1.68, 3.79, 3.62, 2.76, 4.47, 4.26, 5.79 };
      for (int i = 0; i < c.Length; i++)
        p3.Evaluate(c[i]);
      p1.Print();
      p2.Print();
      p3.Print();
      Purple.Task3.Participant[] f = { p1, p2, p3 };
      Purple.Task3.Participant.SetPlaces(f);
      //p.Print();
    }
  }
}
