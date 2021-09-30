using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField]
    [Range(0, 1)]
    private float fillAmount = 0;
    [SerializeField]
    private SpriteRenderer fill;
    [SerializeField]
    private TextMeshProUGUI timeText;

    // ---

    private float time = 10.0f;
    private int currentXposition = 0;

    private void Awake()
    {
        SettingsOnStart();
    }

    private void Update()
    {
        LifeTimer();
        Movement();
    }

    private void OnValidate()
    {
        FillAmountChange();
    }

    void SettingsOnStart()
    {

    }

    private void FillAmountChange()
    {
        fill.size = new Vector2(fill.size.x, fillAmount);
        fill.transform.localPosition = new Vector3(fill.transform.localPosition.x, fillAmount / 2 - 0.5f, 0);
    }

    private void LifeTimer()
    {
        if (time <= 0)
            return;

        time -= Time.deltaTime;
        timeText.text = time.ToString("F1");

        if(time <= 10)
        {
            fill.size = new Vector2(fill.size.x, 1 - (time / 10));
            fill.transform.localPosition = new Vector3(fill.transform.localPosition.x, (1 - (time / 10)) / 2 - 0.5f, 0);
        }
        else
        {
            fill.size = new Vector2(fill.size.x, 0);
            fill.transform.localPosition = new Vector3(fill.transform.localPosition.x, 0, 0);
        }
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.A)) // Left
        {
            if (currentXposition == -2)
                return;

            transform.position = new Vector3(transform.position.x - 1, transform.position.y - 1.5f, 0);
            currentXposition -= 1;
            Brain.self.DestroyUpperLine();
        }
        else if (Input.GetKeyDown(KeyCode.D)) // Right
        {
            if (currentXposition == 2)
                return;

            transform.position = new Vector3(transform.position.x + 1, transform.position.y - 1.5f, 0);
            currentXposition += 1;
            Brain.self.DestroyUpperLine();
        }
    }

}
