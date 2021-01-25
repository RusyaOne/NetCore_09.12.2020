using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Services
{
    public interface IRestApiExampleClient
    {
        public byte[] GetFileBytes();
    }
}
