using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBusinessObject;

namespace BusinessObject
{
    public class JobService : IJobService
    {
        public string GetJob()
        {
            return "Hello World";
        }
    }
}
