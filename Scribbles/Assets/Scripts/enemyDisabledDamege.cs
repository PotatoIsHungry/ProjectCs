using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;

public class enemyDisabledDamege : MonoBehaviour
{
    private SpriteRenderer sr;
    Material mat;
    public bool isDisabled = false;
    private bool changedTracker = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        mat = sr.material;
    }

    void Update()
    {

        if (isDisabled != changedTracker)
        {
            if (isDisabled)
            {
                mat.SetFloat("_FlashAmount", 1f);
                mat.SetFloat("_GrayAmount", 1f);
            }
            else
            {
                mat.SetFloat("_FlashAmount", 0f);
                mat.SetFloat("_GrayAmount", 0f);
            }

            changedTracker = !changedTracker;
        }




    }
}
