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

        }
    }


}
