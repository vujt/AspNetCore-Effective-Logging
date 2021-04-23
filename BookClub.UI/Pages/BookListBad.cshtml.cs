﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BookClub.Logic.Models;
using Microsoft.Extensions.Logging;
using BookClub.Infrastructure;
using BookClub.Infrastructure.BaseClasses;

namespace BookClub.UI.Pages
{
    public class BookListBadModel : BasePageModel
    {
        private readonly ILogger _logger;        
        public List<BookModel> Books;

        public BookListBadModel(ILogger<BookListModel> logger, IScopeInformation scope) : base(logger, scope)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {            
            using (var http = new HttpClient(new StandardHttpMessageHandler(HttpContext, _logger)))
            {
                //Books = (await http.GetFromJsonAsync<List<BookModel>>("https://localhost:44322/api/Book?throwException=true"))
                Books = (await http.GetFromJsonAsync<List<BookModel>>("https://bookclubapi20190719045604.azurewebsites.net/api/Book?throwException=true"))
                    .OrderByDescending(a=> a.Id).ToList();                
            }
        }       
    }
}