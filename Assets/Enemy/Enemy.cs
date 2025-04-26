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
            // Знаходимо персонажа гравця по назві і отримуємо позицію
            target = GameObject.Find(
                "Player").GetComponent<Transform>();
        }
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        // Перевіряє, чи була визначена/знайдена ціль (гравець)
        if (target != null)
        {
            // Встанвлює ціль для об'єкта агента
            agent.SetDestination(target.position);
        }
    }
    IEnumerator StopMoving()
    {
        // Зупиняє ворога
        agent.isStopped = true;
        // Очікує 3 секунди
        yield return new WaitForSeconds(3f);
        // Повертає рух ворогу
        agent.isStopped = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0); 
        }
    }
}
