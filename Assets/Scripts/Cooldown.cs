using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CooldownNamespace
{
    class Cooldown
    {
        public IEnumerator CoroutineCooldown(float seconds, Action<bool> isCooldown)
        {
            isCooldown(true);

            yield return new WaitForSeconds(seconds);

            isCooldown(false);
        }

    }
}

