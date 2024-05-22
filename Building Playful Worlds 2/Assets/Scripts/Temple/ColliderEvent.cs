using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEvent : MonoBehaviour
{
    public UnityEvent Collided;

    private void OnTriggerEnter(Collider other)
    {
        Collided.Invoke();
    }

}
