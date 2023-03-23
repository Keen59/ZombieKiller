using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField]private ParticleSystem FireParticleSystem;

    private void OnEnable()
    {
        EventManager.GunFireEvent += FireParticle;
    }

    private void OnDisable()
    {
        EventManager.GunFireEvent -= FireParticle;
    }

    private void FireParticle()
    {
        FireParticleSystem.Play();
        FireParticleSystem.transform.GetComponent<Light>().enabled = true;
        Invoke("LightClose",0.1f);
    }
    private void LightClose()
    {
        FireParticleSystem.transform.GetComponent<Light>().enabled = false;
    }
}
