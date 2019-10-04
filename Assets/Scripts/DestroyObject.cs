using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //once the explosion spawns, it'll self destroy in 2 seconds
    private void Start()
    {
        Destroy(this.gameObject, 2f);
    }
}