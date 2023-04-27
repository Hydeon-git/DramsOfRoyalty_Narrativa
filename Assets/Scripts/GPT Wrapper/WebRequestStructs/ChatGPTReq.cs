﻿using System.Collections.Generic;

namespace GPT_Wrapper.WebRequestStructs {
    public struct ChatGPTReq
    {
        public string model;
        public List<Message> messages;
        public int max_tokens;
        public float temperature;
    }
}
