using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Lifecycle : MonoBehaviour
{
    public Counter counter; // Make sure to assign this in the Inspector

    private static bool firstChickMatured = false;
    private GameManager gameManager;

    private void Start()
    {
        if (counter == null)
        {
            counter = FindObjectOfType<Counter>();
        }

        gameManager = FindObjectOfType<GameManager>();

        switch (gameObject.tag)
        {
            case "Egg":
                StartCoroutine(HatchEgg());
                break;
            case "Chick":
                StartCoroutine(MatureChick());
                break;
            case "Hen":
                StartCoroutine(LayEggsAndDie());
                break;
            case "Catto":
                StartCoroutine(PerishCatto());
                break;
        }
    }

    private IEnumerator HatchEgg()
    {
        float hatchTime = 10f;
        yield return new WaitForSeconds(hatchTime);

        counter.eggCount--;
        gameManager.SpawnChick(transform.position + Vector3.up * 0.5f);
        Debug.Log("The great eggscape!");
        Destroy(gameObject);
    }

    private IEnumerator MatureChick()
    {
        float matureTime = 10f;
        yield return new WaitForSeconds(matureTime);

        counter.chickCount--;

        if (!firstChickMatured)
        {
            firstChickMatured = true;
            gameManager.SpawnHen(transform.position + Vector3.up * 0.5f);
            Debug.Log("Ding! Leveled up to a clucking boss lady hen!");
        }
        else
        {
            if (Random.value > 0.5f)
            {
                gameManager.SpawnHen(transform.position + Vector3.up * 0.5f);
                Debug.Log("From peep to hen-sation!");
            }
            else
            {
                gameManager.SpawnCatto(transform.position + Vector3.up * 0.5f);
                Debug.Log("The cluck who struck gold and became a catto.");
            }
        }
        Destroy(gameObject);
    }

    private IEnumerator LayEggsAndDie()
    {
        float layEggsTime = 30f;
        yield return new WaitForSeconds(layEggsTime);

        int numberOfEggs = Random.Range(2, 11);
        for (int i = 0; i < numberOfEggs; i++)
        {
            StartCoroutine(gameManager.SpawnEggWithDelay(i * 0.5f));
            Debug.Log("Hatched a plan and dropped an egg!");
        }

        float perishTime = 10f; // Remaining time to perish after laying eggs
        yield return new WaitForSeconds(perishTime);

        counter.henCount--;
        Debug.Log("Off to coop heaven, where the worms are endless!");
        Destroy(gameObject);
    }

    private IEnumerator PerishCatto()
    {
        float perishTime = 40f;
        yield return new WaitForSeconds(perishTime);

        counter.cattoCount--;
        Debug.Log("Catto has run out of lives.");
        Destroy(gameObject);
    }
}
