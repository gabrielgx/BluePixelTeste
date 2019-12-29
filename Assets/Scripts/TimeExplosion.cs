using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeExplosion : MonoBehaviour
{
    public float time;
    IEnumerator destroyExplosao()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
    void Update()
    {
        StartCoroutine(destroyExplosao());
    }
}
