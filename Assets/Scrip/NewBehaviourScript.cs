using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    MeshRenderer Mesh;
   private void OnCollisionEnter(Collision other)
    {
      if(other.gameObject.tag == "Player")
         {
            Mesh= GetComponent<MeshRenderer>();
            Mesh.material.color= Color.red;
           

         } else if  (other.gameObject.tag =="Player") 
         {
            other.gameObject.tag = "Player_lose";
         }
   }
}
