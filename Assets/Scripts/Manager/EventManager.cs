using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
   public static event UnityAction GunFireEvent;
    public static void GunFireVFXEventCall() => GunFireEvent?.Invoke();

    public static event UnityAction ZombieAttackEvent;
    public static void ZombieAttackVFXEventCall() => ZombieAttackEvent?.Invoke();
}
