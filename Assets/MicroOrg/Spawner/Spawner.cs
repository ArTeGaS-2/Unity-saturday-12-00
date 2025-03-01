using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs; // ������� ��'����

    public int spawnNumber = 10; // ʳ������ ��'����

    public float diametr = 5f; // ���� ������

    private float x_Pos;
    private float z_Pos;
    private void Start()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            // �������� ����� �� "x" �� "z"
            x_Pos = Random.Range(-diametr, diametr);
            z_Pos = Random.Range(-diametr, diametr);
            // ���������� ������, � ������ "prefabs"
            GameObject objectToSpawn = prefabs[
                Random.Range(0, prefabs.Count -1)];
            // ����� ������ � ������ ������ Vector3(x,y,z)
            Vector3 spawnPosition = new Vector3(
                x_Pos,
                objectToSpawn.transform.position.y,
                z_Pos);
            // ����� ��'���� (��'���, ����� ������, ���������)
            Instantiate(
                objectToSpawn,
                spawnPosition,
                objectToSpawn.transform.rotation);
        }
    }


}
