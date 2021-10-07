using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ui = new ClaimProgramUI();
            ui.Run();
            Console.WriteLine("\n");
        }
    }
}
