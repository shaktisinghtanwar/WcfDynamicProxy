using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IBusinessObject
{
    [ServiceContract]
    public interface IJobService
    {
        [OperationContract]
        string GetJob();
    }
}
