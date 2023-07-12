using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.01f ;  
    [SerializeField] float xRange = 5f; 
    [SerializeField] float yRange = 5f;
    [SerializeField] GameObject[] lasers;
   


    [SerializeField] float pitchFactor = -2f;
    [SerializeField] float yawFactor = -2f;
    [SerializeField] float controllRollFactor = -20f;
    [SerializeField] float controllPitchFactor = -10f;

    float xThrow, yThrow;
  
  
    
   
   void Update()
    {
       ProcessTranslation();
       ProcessRotation();
       ProcessFiring();
    }

    
    void ProcessRotation() 
    {
       float pitchDueToPosition = transform.localPosition.y * pitchFactor;
       float pitchDueToControlls = yThrow * controllPitchFactor;
       
       
       float pitch = pitchDueToPosition + pitchDueToControlls ;
       float yaw = transform.localPosition.x * yawFactor;
       float roll = xThrow * controllRollFactor;
       transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    
    void ProcessTranslation() 
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

       float xoffset = xThrow * Time.deltaTime * moveSpeed;
       float yoffset = yThrow * Time.deltaTime * moveSpeed ;

       float newXposition = transform.localPosition.x + xoffset;
       float newYposition = transform.localPosition.y + yoffset;

       float clampedNewX = Mathf.Clamp(newXposition, -xRange , xRange);
       float clampedNewY = Mathf.Clamp(newYposition, -yRange, yRange);


       transform.localPosition = new Vector3 (clampedNewX, transform.localPosition.y, transform.localPosition.z);
       transform.localPosition = new Vector3 (transform.localPosition.x, clampedNewY , transform.localPosition.z );
    }


     void ProcessFiring()
    {
      if(Input.GetButton("Fire1"))
       {
         SetBlastersActive(true);    
       }
       else 
       {
         SetBlastersActive(false); 
       }
    }


    void SetBlastersActive(bool isActive)
    {
      foreach (GameObject laser in lasers)
      {
         var emissionModule = laser.GetComponent<ParticleSystem>().emission;
         emissionModule.enabled = isActive;
         
      }
    }

    
 




}

