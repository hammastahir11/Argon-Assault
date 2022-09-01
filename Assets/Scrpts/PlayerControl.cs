using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    float xThrow;
    float yThrow;
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed=30f;
    [SerializeField] float xRange=10f;
    [SerializeField] float yRange=30f;
    [SerializeField] float positionPitchFactor=-2f;
    [SerializeField] float controlPitchFactor=-10f;
    [SerializeField] float positionYawFactor=2f;
    [SerializeField] float controlRollFactor=-20f;
    [SerializeField] InputAction fire;
    [SerializeField] GameObject[] lasers;

    
    void Start()
    {
        
    }
    private void OnEnable() {
        movement.Enable();
        fire.Enable();
    }
    private void OnDisable() {
        movement.Disable();
        fire.Disable();
    }


 
    void Update()
    {
        Processtranslation();
        ProcessRotation();
        processFiring();


    }

    void ProcessRotation(){
 
        float pitch=transform.localPosition.y*positionPitchFactor + yThrow*controlPitchFactor;

        float yaw=transform.localPosition.x * positionYawFactor ;

        float roll=xThrow * controlRollFactor;


        transform.localRotation=Quaternion.Euler(pitch,yaw,roll);
    }

    void Processtranslation(){
        xThrow=movement.ReadValue<Vector2>().x;
        yThrow= movement.ReadValue<Vector2>().y;

        float xOffset=xThrow*controlSpeed*Time.deltaTime;
        float newXPos=transform.localPosition.x + xOffset;
        float xClamped= Mathf.Clamp(newXPos,-xRange,xRange);


        float yOffset=yThrow*controlSpeed*Time.deltaTime;
        float newYPos=transform.localPosition.y + yOffset;
        float yClamped= Mathf.Clamp(newYPos,-yRange,yRange);
        
        transform.localPosition= new Vector3(xClamped,yClamped,transform.localPosition.z);
    }


    void processFiring(){
        if(fire.ReadValue<float>() > 0.5){
            ActivateLasers();
        }
        else{
             DeactivateLasers();
        }
    }

    void DeactivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule=laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled=false;
        }
    }

    void ActivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule=laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled=true;
            
        }
    }
}
