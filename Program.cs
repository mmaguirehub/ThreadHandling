using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace ThreadHandling
{
    public class Program
    {
        static HttpClient _client = new HttpClient();

        public static void Main(string[] args)
        {
            _client.BaseAddress = new Uri(ConfigHelper.BooksApiBaseUri);

            Task<List<Book>> books = GetBooksAsync();

            books.Result.ForEach(book => OutputBookDetails(book));
            Console.ReadKey();
        }

        private static void OutputBookDetails(Book book)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Price: {book.Price}");
        }

        private static async Task<List<Book>> GetBooksAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("");
            List<Book> books = await response.Content.ReadAsAsync<List<Book>>();

            return response.IsSuccessStatusCode
                ? books
                : null;
        }

    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
