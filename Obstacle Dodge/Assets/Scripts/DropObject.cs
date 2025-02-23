using UnityEngine;

public class DropObject : MonoBehaviour
{
    [SerializeField] float dropTime = 3.0f;

    MeshRenderer    myMeshRenderer;
    Rigidbody       myRigidbody;

    void Start()
    {
        // // No cashing
        // GetComponent<MeshRenderer>().enabled = false;
        // GetComponent<Rigidbody>().useGravity = false;

        // cashing
        myMeshRenderer  = GetComponent<MeshRenderer>();
        myMeshRenderer.enabled = false;

        myRigidbody     = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;
    }

    void Update()
    {
        if( Time.time >=  dropTime &&myMeshRenderer.enabled == false )
        {
            myMeshRenderer.enabled = true;
            myRigidbody.useGravity = true;
        }
    }
}
