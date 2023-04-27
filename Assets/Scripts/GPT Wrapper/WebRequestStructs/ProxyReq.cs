using System.Collections.Generic;

namespace GPT_Wrapper.WebRequestStructs {
    public struct ProxyReq
    {
        public string model;
        public List<Message> messages;
        public int max_tokens;
        public float temperature;
    }
}
