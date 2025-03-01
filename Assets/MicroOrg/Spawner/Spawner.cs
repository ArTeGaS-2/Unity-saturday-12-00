using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs; // Шаблони об'єктів

    public int spawnNumber = 10; // Кількість об'єктів

    public float diametr = 5f; // Зона спавну

    private float x_Pos;
    private float z_Pos;
    private void Start()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            // Випадкові точки по "x" та "z"
            x_Pos = Random.Range(-diametr, diametr);
            z_Pos = Random.Range(-diametr, diametr);
            // Випадковий шаблон, зі списку "prefabs"
            GameObject objectToSpawn = prefabs[
                Random.Range(0, prefabs.Count -1)];
            // Точка спавну у вигляді набору Vector3(x,y,z)
            Vector3 spawnPosition = new Vector3(
                x_Pos,
                objectToSpawn.transform.position.y,
                z_Pos);
            // Спавн об'єкту (об'єкт, точка спавну, обертання)
            Instantiate(
                objectToSpawn,
                spawnPosition,
                objectToSpawn.transform.rotation);
        }
    }


}
