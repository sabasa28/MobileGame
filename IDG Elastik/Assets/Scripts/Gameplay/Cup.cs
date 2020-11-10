using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cup : MonoBehaviour
{
    [SerializeField] string BallTag = "";
    [SerializeField] int scoreToAdd = 0;
    public Action<int> AddToScore;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(BallTag))
        {
            AddToScore(scoreToAdd);
        }
    }
}
