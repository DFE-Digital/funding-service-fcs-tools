using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummarisedActuals.Client.DedsSearchService;
using System.Configuration;

namespace SummarisedActuals.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Client client = new Client();
                Console.Clear();
                client.Execute();
            }
        }
    }
}
