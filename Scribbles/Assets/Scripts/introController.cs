using UnityEngine;
using UnityEngine.SceneManagement;

public class introController : MonoBehaviour
{
     private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        animator=GetComponent<Animator>();
        StartCoroutine(PlayAndLoad());
    }

    System.Collections.IEnumerator PlayAndLoad()
    {
        animator.Play("intro");

        yield return new WaitForSeconds(
            animator.GetCurrentAnimatorStateInfo(0).length
        );

        SceneManager.LoadScene("menuScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
