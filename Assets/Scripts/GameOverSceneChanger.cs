using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneChanger : MonoBehaviour
{
    GameObject player;
   
    private ParticleSystem particle;
    Exploder Exploder;

    void Start()
    {
       
        particle = GetComponent<ParticleSystem>();
        Exploder = player.GetComponent<Exploder>();
    }
    // Use this for initialization
    IEnumerator OnControllerColliderHit (ControllerColliderHit other)
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("Enemy"))
        {
           
            yield return new WaitForSeconds(0.3f); //キーそのものを受け付けない
            SceneManager.LoadScene("GameOver");
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            
           
            yield return new WaitForSeconds(0.01f); //キーそのものを受け付けない
            SceneManager.LoadScene("GameOver");
        }
    }
}