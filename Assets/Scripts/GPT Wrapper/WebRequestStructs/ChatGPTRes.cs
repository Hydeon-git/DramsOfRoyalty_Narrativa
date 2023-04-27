using System;
using System.Collections.Generic;

namespace GPT_Wrapper.WebRequestStructs {
    [Serializable]
    public struct ChatGPTRes
    {
        public List<ChatGPTChoices> choices;
    }
}
