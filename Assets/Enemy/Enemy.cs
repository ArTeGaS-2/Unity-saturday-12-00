using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Transform target; // Положення цілі ворога (Гравець)
    private NavMeshAgent agent; // Компонент агента (Ворог)
    private void Start()
    {
        if (GameObject.Find("Player"))
        {
            target = GameObject.Find(
                "Player").GetComponent<Transform>();
        }
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        
    }
}
