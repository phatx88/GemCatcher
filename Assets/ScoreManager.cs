using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverPanel;
    //public GameObject player;
    //public GameObject gem;


    //B1: Tạo biến lưu giá tri điểm người chơi
    public static int score = 0;
    public static float remainingTime;

    void Start()
    {
        remainingTime = 30;
        StartCoroutine(CountdownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        //B3: cập nhật dòng hiển thĩ điểm số mới lên giao diện
        scoreText.text = "Score: " + score + " | Time: " + remainingTime;

        //B7: Cap nhat game over
        if (remainingTime == 0)
        {
            //GameObject.FindWithTag("Player").GetComponent<CharacterMovement>().enabled = false;
            //GameObject.FindWithTag("Gem").GetComponent<GemMover>().enabled = false;
            //GameObject.FindWithTag("GemSpawner").GetComponent<GemFallScript>().enabled = false;
            GameOver();
        }
    }

    //B2: Tạo hàm để cộng điểm
    public static void AddScore(int amount)
    {
        score += amount;
    }

    //B4: Tạo hàm timer count down
    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f); //sau khi pass 1 giay ket thuc Cotroutine = muc dich de vaong lap chay every second passed
            remainingTime--;
        }
    }

    //B5: tao ham game over
    private void GameOver()
    {
        gameOverText.text = "Game Over! \nScore: " + score;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
