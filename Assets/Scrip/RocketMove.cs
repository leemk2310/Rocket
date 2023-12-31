using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    [SerializeField] float mainthrust = 600f;
    [SerializeField] float movethrust = 60f;
    [SerializeField] AudioClip Flysound;
    [SerializeField] ParticleSystem LeftParticle;
    [SerializeField] ParticleSystem RightParticle;
    [SerializeField] ParticleSystem MainParticle;
    Rigidbody rb;
    AudioSource  audioSource;
    
    
    // Start is called before the first frame update
    // check pul code
    //idpate  cac
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessPush();
        ProcessRotation();
    }

    void ProcessPush()
    {
        //set key to push
        // set value up, with verctor 2(2d), vector3 (3d)
       if( Input.GetKey(KeyCode.Space))
         { 
            rb.AddRelativeForce(Vector3.up * mainthrust * Time.deltaTime); 
            if (!audioSource.isPlaying)
             {
                audioSource.PlayOneShot(Flysound);
                
             } 
             //set particle to action
             if (!MainParticle.isPlaying)
             {
               MainParticle.Play();
             }
        }
        else 
        {
            audioSource.Stop();
           // MainParticle.Stop();
        }
    }
    void ProcessRotation()
    {   
        rb.freezeRotation= true;
         if (Input.GetKey(KeyCode.LeftArrow))
         {
            transform.Rotate(-new Vector3(1,0,0) * movethrust * Time.deltaTime);
            //set particle to action
            if (!LeftParticle.isPlaying)
              {
                LeftParticle.Play();
             }
             else{
             LeftParticle.Stop();
         }
         }
         else if (Input.GetKey(KeyCode.RightArrow))
         {
           
             transform.Rotate(new Vector3 (1,0,0)* movethrust * Time.deltaTime);
             //set particle to action
             if (!RightParticle.isPlaying)
              {
                 RightParticle.Play();
              }
              else {
                 RightParticle.Stop();
              }
     }
         rb.freezeRotation = false;
    }   
}
