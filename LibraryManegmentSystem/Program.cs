using LibraryManegmentSystem.repositories.Implementations;
using LibraryManegmentSystem.repositories.Interfaces;
using LibraryManegmentSystem.services.Implementations;
using LibraryManegmentSystem.services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryManegmentSystem{
    class MainClass
    {
        // web application and web api -- check and see 
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
                    services.AddSingleton<IBookRepository, BookRepository>();
                    services.AddSingleton<IPatronRepository, PatronRepository>();
                    services.AddSingleton<IPatronServices, PatronServices>();
                    services.AddSingleton<IBookServices, BookServices>();
                    services.AddSingleton<ITransactionsServices, TransactionsServices>();
                    services.AddSingleton<TaskManegerFun>();
                });
    }
}

//to do: 
// id system
// N-tier 
// agile vs waterfall, scrum master
