using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occillator : MonoBehaviour
{
    Vector3 Startpossion;
    [SerializeField] Vector3 MovementVector;
    float Movementfactor;
    [SerializeField][Range(0,2)] float  period= 2f;

    void Start()
    {
      Startpossion = transform.position;   
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;  // continually growing over time
        
        const float tau = Mathf.PI * 2;  // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau);  // going from -1 to 1

        Movementfactor = (rawSinWave + 1f) / 2f;   // recalculated to go from 0 to 1 so its cleaner
        
        Vector3 offset = MovementVector * Movementfactor;
        transform.position = Startpossion + offset;

    }
}
