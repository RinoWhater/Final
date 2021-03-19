using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Achei.Client.Services.Application.ViewModels {
    public class ObjectResultViewModel {

        public ObjectResultViewModel(bool success, object data, HttpStatusCode statusCode, string message = null) {
            Success = success;
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }

        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
