using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using IBusinessObject;

namespace BusinessObject
{
    public class BusinessObjectFactory
    {
        public static T GetInstance<T>() where T : class
        {
            Type type = typeof (T);
            switch (type.FullName)
            {
                case "IBusinessObject.IJobService":
                    return new JobService() as T;
            }
            return null;
        }
    }
}
