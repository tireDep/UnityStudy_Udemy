using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        if( Keyboard.current.escapeKey.isPressed == true )
        {
            Debug.Log( "Escape Key Input!" );
            Application.Quit();
        }
    }
}
