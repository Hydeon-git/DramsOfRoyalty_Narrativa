using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    [SerializeField] GameObject dialog;
    private void Start()
    {
        dialog.SetActive(true);
    }
}
