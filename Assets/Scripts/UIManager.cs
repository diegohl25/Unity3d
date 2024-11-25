using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;

    public Slider slider;
    public TextMeshProUGUI currentLevel;
    public TextMeshProUGUI nextLevel;

    public Transform topTrans;
    public Transform goalTrans;

    public Transform ball;

    void Update()
    {
        currentScoreText.text = "Score: " + GameManager.singleton.currentScore;
        bestScoreText.text = "Best: " + GameManager.singleton.bestScore;
        ChangeSliderLevelAndProgress();
    }

    public void ChangeSliderLevelAndProgress(){
        currentLevel.text = "" + (GameManager.singleton.currentLevel + 1);
        nextLevel.text = "" + (GameManager.singleton.currentLevel + 2);

        float totalDistance = (topTrans.position.y - goalTrans.position.y);
        float distanceLeft = totalDistance - (ball.position.y - goalTrans.position.y);

        float value = (distanceLeft/totalDistance);
        slider.value = Mathf.Lerp(slider.value, value, 0.3f);
    }
}
