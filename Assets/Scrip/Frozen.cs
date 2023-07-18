using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frozen : MonoBehaviour
{
    MeshRenderer Mesh;
      private void OnCollisionEnter(Collision other)
    {
     if (other.gameObject.tag=="Finish")
        {
            
          GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezePositionX;
          
          GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezePositionY;
          GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezePositionZ;
          
        }
}
}