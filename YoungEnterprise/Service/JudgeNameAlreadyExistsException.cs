using System;
using System.Runtime.Serialization;

namespace Service
{
    public class UserNameAlreadyExistsException : ApplicationException
    {
        string JudgeName { get; set; }

        public UserNameAlreadyExistsException(string judgeName) : base(judgeName)
        {
            JudgeName = judgeName;
        }

        public override string Message
        {
            get
            {
                return "Kunne ikke oprette dommmer, fordi brugeren '" + JudgeName + "' allerede eksisterer i systemet!";
            }

        }
    }
}