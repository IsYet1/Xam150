using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookClient.Data
{
    public class BookManager
    {
        const string Url = "http://xam150.azurewebsites.net/api/books/";
        private string authorizationKey = "25366a12-c72a-4c56-a657-a6c12618cb00";

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            if (String.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await client.GetStringAsync(Url + "login");
                authorizationKey = JsonConvert.DeserializeObject<String>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var client = await GetClient();
            var booksListJson =await  client.GetStringAsync(Url);
            var booksList = JsonConvert.DeserializeObject<IEnumerable<Book>>(booksListJson);

            return booksList;
        }

        public async Task<Book> Add(string title, string author, string genre)
        {
            var book = new Book()
            {
                Title = title,
                Genre = genre,
                Authors = new List<string>(new[] { author }),
                ISBN = "",
                PublishDate = DateTime.Now.Date,
            };

            HttpClient client = await GetClient();

            var bookJson = JsonConvert.SerializeObject(book);
            var bookHttpContent = new StringContent(bookJson, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(Url, bookHttpContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Book>(responseContent);
            
        }

        public async Task Update(Book book)
        {
            HttpClient client = await GetClient();

            string bookJson = JsonConvert.SerializeObject(book);
            HttpContent bookHttpContent = new StringContent(bookJson, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(Url + book.ISBN, bookHttpContent);

            var responseContent = await response.Content.ReadAsStringAsync();


        }

        public async Task Delete(string isbn)
        {
            HttpClient client = await GetClient();

            await client.DeleteAsync(Url + isbn);

        }
    }
}

