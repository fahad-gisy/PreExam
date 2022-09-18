using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 0.3f;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
