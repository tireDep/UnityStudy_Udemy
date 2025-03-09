using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Parameters = for tuning, typically set int the editor
    // Cache - eg. references for readability or speed
    // State - private instances (member) variables

    [SerializeField] InputAction thrust;
    [SerializeField] float thrustStrength = 10.0f;
    [SerializeField] InputAction rotation;
    [SerializeField] float rotationStrength = 10.0f;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] ParticleSystem mainBoosterParticles;
    [SerializeField] ParticleSystem LeftBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;

    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);

        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(mainEngineSFX);
        }

        if (mainBoosterParticles.isPlaying == false)
        {
            mainBoosterParticles.Play();
        }
    }
        void StopThrusting()
    {
        audioSource.Stop();
        mainBoosterParticles.Stop();
    }

    private void ProcessRotation()
    {
        if( rotation.IsPressed() == false )
        {
            rightBoosterParticles.Stop();
            LeftBoosterParticles.Stop();
            return;
        }

        float rotationInput = rotation.ReadValue<float>();
        if( rotationInput < 0.0f )
        {
            RotateRight();
        }
        else
        {
            RotateLeft();
        }
    }

    void RotateRight()
    {
        ApplyRotation(rotationStrength);

        if (LeftBoosterParticles.isPlaying == false)
        {
            rightBoosterParticles.Stop();
            LeftBoosterParticles.Play();
        }
    }
    void RotateLeft()
    {
        ApplyRotation(-rotationStrength);

        if (rightBoosterParticles.isPlaying == false)
        {
            LeftBoosterParticles.Stop();
            rightBoosterParticles.Play();
        }
    }

    private void ApplyRotation( float rotationThisFrame )
    {
        rb.freezeRotation = true;
        transform.Rotate( Vector3.forward * rotationThisFrame * Time.fixedDeltaTime );
        rb.freezeRotation = false;
    }
}
