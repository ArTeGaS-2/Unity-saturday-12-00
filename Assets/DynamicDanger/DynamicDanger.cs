using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Час до наступного обертання
    public float objectSpeed = 5f; // Швидкість руху

    private Rigidbody rb; // Фізичний компонент

    public float anglePerIteration = 90f; // Кут за обертання
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Перевірка тега
        {
            SceneManager.LoadScene(0); // (пере)завантаження сцени
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Доступ до фізики
        StartCoroutine(RotateDynamicDanger());
    }
    private void Update()
    {
        Vector3 forward = transform.up;
        rb.velocity = forward * objectSpeed * Time.deltaTime;
    }
    private IEnumerator RotateDynamicDanger()
    {
        while(true)
        {
            yield return new WaitForSeconds(needToGo);
            Vector3 currentEulerAngle = transform.rotation.eulerAngles;
            currentEulerAngle.y += anglePerIteration;
            transform.rotation = Quaternion.Euler(currentEulerAngle);
        }
    }
}
