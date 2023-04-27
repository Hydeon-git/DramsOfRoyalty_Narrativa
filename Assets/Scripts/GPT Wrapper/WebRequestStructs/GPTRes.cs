using System;
using System.Collections.Generic;

namespace GPT_Wrapper.WebRequestStructs {
    [Serializable]
    public struct GPTRes
    {
        public string id;
        public List<GPTChoices> choices;

    }
}
