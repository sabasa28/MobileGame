using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallsManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DropBall());
    }

    IEnumerator DropBall()
    {
        while(true)
        { 
            transform.GetChild(0).GetComponent<Ball>().Detach();
            yield return new WaitUntil(()=>transform.childCount > 0);
        }
    }
}
