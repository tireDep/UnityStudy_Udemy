using System.Linq;
using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
    [SerializeField] GameObject[] Projectiles;

    void OnTriggerEnter( Collider other )
    {
        if( other.gameObject.tag == "Player" )
        {
            for( int index = 0; index < Projectiles.Length; index++ )
            {
                GameObject projectile = Projectiles[index];
                if( projectile == null )
                {
                    continue;
                }

                projectile.SetActive( true );
            }

            Destroy( gameObject );
        }
    }
}
