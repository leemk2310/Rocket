using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hits : MonoBehaviour
{
    [SerializeField] float Freeztime = 2f;
    MeshRenderer Mesh;
     private void OnCollisionEnter(Collision other) 
    {
               
        switch (other.gameObject.tag)
        {          
            case "Start":
            Debug.Log( "start");
            break;

            case "Obstacle":
            Debug.Log(" Loser!!!!!!");
            break;

            case "Finish":
            Levelup();
            break;

            default:
            ReloadCheckpoint();
            break;  

        }  
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
