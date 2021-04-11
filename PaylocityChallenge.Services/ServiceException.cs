using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PaylocityChallenge.Services
{
    public class ServiceException: Exception
    {
        private int _errorcode = 0;

        public int ErrorCode {
            get
            {
                return this._errorcode;
            }
            set
            {
                this._errorcode = value;
            }
        }

        public ServiceException(string message) : base(message)
        {
        }

        public ServiceException(string message, int errcode)
        {
            this._errorcode = errcode;
        }

        protected ServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ServiceException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public ServiceException(string message, Exception innerException, int errcode)
           : base(message, innerException)
        {
            this._errorcode = errcode;
        }
    }
}
