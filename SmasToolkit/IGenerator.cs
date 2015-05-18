using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmasToolkit
{
    public interface IGenerator
    {
        void Build(string dirPath);
    }
}
