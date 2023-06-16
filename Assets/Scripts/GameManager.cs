using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool m_ReadyForInput;
    public Player m_Player;
    public GameObject m_NextButton;
    public LevelBuilder m_LevelBuilder;
    public Text moves;
    public Text currLevel;
    public GameObject MenuPanel;
    public GameObject GamePanel;
    public GameObject LevelCompleted;
    public GameObject yayParticles;
    public Button menuButton;
    public GameObject startPanel;
    public Button startButton;
    private int currLvl;
    private GameObject m_win;

    void Start()
    {
        startPanel.SetActive(true);
        GamePanel.SetActive(false);
        MenuPanel.SetActive(false);
        startButton.onClick.AddListener(Startu);
    }
    void Startu()
    {
        startPanel.SetActive(false);
        MenuPanel.SetActive(false);
        ResetScene();
        GamePanel.SetActive(true);
        m_NextButton.SetActive(false);
        LevelCompleted.SetActive(false);
        menuButton.onClick.AddListener(OpenMenu);

    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if (m_Player)
        { 
            if (moveInput.sqrMagnitude > 0.5)
            {
                if (m_ReadyForInput)
                {
                    m_ReadyForInput = false;
                    m_Player.Move(moveInput);
                    m_NextButton.SetActive(IsLevelComplete());
                    if (IsLevelComplete())
                    {
                        LevelCompleted.SetActive(true);
                        GameObject m_win = Instantiate(yayParticles, m_Player.transform.position, Quaternion.identity);
                        
                        Destroy(m_win, 5.0f);

                    }
                }
            }
            else
            {
                m_ReadyForInput = true;
            }
            moves.text = "Ход: " + m_Player.num_moves.ToString();
            currLvl = m_LevelBuilder.m_CurrentLevel + 1;
            currLevel.text = "Уровень: " + currLvl.ToString();
        } 
    }

    public void NextLevel()
    {
        LevelCompleted.SetActive(false);
        m_NextButton.SetActive(false);
        m_LevelBuilder.NextLevel();
        StartCoroutine(ResetSceneAsync());
        ParticleSystem currentVfx = FindObjectOfType<ParticleSystem>();
        Destroy(currentVfx);
    }

    public void ResetScene()
    {
        m_Player.num_moves = 0;
        StartCoroutine(ResetSceneAsync());
        ParticleSystem currentVfx = FindObjectOfType<ParticleSystem>();
        Destroy(currentVfx);
        LevelCompleted.SetActive(false);
        m_NextButton.SetActive(false);
    }

    bool IsLevelComplete()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        foreach (var box in boxes)
        {
            if (!box.m_OnPoint)
                return false;
        }
        return true;
    }

    IEnumerator ResetSceneAsync()
    {
        if (SceneManager.sceneCount > 1)
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync("levelScene");
            while (!asyncUnload.isDone)
            {
                yield return null;
                Debug.Log("Unloading...");
            }
            Debug.Log("Unload Done");
            Resources.UnloadUnusedAssets();
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("levelScene", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
            Debug.Log("Loading...");
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("levelScene"));
        m_LevelBuilder.Build();
        m_Player = FindObjectOfType<Player>();
        Debug.Log("Level loaded");
        LevelCompleted.SetActive(false);
        m_NextButton.SetActive(false);
    }

    public void OpenMenu()
    {
        MenuPanel.SetActive(true);
        GamePanel.SetActive(false);
    }
    public void CloseMenu()
    {
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void StartLevel1()
    {
        m_LevelBuilder.LoadLevel(0);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void StartLevel2()
    {
        m_LevelBuilder.LoadLevel(1);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void StartLevel3()
    {
        m_LevelBuilder.LoadLevel(2);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void StartLevel4()
    {
        m_LevelBuilder.LoadLevel(3);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void StartLevel5()
    {
        m_LevelBuilder.LoadLevel(4);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void StartLevel6()
    {
        m_LevelBuilder.LoadLevel(5);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void StartLevel7()
    {
        m_LevelBuilder.LoadLevel(6);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void StartLevel8()
    {
        m_LevelBuilder.LoadLevel(7);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void StartLevel9()
    {
        m_LevelBuilder.LoadLevel(8);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void StartLevel10()
    {
        m_LevelBuilder.LoadLevel(9);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void StartLevel11()
    {
        m_LevelBuilder.LoadLevel(10);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void StartLevel12()
    {
        m_LevelBuilder.LoadLevel(11);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void StartLevel13()
    {
        m_LevelBuilder.LoadLevel(12);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void StartLevel14()
    {
        m_LevelBuilder.LoadLevel(13);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void StartLevel15()
    {
        m_LevelBuilder.LoadLevel(14);
        StartCoroutine(ResetSceneAsync());
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
}
