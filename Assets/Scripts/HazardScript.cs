using System;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class HazardScript : MonoBehaviour{
    
    [SerializeField] Slider healthBar;

    private void OnCollisionEnter(Collision col){
        if (col.gameObject.CompareTag($"Player"))
            if (healthBar.value > 1){
                healthBar.value -= 2;
            }else
            {
                healthBar.value = 0; 
            }
    }
}