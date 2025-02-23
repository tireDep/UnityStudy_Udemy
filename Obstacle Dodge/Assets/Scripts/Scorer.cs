using UnityEngine;

public class Scorer : MonoBehaviour
{
    int HitCount = 0;
    private void OnCollisionEnter( Collision collision )
    {
        HitCount++;
        Debug.Log( "You've bumped into a thing this many times : " + HitCount );
    }
}
