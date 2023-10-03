using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.BLL.Contracts
{
    public interface IBulkImportService
    {
        Task ImportJsonAsync(Stream jsonStream);
    }
}
