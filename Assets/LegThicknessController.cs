using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegThicknessController : MonoBehaviour
{
    public const int THRESHOLD = 10;
    public SpriteRenderer spriteRenderer;
    public Sprite originalSprite;
    public Sprite newSprite;
    public Sprite currentSprite;
    // Start is called before the first frame update
    // void Awake()
    // {
    //     currentSprite = GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().currentSprite;
    //     spriteRenderer.sprite = currentSprite;
    // }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().currentSprite = currentSprite;
        if (GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().newNumSteps <= THRESHOLD)
        {
            transform.localScale = new Vector3(1f, 0.65f, 1) + new Vector3((30f / THRESHOLD) * (GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().newSpeed - 1), 0f, 0f);
        } else {
            transform.localScale = new Vector3(1f, 1f, 1) + new Vector3((30f / THRESHOLD) * (GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().newSpeed - (1 + THRESHOLD * 0.01f)), 0f, 0f);
        }
        if (GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().newNumSteps == THRESHOLD)
        {
            spriteRenderer.sprite = newSprite;
            transform.localScale = new Vector3(1f, 1f, 1f);
            currentSprite = newSprite;
        }
    }
}
