using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
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
                LoadNextLevel();
            }
            break;
            default:
            {
                ReloadLevel(); 
            }
            break;
        }

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
