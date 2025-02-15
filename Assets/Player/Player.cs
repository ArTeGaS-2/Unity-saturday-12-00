using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Швидкість")]
    public float forceMultiplier = 100f; // Множник швидкості
    public float maxSpeed = 10f; // Максимальна швидкість

    [Header("Налаштування камери")]
    public Camera mainCamera; // Посилання на головну камеру
    private float cameraDistance = 7; // Висота камери
    private float cameraOffset = 1; // Зсув

    private Rigidbody rb; // Фізичний компонент
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 moveInput = new Vector3( // Набір з 3 координат
            Input.GetAxis("Horizontal"), // X
            0,  // Y
            Input.GetAxis("Vertical")); // Z

        if (moveInput.magnitude > 0.1f)
        {
            rb.AddForce(                // Прискорення об'єкта
                moveInput.normalized * // Вектор руху
                forceMultiplier *     // Множник швидкості
                Time.deltaTime, ForceMode.Acceleration); // Узгодження і
                                                         // тип прискорення
            rb.velocity = Vector3.ClampMagnitude( // Обмеження швидкості
                rb.velocity, // Те що обмежуємо
                maxSpeed); // Те наскільки обмежуємо
        }
    }
}
