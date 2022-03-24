using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteUI : MonoBehaviour
{
    public Text livesText;
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "LIVES:" + (GameData.lives).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "LIVES:" + (GameData.lives).ToString();
        DrawDeadText();
    }

    void DrawDeadText() {
        if (GameData.dead) {
            gameOverText.gameObject.SetActive(true);
        }
    }
}
