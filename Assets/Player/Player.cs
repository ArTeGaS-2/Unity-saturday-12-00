using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("��������")]
    public float forceMultiplier = 100f; // ������� ��������
    public float maxSpeed = 10f; // ����������� ��������

    [Header("������������ ������")]
    public Camera mainCamera; // ��������� �� ������� ������
    private float cameraDistance = 7; // ������ ������
    private float cameraOffset = 1; // ����

    private Rigidbody rb; // Գ������ ���������
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 moveInput = new Vector3( // ���� � 3 ���������
            Input.GetAxis("Horizontal"), // X
            0,  // Y
            Input.GetAxis("Vertical")); // Z

        if (moveInput.magnitude > 0.1f)
        {
            rb.AddForce(                // ����������� ��'����
                moveInput.normalized * // ������ ����
                forceMultiplier *     // ������� ��������
                Time.deltaTime, ForceMode.Acceleration); // ���������� �
                                                         // ��� �����������
            rb.velocity = Vector3.ClampMagnitude( // ��������� ��������
                rb.velocity, // �� �� ��������
                maxSpeed); // �� �������� ��������
        }
    }
}
