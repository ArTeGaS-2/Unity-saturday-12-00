using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [Header("��������")]
    public float forceMultiplier = 100f; // ������� ��������
    public float maxSpeed = 10f; // ����������� ��������

    [Header("������������ ������")]
    public Camera mainCamera; // ��������� �� ������� ������
    private float cameraDistance = 7; // ������ ������
    private float cameraOffset = 1; // ����
    public float cameraScaleMod = 0f; // ��������� ������� ������

    private Rigidbody rb; // Գ������ ���������

    public Vector3 scaleMod; // ����������� ������
    public Vector3 currentScale; // �������� �����
    public Vector3 baseStateScale; // ���� ��� ����������

    public float animTime = 20f; // �������� ���������� �������
    private float forwardScaleMod = 1.3f;
    private float sideScaleMod = 0.8f;

    public float divider = 2f; // ĳ������/�������
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Գ������ ���������

        baseStateScale = transform.localScale; // ��������� ������� ����

        currentScale = transform.localScale; // �������� ����� �� �������
        scaleMod = currentScale / divider; // ����������� ������
        forwardScaleMod = currentScale.z * 1.3f; // ������� ���������
        sideScaleMod = currentScale.x * 0.8f; // ������� ���������
    }
    public void AddCameraDistance()
    {
        cameraDistance += cameraScaleMod;
    }
    public void AddSize()
    {
        currentScale = currentScale + scaleMod;
        transform.localScale = currentScale;

        baseStateScale += scaleMod; // ������� ������� ���������

        //forwardScaleMod = currentScale.z * 1.3f; // ������� ���������
        //sideScaleMod = currentScale.x * 0.8f; // ������� ���������
    }


    private void Update()
    {
        Vector3 moveInput = new Vector3( // ���� � 3 ���������
            Input.GetAxis("Horizontal"), // X
            0,  // Y
            Input.GetAxis("Vertical")); // Z

        if (moveInput.magnitude > 0.1f)
        {
            // ���������
            Quaternion targetRotation = Quaternion.LookRotation(
                moveInput.normalized);
            transform.rotation = Quaternion.Slerp(
                transform.rotation, targetRotation, Time.deltaTime * 5f);

            // ���
            rb.AddForce(                // ����������� ��'����
                moveInput.normalized * // ������ ����
                forceMultiplier *     // ������� ��������
                Time.deltaTime, ForceMode.Acceleration); // ���������� �
                                                         // ��� �����������
            rb.velocity = Vector3.ClampMagnitude( // ��������� ��������
                rb.velocity, // �� �� ��������
                maxSpeed); // �� �������� ��������
        }
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            SlimeMoveAnim();
        }
        else
        {
            SlimeStopAnim();
        }
        mainCamera.transform.position = new Vector3(
            transform.position.x, // ��������� �� X
            transform.position.y + cameraDistance, // ������ � �����
            transform.position.z - cameraOffset); // ³���� �����
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MicroOrg"))
        {
            AddSize();
            AddCameraDistance();
        }
    }
    private void SlimeMoveAnim()
    {
        // ������� ����

        // ���� �������
        float forwardScale = Mathf.Lerp(transform.localScale.z,
            forwardScaleMod, Time.deltaTime * animTime);
        // ���� ������
        float sideScale = Mathf.Lerp(transform.localScale.x,
            sideScaleMod, Time.deltaTime * animTime);
        // ������������ ���
        currentScale = new Vector3(sideScale,
            currentScale.y, forwardScale);
    }
    private void SlimeStopAnim()
    {
        // ������� ����

        // ���� �������
        float forwardScale = Mathf.Lerp(transform.localScale.z,
           baseStateScale.z, (Time.deltaTime * animTime) / 2f);
        // ���� ������
        float sideScale = Mathf.Lerp(transform.localScale.x,
            baseStateScale.x, (Time.deltaTime * animTime) / 2f);
        // ������������ ���
        currentScale = new Vector3(sideScale,
            currentScale.y, forwardScale);
    }
}
