using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform AttackPoint;
    // Start is called before the first frame update
    public GameObject PoisonPrefab;
    private float nextTime = 0.0f;
    private float TimeLeft = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            Shoot();
        }
    }
    void Shoot() {
        Instantiate(PoisonPrefab, AttackPoint.position, AttackPoint.rotation);
    }
}
