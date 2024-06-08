using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject eggPrefab;
    public GameObject chickPrefab;
    public GameObject henPrefab;
    public GameObject roosterPrefab;
    public Counter counter;

    private Vector3 spawnPosition = new Vector3(0, 20f, 0);

    void Start()
    {
        StartCoroutine(SpawnEggWithDelay(0f));
    }

    public IEnumerator SpawnEggWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 eggSpawnPosition = spawnPosition;
        eggSpawnPosition.y += 0.5f;
        GameObject egg = Instantiate(eggPrefab, eggSpawnPosition, Quaternion.Euler(-90, 0, 0));
        egg.tag = "Egg";
        counter.eggCount++;
    }

    public void SpawnChick(Vector3 position)
    {
        GameObject chick = Instantiate(chickPrefab, position, Quaternion.Euler(-90, 0, 0));
        chick.tag = "Chick";
        counter.chickCount++;
    }

    public void SpawnHen(Vector3 position)
    {
        GameObject hen = Instantiate(henPrefab, position, Quaternion.Euler(-90, -150, 80));
        hen.tag = "Hen";
        counter.henCount++;
    }

    public void SpawnRooster(Vector3 position)
    {
        GameObject rooster = Instantiate(roosterPrefab, position, Quaternion.Euler(-90, 0, 0));
        rooster.tag = "Rooster";
        counter.roosterCount++;
    }
}
