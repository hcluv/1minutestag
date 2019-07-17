using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
   
    [SerializeField] public GameObject Player;

    private NavMeshAgent navAgent = null;

    IEnumerator Start()
    {
        GetComponent<NavMeshAgent>().enabled = true;
        Player = GameObject.Find("Player"); 
        navAgent = GetComponent<NavMeshAgent>();

        enabled = false;
        yield return new WaitForSeconds(3); //三秒待ってUpdate()を有効化してキーそのものを受け付けない
        enabled = true;

    }



    private void Update()
    {

                
            navAgent.destination = Player.transform.position;//navMeshAgentの操作
        
        
    }

} // class ObjectController