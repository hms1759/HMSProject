using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Share
{
    public class UserManagmentResponse
    {


        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public IEnumerable<string> Error { get; set; }
        public DateTime?  ExpireDate { get; set; }
    }
}
