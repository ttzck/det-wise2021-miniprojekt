using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnEvent : MonoBehaviour
{
    [SerializeField] private GameObject @object;

    private void Start()
    {
        foreach (var notify in GetComponents<INotify>())
        {
            notify.Event += OnEvent;
        }
    }

    private void OnEvent()
    {
        Instantiate(@object, transform.position, transform.rotation);
    }
}
