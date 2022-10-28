using System;
using System.Collections.Generic;
using System.Text;

namespace PMT_BAL.Common
{
    /// <summary>
    /// service Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        /// <summary>
        /// data
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// successs
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
