using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HvorErBat.Services
{
    public interface IBusDataStore<T>
    {
        Task<IEnumerable<T>> GetBusList();
    }
}
