using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Шаблон снаряду
    public float speed = 10f; // Швидкість снаряду
    public Transform spawnPoint; // Точка створення снаряду
    public void ShootProjectileForward()
    {
        // Напрямок руху проджектайлу - напрямок руху гравця
        Vector3 direction = transform.forward;
        // Обертання у напямку погляду персонажа
        Quaternion projectileRotation =
            Quaternion.LookRotation(direction);
        // Створення на сцені з заданими параметрами
        GameObject projectile = Instantiate(
            projectilePrefab, 
            spawnPoint.position,
            projectileRotation);
        // Фізичний компонент
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * speed; // Прискорення
        }
        Destroy(projectile, 10f); // Знищення з затримкою в 10 сек
    }
}
