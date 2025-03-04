using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    Rigidbody rb;
    [SerializeField] float thrustStrength = 10.0f;

    [SerializeField] InputAction rotation;
    [SerializeField] float rotationStrength = 10.0f;

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

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce( Vector3.up * thrustStrength * Time.fixedDeltaTime );

            if( audioSource.isPlaying == false )
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void ProcessRotation()
    {
        if( rotation.IsPressed() == false )
        {
            return;
        }

        float rotationInput = rotation.ReadValue<float>();
        if( rotationInput < 0.0f )
        {
            ApplyRotation( rotationStrength );
        }
        else
        {
            ApplyRotation( -rotationStrength );
        }
    }

    private void ApplyRotation( float rotationThisFrame )
    {
        rb.freezeRotation = true;
        transform.Rotate( Vector3.forward * rotationThisFrame * Time.fixedDeltaTime );
        rb.freezeRotation = false;
    }
}
