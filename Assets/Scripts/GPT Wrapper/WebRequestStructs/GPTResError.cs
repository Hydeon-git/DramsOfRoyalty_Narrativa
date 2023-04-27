using System;

namespace GPT_Wrapper.WebRequestStructs {
    [Serializable]
    public struct ChatGPTResError
    {
        public Error error;

    }

    [Serializable]
    public struct Error {
      public string message;
    }
}