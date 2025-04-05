using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroOrg : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Score.Instance.UpdateScore();
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Score.Instance.UpdateScore();
        Destroy(gameObject);
    }
}
