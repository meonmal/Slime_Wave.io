using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private GameObject panelGameStart;
    [SerializeField]
    private GameObject panelGameOver;
    // 현재 점수를 출력하는 텍스트 UI
    [SerializeField]
    private TextMeshProUGUI textCurrentScore;
    // 최고 점수를 출력하느 텍스트 UI
    [SerializeField]
    private TextMeshProUGUI textBestScore;

    private int currentScore = 0;

    public bool IsGameOver { private set; get; } = false;

    private IEnumerator Start()
    {
        // 디바이스에 "BestScore" 키로 저장되어 있는 최고 점수 데이터를 불러온다.
        int bestScore = PlayerPrefs.GetInt(Constants.BestScore);
        // 게임 화면에 최고 점수를 출력
        textBestScore.text = $"<size=50>BEST</size>\n<size=100>{bestScore}</size>";

        // 마우스 왼쪽 버튼을 누를 때 까지 반복문 재생 
        while (true)
        {
            // 마우스 왼쪽 버튼을 누르면 GameStart() 함수 실행, 코루틴 break
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();

                yield break;
            }

            yield return null;
        }
    }

    private void GameStart()
    {
        // 게임 타이틀과 Tap To Play 텍스트를 보이지 않게 설정
        panelGameStart.SetActive(false);
        // 점수 Text UI 활성화
        textCurrentScore.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        IsGameOver = true;

        // 디바이스에 "BestScore" 키로 저장 되어 있는 최고 점수 데이터를 불러온다.
        int bestScore = PlayerPrefs.GetInt(Constants.BestScore);
        if(currentScore > bestScore)
        {
            PlayerPrefs.SetInt(Constants.BestScore, currentScore);
            textBestScore.text = $"<size=50>BEST</size>\n<size=100>{currentScore}</size>";
        }

        // 게임 오버 UI 활성화
        panelGameOver.SetActive(true);
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;
        // 현재 점수를 텍스트 UI에 출력
        textCurrentScore.text = currentScore.ToString();
    }

    public void ContinueGame()
    {
        // 현재 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
