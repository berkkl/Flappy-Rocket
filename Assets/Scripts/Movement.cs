using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustPower = 888f;
    [SerializeField] float rotationPower = 100f;

    [SerializeField] AudioClip mainAudioEngine;

    [SerializeField] ParticleSystem thrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;
    [SerializeField] ParticleSystem leftThrustParticle;

    Rigidbody rb;
    AudioSource audioSource;
    ParticleSystem particleSystem;
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();   
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
            thrustParticle.Play();
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainAudioEngine);
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
            rightThrustParticle.Play();
            applyRotation(rotationPower);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            leftThrustParticle.Play();
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
