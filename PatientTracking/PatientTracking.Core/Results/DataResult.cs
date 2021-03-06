﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PatientTracking.Core.Results
{
    public class DataResult<T> : Result
    {
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
