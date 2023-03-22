using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterComponentDI
{
    Rigidbody GetRigidbodyComponent();
    Animator GetAnimatorComponent();
}
