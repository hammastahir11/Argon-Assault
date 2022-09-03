using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float loadDelay=1f;
   [SerializeField] ParticleSystem crashVFX;
   void OnTriggerEnter(Collider other) {
    startCrashSequence();
    
   }


    void startCrashSequence()
    {
        crashVFX.Play();
        GetComponent<PlayerControl>().enabled=false;
        GetComponent<Rigidbody>().useGravity=true;
        
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel(){
        int currentSceneIndex= SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
