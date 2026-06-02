using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowerChange : MonoBehaviour
{
    public SpriteRenderer flower;
    public Sprite flower2;
    public Sprite flower3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.lastSceneExited == "level2")
        {
            ChangeFlower(flower2);
        }
        else if (GameManager.lastSceneExited == "level3")
        {
            ChangeFlower(flower3);
        }
    }

    private void ChangeFlower(Sprite newSprite)
    {
        float targetHeight = flower.sprite.bounds.size.y * flower.transform.localScale.y;

        flower.sprite = newSprite;

        float spriteHeight = flower.sprite.bounds.size.y;

        float scaleFactor = targetHeight / spriteHeight;

        flower.transform.localScale = new Vector3(
            scaleFactor,
            scaleFactor,
            1f
        );

    }
}
