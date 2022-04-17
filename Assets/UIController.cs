using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public bool darkMode;
    public UnityEngine.UIElements.Button menuButton;
    public UnityEngine.UIElements.Button homeButton;
    public UnityEngine.UIElements.Button settingsButton;
    public UnityEngine.UIElements.Button gameButton;
    public UnityEngine.UIElements.Toggle darkmodeToggle;
    public VisualElement menu;
    public Label numSteps;
    public Label upwardStepsTaken;
    public Label jumpHeight;
    public Label speed;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        menuButton = root.Q<UnityEngine.UIElements.Button>("menu_button");
        menuButton.clicked += MenuButtonPressed;
        if (SceneManager.GetActiveScene().name != "Home")
        {
            homeButton = root.Q<UnityEngine.UIElements.Button>("home_button");
            homeButton.clicked += HomeButtonPressed;
        } else {
            numSteps = root.Q<UnityEngine.UIElements.Label>("numsteps_label");
            jumpHeight = root.Q<UnityEngine.UIElements.Label>("jumpheight_label");
            speed = root.Q<UnityEngine.UIElements.Label>("speed_label");
            upwardStepsTaken = root.Q<UnityEngine.UIElements.Label>("upwardsteps_label");
            numSteps.text = "Number of Steps: 0";
            jumpHeight.text = "Jump Height: 0";
            speed.text = "Speed: 0";
            upwardStepsTaken.text = "Upward Steps Taken: 0";
        }
        if (SceneManager.GetActiveScene().name != "Settings")
        {
            settingsButton = root.Q<UnityEngine.UIElements.Button>("settings_button");
            settingsButton.clicked += SettingsButtonPressed;
        } else {
            darkmodeToggle = root.Q<UnityEngine.UIElements.Toggle>("darkmode_toggle");
        }
        if (SceneManager.GetActiveScene().name != "firstscene")
        {
            gameButton = root.Q<UnityEngine.UIElements.Button>("game_button");
            gameButton.clicked += GameButtonClicked;
        }
        menu = root.Q<VisualElement>("menu");
        menu.SetEnabled(false);
        menu.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (darkmodeToggle != null && SceneManager.GetActiveScene().name == "Settings")
        {
            if (darkmodeToggle.value)
            {
                GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().darkMode = true;
            } else {
                GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().darkMode = false;
            }
        }
        if (GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().darkMode)
        {
            image.color = new Color32(0x57, 0x57, 0x57, 100);
        } else {
            image.color = Color.white;
        }
        if (SceneManager.GetActiveScene().name == "Home")
        {
            int newNumSteps = (int)GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().timeElapsed;
            numSteps.text = "Number of Steps: " + newNumSteps;
            int newUpwardSteps = (int)GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().temp_stepsTaken;
            upwardStepsTaken.text = "Upward Steps Taken: " + newUpwardSteps;
            float newSpeed = 1 + newNumSteps * 0.01f;
            speed.text = "Speed: " + newSpeed;
            float newJumpHeight = 1 + newUpwardSteps * 0.01f;
            jumpHeight.text = "Jump Height: " + newJumpHeight;
            GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().newNumSteps = newNumSteps;
            GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().newJumpHeight = newJumpHeight;
            GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().newSpeed = newSpeed;
            GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().newUpwardSteps = newUpwardSteps;
        }
    }

    void MenuButtonPressed()
    {
        if (menu.enabledSelf)
        {
            menu.SetEnabled(false);
            menu.visible = false;
        } else {
            menu.SetEnabled(true);
            menu.visible = true;
        }
    }

    void HomeButtonPressed()
    {
        SceneManager.LoadScene("Home");
        menu.SetEnabled(false);
        menu.visible = false;
    }

    void SettingsButtonPressed()
    {
        SceneManager.LoadScene("Settings");
        menu.SetEnabled(false);
        menu.visible = false;
    }

    void GameButtonClicked()
    {
        SceneManager.LoadScene("firstscene");
        menu.SetEnabled(false);
        menu.visible = false;
    }
}
