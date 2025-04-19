using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroOrg : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Score.Instance.UpdateScore();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Score.Instance.UpdateScore();
            Destroy(gameObject);
        }
    }
}
