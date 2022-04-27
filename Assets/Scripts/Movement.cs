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

    private Rigidbody rb;
    private AudioSource audioSource;
    private ParticleSystem particleSystem;
    
    
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
            StartThrust();
        }
        else
        {
            StopThrust();
        }
    }
    private void StartThrust()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainAudioEngine);
        }

        if (!thrustParticle.isPlaying)
        {
            thrustParticle.Play();
        }

        rb.AddRelativeForce(Vector3.up * (thrustPower * Time.deltaTime));
    }
    
    private void StopThrust()
    {
        audioSource.Stop();
        thrustParticle.Stop();
    }
    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateToRight();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateToLeft();
        }
        else
        {
            StopRotating();
        }
    }

    private void RotateToRight()
    {
        ApplyRotation(rotationPower);
        if (!rightThrustParticle.isPlaying)
        {
            rightThrustParticle.Play();
        }
    }
    private void RotateToLeft()
    {
        ApplyRotation(-rotationPower);
        if (!leftThrustParticle.isPlaying)
        {
            leftThrustParticle.Play();
        }
    }
    
    private void StopRotating()
    {
        leftThrustParticle.Stop();
        rightThrustParticle.Stop();
    }
    
    private void ApplyRotation(float rotationFrame)
    {
        transform.Rotate(Vector3.forward * (rotationFrame * Time.deltaTime));
        rb.AddForce(Vector3.forward * (rotationFrame * Time.deltaTime));
    }
}
