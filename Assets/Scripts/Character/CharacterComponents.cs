using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponents : MonoBehaviour, CharacterComponentDI
{
    private Rigidbody rb;
    private Animator animator;

    public Animator GetAnimatorComponent()
    {
        return animator;
    }

    public Rigidbody GetRigidbodyComponent()
    {
        return rb;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>();
    }


 
}
