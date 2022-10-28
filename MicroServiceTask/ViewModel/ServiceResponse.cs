using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask.ViewModel
{
    public class ServiceResponse<T>
    {
        public T  Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }       
        public int TotalPages { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
