using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
[GenerateAuthoringComponent]

public struct ZombieBehavior : IComponentData
{
    public Enums.ZombieBehave behave;
}
