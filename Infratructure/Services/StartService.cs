using Application.Abstraction;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure.Services
{
    public class StartService : BackgroundService
    {
        private readonly ICommandRepository _commandRepository;
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(1);
        public StartService(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }


        public async Task Execute()
        {
            await ExecuteAsync();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken = default)
        {
            while (!stoppingToken.IsCancellationRequested) 
            {
                try
                {
                    var command = _commandRepository.PeekAndDeque();
                    if (command == null) 
                    {
                        await Task.Delay(_timeout);
                    }
                    else
                    {
                        command.Execute();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
