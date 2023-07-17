using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hits : MonoBehaviour
{
   
    [SerializeField] float Freezetime =2f;
    [SerializeField] AudioClip Falsesound;
    [SerializeField] AudioClip Finishsound;
    AudioSource audioSetting;
    Rigidbody rb;

    bool isTransitioning =false;
    void  Start() 
    {
    audioSetting= GetComponent<AudioSource>();    
    }

void finishstate()
{
    rb =GetComponent<Rigidbody>();
}
     private void OnCollisionEnter(Collision other) 
    {


        if (isTransitioning ) {return;}       
        switch (other.gameObject.tag)
        {          
            case "Start":
            Debug.Log( "start");
            break;

            case "Finish":
            LevelupFreezetime();
            break;

            default:
            Startcrashcheckpoint();
            break;  

        }   
        
    }
    void Startcrashcheckpoint()
    {
        isTransitioning = true;
        audioSetting.Stop();
        audioSetting.PlayOneShot(Falsesound);
        GetComponent<RocketMove>().enabled= false;
        Invoke("ReloadCheckpoint", Freezetime) ;
    }
    void LevelupFreezetime()
    {
        isTransitioning = true;
        audioSetting.Stop();
        audioSetting.PlayOneShot(Finishsound);
        GetComponent<RocketMove>().enabled=false;
        Invoke ("Levelup", Freezetime);
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
    //Restart checkpoint 
  void ReloadCheckpoint ()
    {
      int currentcheckpoint = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentcheckpoint);
      
    }
}
