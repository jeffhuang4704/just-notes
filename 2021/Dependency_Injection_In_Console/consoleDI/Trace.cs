using System;
using System.Collections.Generic;
using System.Text;

namespace consoleDI
{
    public interface ITrace
    {
        public void Dump(string msg);
    }
    class Trace : ITrace
    {
        public void Dump(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine(msg);
        }
    }
}
