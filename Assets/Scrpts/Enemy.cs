using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyVFX;
    [SerializeField] Transform parent;
        void OnParticleCollision(GameObject other) {
            GameObject vfx = Instantiate(enemyVFX, transform.position,Quaternion.identity);
            vfx.transform.parent=parent;
            Destroy(gameObject);    
        }
}
