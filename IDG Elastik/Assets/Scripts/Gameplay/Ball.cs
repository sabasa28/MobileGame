using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float minPosY = -10;
    [SerializeField] Transform ballManager = null;
    [SerializeField] string CupTag = "";
    float timeBeforeDestroying = 10;
    float timeLoose = 0;
    Vector3 startPos;
    bool intoCup = false;

    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        timeLoose += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CupTag))
        {
            intoCup = true;  
        }
    }
    public void Detach()
    {
        gameObject.SetActive(true);
        transform.parent = null;
        StartCoroutine(ResetAfterTime());
    }
    IEnumerator ResetAfterTime()
    {
        yield return new WaitUntil(()=> timeLoose >= timeBeforeDestroying || transform.position.y < minPosY|| intoCup == true);
        if (!LevelManager.Get().CheckOnOutOfBalls())
            Attach();
    }
    public void Attach()
    {
        transform.position = startPos;
        timeLoose = 0;
        intoCup = false;
        transform.parent = ballManager;
        gameObject.SetActive(false);
    }
}
