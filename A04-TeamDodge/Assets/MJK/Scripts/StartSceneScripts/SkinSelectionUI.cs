using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelectionUI : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int skindid;
    // Start is called before the first frame update

    public void NextSkin()
    {
        skindid++;

        if (skindid > 2)
            skindid = 0;

        anim.SetInteger("Skinid", skindid);
    }

    public void PreviousSkin()
    {
        skindid--;

        if (skindid < 0)
            skindid = 2;
        anim.SetInteger("Skinid", skindid);
    }
}
