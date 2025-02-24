using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter( Collision other ) 
    {
        if( other.gameObject.tag == "Player" && this.gameObject.tag != "Hit" )
        {
            GetComponent<MeshRenderer>().material.color = Color.gray;
            this.gameObject.tag = "Hit";
        }
    }
}
