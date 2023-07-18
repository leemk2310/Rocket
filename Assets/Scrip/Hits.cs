using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hits : MonoBehaviour
{
   
    [SerializeField] float Freezetime =2f;
    [SerializeField] AudioClip Falsesound;
    [SerializeField] AudioClip Finishsound;
    [SerializeField] ParticleSystem FalseParticle;
    [SerializeField] ParticleSystem FinishParticle;

    AudioSource audioSetting;
    Rigidbody rb;

    bool isTransitioning =false;
    bool CheatCollision = false;
    void  Start() 
    {
    audioSetting= GetComponent<AudioSource>();    
    }
      void Update()
       {
        CheatKey();
        
       }
    void CheatKey() { // Cheat up level add on void update
        if(Input.GetKeyDown(KeyCode.A))
        {
            Levelup();
        }
        else if (Input.GetKeyDown (KeyCode.D))
        {
            CheatCollision = !CheatCollision; // Cheat collision ko die  kjhi va cham
        }
    }  

      void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning ) {return;}       
        switch (other.gameObject.tag)
        {          
            case "Start":
             Debug.Log("start");
            break;
            case "Finish":
            LevelupFreezetime ();
            break;
            default:
           Freezecheckpoint();
            break;  

        }   
        
   }
    
    void LevelupFreezetime()
     {
      isTransitioning = true;// xử lý action và trigger 1 sound khi up level
        audioSetting.Stop();
       audioSetting.PlayOneShot(Finishsound);
         FinishParticle.Play();
       GetComponent<RocketMove>().enabled=false;
        Invoke ("Levelup", Freezetime);
     }
     void Freezecheckpoint()
     {
     isTransitioning = true;// xử lý action và trigger 1 sound khi va chạm
       audioSetting.Stop();
       audioSetting.PlayOneShot(Falsesound);
       FalseParticle.Play();
        GetComponent<RocketMove>().enabled= false;
        Invoke("ReloadCheckpoint", Freezetime) ;
     }
     void Levelup()
    {
        int currentcheckpoint = SceneManager.GetActiveScene().buildIndex; // lan dau la index hien tai: 1
        int nextcSceneIndex = currentcheckpoint + 1; //tang len 1 : 1_+1
        if (nextcSceneIndex == SceneManager.sceneCountInBuildSettings) // neu la man hinh cuoi cung  = tong level
        {
            nextcSceneIndex = 0; // thi gan level tro lai =0
        }

        SceneManager.LoadScene(nextcSceneIndex); //load lai index
        

    }
      // Restart checkpoint 
    void ReloadCheckpoint ()
    {
      int currentcheckpoint = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentcheckpoint);
      
    }
}
