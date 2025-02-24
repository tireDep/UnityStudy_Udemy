using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [SerializeField] float xRotate = 1.0f;
    [SerializeField] float yRotate = 1.0f;
    [SerializeField] float zRotate = 1.0f;
    
    void Update()
    {
        transform.Rotate( xRotate, yRotate, zRotate );
    }
}
