using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {
    public GameObject missleTemplate;
    public Transform firePoint2;
    public Transform firePoint3;

    public Transform battery;
    public Unit target;

    public float fireRate2 = 10;
    float fireTimer2 = 0.0f;

    public float UltCD = 5.0f;
    float fireTimer3 = 0.0f;

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
        if (target)
        {
            Vector3 dir = target.transform.position - battery.transform.position;
            battery.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
        }
    }

    public override void OnStart()
    {
        StartCoroutine(Enter());
    }

    IEnumerator Enter()
    {
        this.transform.position = new Vector3(15, 0, 0);
        yield return MoveTo(new Vector3(5, 0, 0));
        ani.SetTrigger("Fly");
        yield return Attack();
    }

    IEnumerator MoveTo(Vector3 pos)
    {
        while (true)
        {
            Vector3 dir = (pos - this.transform.position);
            if(dir.magnitude < 0.1)
            {
                break;
            }
            this.transform.position += dir.normalized * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Attack()
    {
        while(true)
        {
            fireTimer2 += Time.deltaTime;
            Fire();
            BatteryFire();
            fireTimer3 += Time.deltaTime;
            if (fireTimer3 > UltCD)
            {
                yield return UltraAttack();
                fireTimer3 = 0.0f;
            }

            yield return null;
        }
    }
    
    IEnumerator UltraAttack()
    {
        yield return MoveTo(new Vector3(5, 5, 0));
        yield return FireMissile();
        yield return MoveTo(new Vector3(5, 0, 0));
    }

    IEnumerator FireMissile()
    {
        ani.SetTrigger("Skill");
        yield return new WaitForSeconds(3f);
    }

    void BatteryFire()
    {
        if (fireTimer2 > 1.0 / fireRate2)
        {
            GameObject go = Instantiate(bulletTemplate, battery.transform.position, battery.transform.rotation);
            Bullet bullet = go.GetComponent<Bullet>();
            if (target)
                bullet.direction = (target.transform.position - go.transform.position).normalized;
            fireTimer2 = 0.0f;
        }
    }
}
