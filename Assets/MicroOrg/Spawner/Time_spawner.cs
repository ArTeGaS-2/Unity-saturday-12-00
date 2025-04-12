using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_spawner : MonoBehaviour
{
    public List<GameObject> prefabs; // ������� ��'����

    public float diametr = 5f; // ĳ����� ������ �� ������
    public float delay = 1f; // �������� �� �������

    private float x_Pos; // ��������� ��� ���������� X
    private float z_Pos; // ��������� ��� ���������� Z
    private void Start()
    {
        StartCoroutine(spawnCreature());
    }
    private IEnumerator spawnCreature()
    {
        while (true)
        {
            x_Pos = Random.Range(-diametr, diametr);
            z_Pos = Random.Range(-diametr, diametr);

            GameObject objectToSpawn = prefabs[
                Random.Range(0, prefabs.Count - 1)];

            Vector3 spawnPosition = new Vector3(
                x_Pos,
                objectToSpawn.transform.position.y,
                z_Pos);

            Instantiate(objectToSpawn, spawnPosition,
                objectToSpawn.transform.rotation);

            yield return new WaitForSeconds(delay);
        }
    }
}
