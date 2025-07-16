using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider bx;
    bool disableRotation;
    public float destroyTime = 4f;
    AudioSource arrowAudio;
  [SerializeField]  AudioClip targethittingsound;
    public float bullseyeRadius = 0.2f;
    public float middleRadius = 0.5f;
    public float outerRadius = 0.7f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();
        arrowAudio = GetComponent<AudioSource>();

        Destroy(this.gameObject, destroyTime);
    }

    void Update()
    {
        if (!disableRotation)
            transform.rotation = Quaternion.LookRotation(rb.linearVelocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            arrowAudio.Play();
            disableRotation = true;
            rb.isKinematic = true;
            bx.isTrigger = true;
            if (collision.gameObject.CompareTag("target"))
            {
                arrowAudio.PlayOneShot(targethittingsound);
                Vector3 hitPoint = collision.contacts[0].point;
                Vector3 targetCenter = collision.transform.position;

                float distanceToCenter = Vector3.Distance(hitPoint, targetCenter);

                Debug.Log(distanceToCenter);
             
                if (distanceToCenter <= bullseyeRadius)
                {
                    Debug.Log("🎯 Bullseye Hit!");
                    ScoreScript.Instance.AddScore(10);
                    Destroy(collision.gameObject, 1f);
                }
                else if (distanceToCenter <= middleRadius)
                {
                    Debug.Log("✅ Middle Ring Hit");
                    ScoreScript.Instance.AddScore(7);
                    Destroy(collision.gameObject, 1f);
                }
                else if (distanceToCenter <= outerRadius)
                {
                    Debug.Log("⚠️ Outer Ring Hit");
                    ScoreScript.Instance.AddScore(5);
                    Destroy(collision.gameObject, 1f);
                }
                else
                {
                    Debug.Log("❌ Missed the Target");
                    // No score for a miss
                }



                // You can add score or visual effects here based on the zone
            }


            if (collision.gameObject.CompareTag("targetAnimal"))
            {

                arrowAudio.PlayOneShot(targethittingsound);
                ScoreScript.Instance.AddScore(5);
                Destroy(collision.gameObject, 1f);

            }
            if (collision.gameObject.CompareTag("targetAnimalMoving"))
            {


                arrowAudio.PlayOneShot(targethittingsound);
                ScoreScript.Instance.AddScore(8);
                Destroy(collision.gameObject, 1f);
            }

        }


    }

}
