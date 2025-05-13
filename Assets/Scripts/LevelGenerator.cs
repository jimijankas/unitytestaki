using System.Collections;
using UnityEngine;

public class GenerateLevels : MonoBehaviour
{
    public GameObject[] levels;
    public float zPos = 97f;
    public bool create = true;
    public int lvlnum;
    [SerializeField] private float destroyDelay = 30f;

    void Update()
    {
        if (create && levels != null && levels.Length > 0)
        {
            create = false;
            StartCoroutine(GenerateLevel());
        }
    }

    IEnumerator GenerateLevel()
    {
        lvlnum = Random.Range(0, levels.Length);
        GameObject newLevel = Instantiate(levels[lvlnum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 97f;
        StartCoroutine(DestroyLevelAfterDelay(newLevel, 60));
        yield return new WaitForSeconds(20f);
        create = true;
    }

    IEnumerator DestroyLevelAfterDelay(GameObject level, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (level != null) // Check if the level still exists
        {
            Destroy(level);
        }
    }
}
