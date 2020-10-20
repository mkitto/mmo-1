using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : Bullet {

    public Transform target;
    private bool running = false;

    public override void OnUpdate()
    {
        if (!running)
            return;

        if (target != null)
        {
            Vector3 dir = target.transform.position - this.transform.position;
            if(dir.magnitude < 0.1)
            {
                Explod();
            }
            this.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
            this.transform.position += speed * Time.deltaTime * dir.normalized;
        }
    }

    public void Launch()
    {
        running = true;
    }

    public void Explod()
    {
        Destroy(this.gameObject);
        // todo: Effect
        Player player = target.GetComponent<Player>();
        player.Damage(power);
    }
}
