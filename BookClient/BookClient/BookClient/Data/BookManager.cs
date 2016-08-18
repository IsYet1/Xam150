﻿using Newtonsoft.Json;
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

            return JsonConvert.DeserializeObject<Book>(
                await response.Content.ReadAsStringAsync()
                );
            
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

