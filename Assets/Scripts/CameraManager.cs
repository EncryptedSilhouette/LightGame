using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    public Transform Target;

    private void Awake()
    {
        if (Target is null) return;
        transform.parent = Target;
    }
}
