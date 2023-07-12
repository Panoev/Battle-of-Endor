using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    GameObject parentGameObject;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int hitScore = 2;
    

    ScoreBoard scoreBoard;
   
    
     
    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidBody();
        parentGameObject = GameObject.FindWithTag("EmptyParent");
    }
    
    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    
    
    
    void OnParticleCollision(GameObject other) 
    {
        if(hitScore < 1 )
        {
           KillTheEnemy();
        }
        
        ProcessHit(); 
    }
    
    void KillTheEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position , Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform ; 
        Destroy(gameObject);
        scoreBoard.IncreaseScore(scorePerHit);
    }
    
    void ProcessHit()
    {
      GameObject vfx = Instantiate(hitVFX, transform.position , Quaternion.identity);
      vfx.transform.parent = parentGameObject.transform ; 
      hitScore--;
      
    }

}
