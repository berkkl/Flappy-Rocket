using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustPower = 888f;
    [SerializeField] float rotationPower = 100f;
    Rigidbody rb;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play(1000);
            }
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime); 
        }
        else
        {
            audioSource.Stop();
        }
    }
    
    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            applyRotation(rotationPower);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            applyRotation(-rotationPower);
        }   
    }
        void applyRotation(float rotationFrame)
    {
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        rb.AddForce(Vector3.forward * rotationFrame * Time.deltaTime);
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
