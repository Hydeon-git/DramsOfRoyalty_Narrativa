﻿namespace GPT_Wrapper.WebRequestStructs {
    public struct GPTReq
    {
        public string model;
        public string prompt;
        public int max_tokens;
        public float temperature;
    }
}
