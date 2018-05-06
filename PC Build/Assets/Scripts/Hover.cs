using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    public AudioSource HoverSound;

    public void mouseEnter(GameObject WhatObject)
    {
        HoverSound.Play();
        StartCoroutine(HoverEffect(WhatObject));
    }

    IEnumerator HoverEffect(GameObject WhatObject)
    {
        WhatObject.transform.localScale = new Vector3(-1, -1, 0);
        yield return new WaitForSeconds(0.04F);
        WhatObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
