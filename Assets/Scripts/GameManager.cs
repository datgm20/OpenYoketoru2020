//#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Tooltip("シーン開始時に効果音を鳴らす時チェック"), SerializeField]
    bool isStartSe = false;
    [Tooltip("スコアの表示先。不要な時は未設定"), SerializeField]
    TextMeshProUGUI scoreText = default;
    [Tooltip("残り時間の表示先。不要な時は未設定"), SerializeField]
    TextMeshProUGUI timeText = default;
    [Tooltip("ハイスコアの表示先。不要な時は未設定"), SerializeField]
    TextMeshProUGUI highScoreText = default;

    const float StartTime = 10f;
    const int ScoreMax = 99999;

    static int score;
    static float time;
    static int highScore = 100;
    /// <summary>
    /// ゲーム中の時true。
    /// </summary>
    public static bool IsGameStarted { get; private set; } = false;

    public static float GetTime
    {
        get
        {
            return Mathf.Round(time * 10f) / 10f;
        }
    }

    private void Awake()
    {
        Instance = this;
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
        Item.ClearCount();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isStartSe)
        {
            TinyAudio.PlaySe(TinyAudio.Se.Click);
        }
        score = 0;
        time = StartTime;

        UpdateScoreText();
        UpdateTimeText();
        UpdateHighScoreText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            Application.Quit();
#endif
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsGameStarted) return;

        time -= Time.fixedDeltaTime;
        if (time <= 0)
        {
            time = 0;
            ToGameover();
        }
        UpdateTimeText();


#if DEBUG_KEY
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        }
#endif
    }

    void UpdateScoreText()
    {
        if(scoreText != null)
        {
            scoreText.text = $"{score:00000}";
        }
    }

    void UpdateHighScoreText()
    {
        if (highScoreText!= null)
        {
            highScoreText.text = $"High Score: {highScore:00000}";
        }
    }

    public void AddPoint(int point)
    {
        score += point;

        // 上限チェックその1
        if (score > ScoreMax)
        {
            score = ScoreMax;
        }
        // 上限チェックその2(三項式)
        score = score < ScoreMax ? score : ScoreMax;
        // 上限チェックその3(関数型)
        score = Mathf.Min(score, ScoreMax);

        UpdateScoreText();
    }

    void UpdateTimeText()
    {
        if (timeText != null)
        {
            timeText.text = $"{time:0.0}";
        }
    }

    public static void ToGameover()
    {
        if (!IsGameStarted) return;

        IsGameStarted = false;
        Time.timeScale = 0;
        SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        CheckHighScore();
    }

    public static void ToClear()
    {
        if (!IsGameStarted) return;

        IsGameStarted = false;
        Time.timeScale = 0;
        SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        CheckHighScore();
    }

    public void StartGame()
    {
        if (IsGameStarted) return;

        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        IsGameStarted = true;
    }

    public static void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(highScore);
        }
    }

    [System.Diagnostics.Conditional("DEBUG_LOG")]
    public static void Log(object mes)
    {
        Debug.Log(mes);
    }
}
