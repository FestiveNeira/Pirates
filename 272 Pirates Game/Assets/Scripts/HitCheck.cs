using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public bool Check() {
        if (this.gameObject.transform.parent.gameObject.GetComponent<HealthPlayer>().immunitytimer <= 0 && this.gameObject.transform.parent.parent.gameObject.GetComponent<jump>().onGround) {
            return true;
        }
        return false;
    }
}
