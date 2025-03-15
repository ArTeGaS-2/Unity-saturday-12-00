using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [Header("Швидкість")]
    public float forceMultiplier = 100f; // Множник швидкості
    public float maxSpeed = 10f; // Максимальна швидкість

    [Header("Налаштування камери")]
    public Camera mainCamera; // Посилання на головну камеру
    private float cameraDistance = 7; // Висота камери
    private float cameraOffset = 1; // Зсув
    public float cameraScaleMod = 0f; // Додаткова відстань камери

    private Rigidbody rb; // Фізичний компонент

    public Vector3 scaleMod; // Модифікатор розміру
    public Vector3 currentScale; // Поточний розмір

    public float divider = 2f; // Ділитель/Множник
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Фізичний компонент

        currentScale = transform.localScale; // Поточний розмір на початку
        scaleMod = transform.localScale / divider; // Модифікатор розміру
    }
    public void AddCameraDistance()
    {
        cameraDistance += cameraScaleMod;
    }
    public void AddSize()
    {
        currentScale = currentScale + scaleMod;
        transform.localScale = currentScale;
    }
    private void Update()
    {
        Vector3 moveInput = new Vector3( // Набір з 3 координат
            Input.GetAxis("Horizontal"), // X
            0,  // Y
            Input.GetAxis("Vertical")); // Z

        if (moveInput.magnitude > 0.1f)
        {
            // Обертання
            Quaternion targetRotation = Quaternion.LookRotation(
                moveInput.normalized);
            transform.rotation = Quaternion.Slerp(
                transform.rotation, targetRotation, Time.deltaTime * 5f);

            // Рух
            rb.AddForce(                // Прискорення об'єкта
                moveInput.normalized * // Вектор руху
                forceMultiplier *     // Множник швидкості
                Time.deltaTime, ForceMode.Acceleration); // Узгодження і
                                                         // тип прискорення
            rb.velocity = Vector3.ClampMagnitude( // Обмеження швидкості
                rb.velocity, // Те що обмежуємо
                maxSpeed); // Те наскільки обмежуємо
        }
        mainCamera.transform.position = new Vector3(
            transform.position.x, // Положення по X
            transform.position.y + cameraDistance, // Висота з модом
            transform.position.z - cameraOffset); // Віступ назад
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MicroOrg"))
        {
            AddSize();
            AddCameraDistance();
        }
    }
}
