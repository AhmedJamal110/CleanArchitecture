using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomException
{
    public class CustomValidationException : Exception
    {

        public List<string> ErrorMessage { get; set; }
        public string FriendlErrorMessage { get; set; }


        public CustomValidationException(List<string> errorMessage, string friendlErrorMessage)
        {
            ErrorMessage = errorMessage;
            FriendlErrorMessage = friendlErrorMessage;
        }


    }

}

