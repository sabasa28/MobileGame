using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] string ballTag = "";
    public float strength = 0;
    Quaternion origRot;
    float hor;
    public float rotationSpeed;
    [SerializeField] float maxRot = 55.0f;
    Animator animator; 
    
    AudioSource sound;
    
    private void Start()
    {
        origRot = transform.rotation;
        sound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.rotation = ConstrainRotation(Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, hor * Time.deltaTime * rotationSpeed)));
    }

    public void RotatePlatform(float movement)
    {
        hor = movement;
    }

    public void ResetRotation()
    {
        transform.rotation = origRot;
    }

    Quaternion ConstrainRotation(Quaternion notClampedRot)
    {
        float clampedRot = notClampedRot.eulerAngles.z;
        if (clampedRot > maxRot && clampedRot < 360 - maxRot)
        {
            if (clampedRot < 180)
            {
                clampedRot = maxRot;
            }
            else
            {
                clampedRot = 360 - maxRot;
            }
        }
        return Quaternion.Euler(new Vector3(0,0,clampedRot));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ballTag))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(transform.up * strength);
            StartCoroutine(Bounce());    
        }
    }

    IEnumerator Bounce()
    {
        animator.SetBool("Bouncing",true);
        Handheld.Vibrate();
        sound.Play();
        yield return new WaitForSeconds(1);
        animator.SetBool("Bouncing", false);
    }
}
