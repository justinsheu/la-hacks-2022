using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkModeController : MonoBehaviour
{
    public Sprite currentSprite;
    public bool darkMode;
    public float timeElapsed;
    public float temp_stepsTaken;
    public int newNumSteps;
    public int newUpwardSteps;
    public float newSpeed;
    public float newJumpHeight;
    // Start is called before the first frame update
    void Awake()
    {
        temp_stepsTaken = 0;
        timeElapsed = 0;
        DontDestroyOnLoad(this.gameObject);
        darkMode = false;
        GameObject.Find("Character").GetComponent<LegThicknessController>().currentSprite = GameObject.Find("Character").GetComponent<LegThicknessController>().originalSprite;
        GameObject.Find("Character").GetComponent<LegThicknessController>().spriteRenderer.sprite = GameObject.Find("Character").GetComponent<LegThicknessController>().currentSprite;

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if ((int)(timeElapsed / 10) % 10 == 1)
        {
            temp_stepsTaken += Time.deltaTime;
        }
    }
}
