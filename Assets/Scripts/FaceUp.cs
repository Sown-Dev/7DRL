using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceUp : MonoBehaviour
{
    
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector2.up);
    }
}
