using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string messege):base(true,messege)
        {

        }

        public SuccessResult():base(true)
        {

        }
    }
}
