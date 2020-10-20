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
        Debug.LogError("Boss");
        Vector3 dir = target.transform.position - battery.transform.position;
        battery.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
    }

    public override void OnStart()
    {
        StartCoroutine(FireMissile());
        StartCoroutine(BatteryFire());
    }

    IEnumerator FireMissile()
    {
        yield return new WaitForSeconds(5f);
        ani.SetTrigger("Skill");
    }

    IEnumerator BatteryFire()
    {
        yield return new WaitForSeconds(5f);
        while(true)
        {
            GameObject go = Instantiate(bulletTemplate, battery.transform.position, battery.transform.rotation);
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.direction = (target.transform.position - go.transform.position).normalized;
            yield return new WaitForSeconds(1f);
        }
    }
}
