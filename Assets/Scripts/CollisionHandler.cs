using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticle;
    
    
    
    void OnTriggerEnter(Collider other) 
    {
       StartCrashSequence();
       Invoke("ReloadLevel", 1f);
    }
    
    void StartCrashSequence()
     {
       GetComponent<PlayerController>().enabled = false ;
       crashParticle.Play();
       foreach (MeshRenderer meshInChild in GetComponentsInChildren<MeshRenderer>())
       meshInChild.enabled = false;
 
       foreach (Collider colliderInChild in GetComponentsInChildren<Collider>())
       colliderInChild.enabled = false;
       
     }
     
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }            

}
