using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Cooldown
{
    public IEnumerator CoroutineCooldown(float seconds, Action<bool> isCooldown)
    {
        //Debug.Log("Cooldown start");
        //isCooldown = true;
        isCooldown(true);

        yield return new WaitForSeconds(seconds);

        //Debug.Log(seconds+" seconds");
        //isCooldown = false;
        isCooldown(false);
    }

}

