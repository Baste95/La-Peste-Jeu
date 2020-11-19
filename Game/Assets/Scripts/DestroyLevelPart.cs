using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevelPart : MonoBehaviour
{
    // Start is called before the first frame update
    private float secondsToDestroy = 40f;
    void Start()
    {
        Destroy(this.gameObject, secondsToDestroy);

    }
}
