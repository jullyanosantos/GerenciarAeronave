using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public object Object { get; set; }
        public string Message { get; set; }
    }
}