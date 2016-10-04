using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerfectWeddings.ViewModels
{
    public class JsonResponse
    {
        public bool IsSucess { get; set; }
        public string ErrorMessage { get; set; }
        public string Result { get; set; }
    }
}