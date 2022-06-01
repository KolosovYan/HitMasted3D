using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    public Animator Anim;
    public Rigidbody[] AllRigidbodys;
    public bool IsAlive;

    private void Awake()
    {
        MakePhysical(true);
    }

    public void MakePhysical(bool status)
    {
        Anim.enabled = status;
        for (int i = 0; i < AllRigidbodys.Length; i++)
        {
            AllRigidbodys[i].isKinematic = status;
        }
        IsAlive = status;
    }
}
