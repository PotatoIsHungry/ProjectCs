using System.Collections;
using UnityEngine;

public class awokeDialog : MonoBehaviour
{
    string lastScene = GameManager.lastSceneExited;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartDialog());
    }


    IEnumerator StartDialog()
    {

        if (!lastScene.Equals(""))
        {
            yield return new WaitForSeconds(1f);
            dialogueManager.Instance.StartDialogue(lastScene + "Lines");
        }
    }
}
