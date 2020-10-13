using System;

struct Books
{
    private string _title;
    private float _price;
    private int _bookID;

    public void setValues(int bookID, string title, float price)
    {
        _bookID = bookID;
        _title = title;
        _price = price;
    }

    public void display()
    {
        Console.WriteLine("Book ID: {0}", _bookID);
        Console.WriteLine("Title: {0}", _title);
        Console.WriteLine("Price: {0}", _price);
    }
};

namespace teststruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Books book1 = new Books();
            book1.setValues(1001, "C Primer", 50.77f);
            book1.display();
            Console.ReadLine();
        }
    }
}
