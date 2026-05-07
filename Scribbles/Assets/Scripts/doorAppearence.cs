using UnityEngine;

public class doorAppearence : MonoBehaviour
{
     public GameObject objectToEnable;
     GameObject taggedObject;
     Animator anim;

    void Start()
    {
        anim = objectToEnable.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        taggedObject = GameObject.FindGameObjectWithTag("Enemy");

         if (taggedObject == null)
        {
            objectToEnable.SetActive(true);
            anim.Play("doorAppearenceState");
        }
    }
}
