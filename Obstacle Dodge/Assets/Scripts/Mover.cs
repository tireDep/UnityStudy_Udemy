using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 1.0f;

    void Start()
    {

    }

    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        float yValue = 0.0f;
        float zValue = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
    
        transform.Translate( xValue, yValue, zValue );
    }
}
