using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChainSystem : MonoBehaviour
{
    [SerializeField] private int jumpCount = 0;
    [SerializeField] List<Enemy> allEnemies = new List<Enemy>();
    [SerializeField] Enemy closestEnemy = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (!allEnemies.Contains(enemy))
            {
                allEnemies.Add(other.gameObject.GetComponent<Enemy>());

                float distanceToClosestEnemy = Mathf.Infinity;
                foreach (Enemy currentEnemy in allEnemies)
                {
                    float distanceToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;
                    if (distanceToEnemy < distanceToClosestEnemy)
                    {
                        distanceToClosestEnemy = distanceToEnemy;
                        closestEnemy = currentEnemy;
                    }
                }

                if (allEnemies.Count > 0 && jumpCount > 0)
                {
                    transform.DOMove(closestEnemy.transform.position, 0.2F).OnComplete(() =>
                    {
                        allEnemies.Remove(closestEnemy);
                        Destroy(closestEnemy.gameObject);
                        jumpCount--;
                    });
                }

                if (jumpCount <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
