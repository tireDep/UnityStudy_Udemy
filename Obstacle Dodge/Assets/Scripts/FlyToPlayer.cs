using Unity.VisualScripting;
using UnityEngine;

public class FlyToPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float masDistanceDelta = 1.0f;

    Vector3 playerPosition;

    void Start()
    {
        playerPosition = playerTransform.transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards( transform.position, playerPosition, masDistanceDelta * Time.deltaTime );
    }
}
