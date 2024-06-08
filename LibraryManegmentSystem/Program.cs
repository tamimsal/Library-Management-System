﻿using LibraryManegmentSystem.repositories.Implementations;
using LibraryManegmentSystem.repositories.Interfaces;
using LibraryManegmentSystem.services.Implementations;
using LibraryManegmentSystem.services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryManegmentSystem{
    class MainClass
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var taskManager = host.Services.GetRequiredService<TaskManegerFun>();
            
            while (true)
            {
                taskManager.MainScreen();
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IBookRepository, BookRepository>();
                    services.AddTransient<IPatronRepository, PatronRepository>();
                    services.AddTransient<IPatronServices, PatronServices>();
                    services.AddTransient<IBookServices, BookServices>();
                    services.AddTransient<ITransactionsServices, TransactionsServices>();
                    services.AddTransient<TaskManegerFun>();
                });
    }
}

//to do: 
// id system
// N-tier 
// agile vs waterfall, scrum master
// dependancy injection