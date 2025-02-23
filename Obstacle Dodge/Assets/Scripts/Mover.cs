using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 1.0f;

    void Start()
    {
         PrintInstruction();
    }

    void Update()
    {
        MovePlayer();
    }

    void PrintInstruction()
    {
        Debug.Log( "Welcome to the game!" );
        Debug.Log( "Move using arrow keys or wasd" );
        Debug.Log( "Don't bump into objects!" );
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        float yValue = 0.0f;
        float zValue = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
    
        transform.Translate( xValue, yValue, zValue );
    }
}
