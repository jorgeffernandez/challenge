using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Api.Models
{
    public class Response
    {
        bool _isSuccess;
        object _responseData;
        string _message;
        object _result;

        #region Public Properties

        public bool IsSuccess
        {
            get
            {
                return this._isSuccess;
            }
            set
            {
                this._isSuccess = value;
            }
        }

        public object ResponseData
        {
            get
            {
                return this._responseData;
            }
            set
            {
                this._responseData = value;
            }
        }

        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = value;
            }
        }

        public object Result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }

        #endregion
    }
}
