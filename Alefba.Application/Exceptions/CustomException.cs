using System.Net;

namespace Alefba.Application.Exceptions
{
    public class CustomException : Exception
    {

        public CustomException(HttpStatusCode httpStatusCode)
        {
            Message = httpStatusCode.GetDescription();
            Status = (int)httpStatusCode;
        }

        public CustomException(int customHttpStatus, string errorMessage)
        {
            Status = customHttpStatus;
            Message = errorMessage;
        }

        public override string Message { get; }
        public int Status { get; private set; }
    }

}
