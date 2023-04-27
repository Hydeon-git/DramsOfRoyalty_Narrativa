using UnityEngine.Events;

namespace GPT_Wrapper {
    // This is required for older versions of Unity
    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string>{}
}