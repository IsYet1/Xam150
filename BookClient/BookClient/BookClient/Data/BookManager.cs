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
        private string authorizationKey;

        private async Task<HttpClient> GetClient()
        {
            var client = new HttpClient();
            if (!String.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await client.GetStringAsync(Url + "login");
                authorizationKey = JsonConvert.DeserializeObject<String>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            // TODO: use GET to retrieve books
            throw new NotImplementedException();
        }

        public Task<Book> Add(string title, string author, string genre)
        {
            // TODO: use POST to add a book
            throw new NotImplementedException();
        }

        public Task Update(Book book)
        {
            // TODO: use PUT to update a book
            throw new NotImplementedException();
        }

        public Task Delete(string isbn)
        {
            // TODO: use DELETE to delete a book
            throw new NotImplementedException();
        }
    }
}

