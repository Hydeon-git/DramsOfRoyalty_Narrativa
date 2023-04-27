using System;

namespace GPT_Wrapper.WebRequestStructs {

    [Serializable]
    public class Message 
    {
        public string role;
        public string content;

        public Message(string r, string c) {
            role = r;
            content = c;
        }
    }
}