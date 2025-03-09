using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelayTime = 2.0f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isControllable = true;
    bool isCollidable = true;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        // if( Keyboard.current.lKey.isPressed == true )
        if( Keyboard.current.lKey.wasPressedThisFrame == true )
        {
            LoadNextLevel();
        }
        else if( Keyboard.current.cKey.wasPressedThisFrame == true )
        {
            isCollidable = !isCollidable;
            Debug.Log( "Collidable State : " + isCollidable );
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if( isControllable == false || isCollidable == false )
        {
            return;
        }

        switch ( collision.gameObject.tag )
        {
            case "Friendly":
            {
                Debug.Log( "Friendly" );
            }
            break;
            case "Fuel":
            {
                Debug.Log( "Fuel" );
            }
            break;
            case "Finish":
            {
                StartSuccessSequence();
            }
            break;
            default:
            {
                StartCrashSequence();
            }
            break;
        }

    }

    private void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot( successSFX );
        GetComponent<Movement>().enabled = false;
        successParticles.Play();
        Invoke( "LoadNextLevel", loadDelayTime );
    }

    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot( crashSFX );
        GetComponent<Movement>().enabled = false;
        crashParticles.Play();
        Invoke( "ReloadLevel", loadDelayTime );
    }

    void ReloadLevel()
    {
        // SceneManager.LoadScene( "Sandbox" );

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene( currentScene );
    }

    void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if( nextScene >= SceneManager.sceneCountInBuildSettings )
        {
            nextScene = 0;
        }

        SceneManager.LoadScene( nextScene );
    }

}
