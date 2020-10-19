using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {

    public GameObject missleTemplate;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;

    public Transform battery;
    public Unit target;

    Missle missle = null;
    public void OnMissleLoad()
    {
        GameObject go = Instantiate(missleTemplate, firePoint3);
        missle = go.GetComponent<Missle>();
        missle.target = target.transform;
    }

    public void OnMisslelaunch()
    {
        if (!missle)
            return;
        missle.transform.SetParent(null);
        missle.Launch();
    }

    public override void OnUpdate()
    {
    }

    public override void OnStart()
    {
        StartCoroutine(FireMissile());
    }

    IEnumerator FireMissile()
    {
        yield return new WaitForSeconds(5f);
        ani.SetTrigger("Skill");
    }
}
