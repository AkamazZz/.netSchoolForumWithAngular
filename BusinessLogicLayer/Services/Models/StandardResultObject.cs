using System;


namespace BusinessLogicLayer.Services.Models
{
    public abstract class StandardResultObject
    {
        public StandardResultObject()
        {
            success = false;
            userMessage = string.Empty;
            internalMessage = string.Empty;
            exception = null;
        }
        public bool success { get; set; }
        public string userMessage { get; set; }
        internal string internalMessage { get; set; } // the end user will not see it.
        internal Exception exception { get; set; } // the end user will not see it.
    }
}
