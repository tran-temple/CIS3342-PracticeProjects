using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        //properties
        private string isbn;
        private string title;
        private string author;
        private string bookType;
        private string option;
        private int quantity;
        private double price;
        private double totalCost;

        public Book()
        {

        }

        public Book(string isbn, string title, string author, string bookType, string option, int quantity, double price, double totalCost)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.bookType = bookType;
            this.option = option;
            this.quantity = quantity;
            this.price = price;
            this.totalCost = totalCost;
        }



        // Encapsulate fields
        public string Isbn { get => isbn; set => isbn = value; }

        public string Title { get => title; set => title = value; }

        public string Author { get => author; set => author = value; }

        public string BookType { get => bookType; set => bookType = value; }

        public string Option { get => option; set => option = value; }

        public int Quantity { get => quantity; set => quantity = value; }

        public double Price { get => price; set => price = value; }

        public double TotalCost { get => totalCost; set => totalCost = value; }
      
    }
}
