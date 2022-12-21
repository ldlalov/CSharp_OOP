using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        string Model { get; set; }
        string Color { get; set; }
        string Start();
        string Stop();
    }
}
