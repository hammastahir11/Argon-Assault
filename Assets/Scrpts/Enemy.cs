using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit=10;


    ScoreBoard scoreBoard; 
    void Start() {
        scoreBoard= FindObjectOfType<ScoreBoard>();
    }
        void OnParticleCollision(GameObject other) {
            scoreBoard.IncreaseScore(scorePerHit);
            GameObject vfx = Instantiate(enemyVFX, transform.position,Quaternion.identity);
            vfx.transform.parent=parent;
            Destroy(gameObject);    
        }
}
