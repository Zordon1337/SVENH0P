using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Memory;

namespace SVENH0P
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern bool GetAsyncKeyState(int key);
        static void Main()
        {
            Mem m = new Mem();
            Console.WriteLine("Injecting!");
            {
                int procid = m.GetProcIdFromName("svencoop.exe");
                m.OpenProcess(procid);
            }
            
            while(true)
            {
                if (GetAsyncKeyState(0x20))
                {
                    m.WriteMemory("client.dll+5FC244", "int", "5");
                    m.WriteMemory("client.dll+5FC244", "int", "4");
                }
            }
            
            
        }
    }
}
