using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;
    int keyPoint = 0 ;
    static int questPoint = 0;
    int questPointPerLevel = 0;
    int passKeyPoint = 0;
    int passQuestPoint = 0;
    int passRoutePoint = 0;
    int keyCage = 0;
    int trophyCage = 0;
    public int currentHealth;
    int maxHealth = 5;
    int password = 0;
    // bool dead = false;
    float startSleepTime = 120f;
    public float currentSleepTime;
    float limitPlayerTime;
    float extendLimitPlayerTime;
    float currentPlayerTime;
    public float startTime;
    public float wastingTime = 0f;
    string keyTime;
    string trophyTime;
    string gateTime;
    string skipTime;
    string gameOverTime;
    int enterGateStatus = 0;
    int portalPoint = 0;
    int gateSemuPoint = 0;
    int trophySemuPoint = 0;
    Vector3 touchPosition;
    Vector3 mousePosition;
    Vector3 worldPosition;
    Vector3 direction;
    Camera myMainCamera;
    float moveSpeed = 25f;
    static int currentLevel;
    static string playerToken;
    static string playerId; 
    static string playerName;
    static string playerUniv;
    static string playerDateTest; 
    static string playerTownTest; 
    bool allowDrag = true;
    float deltaX, deltaY;
    Vector3 touchPosWorld;
    Vector2 touchOrigin;
    public Vector2 startPosition;
    Animator animator;
    AudioSource audioSource;
    public static int anotherChancePoint = 1;
    static int caringSix = 1;
    static int caringEight = 1;
    static int caringTen = 1;
    int caringResult;
    int gameOverStatus = 0;
    int skipLevelStatus = 0;
    string sendData;
    static string takeAnotherChance = "n";
    int firstAbstract;
    int secondAbstract;
    int thirdAbstract;

    public Slider loadingBar;

    public UIHealthBar powerBar;
    public Text questText, keyText, goalText;
    public Image popUpSleep, popUpWasting, popUpDead, popUpRestart, sendUserData;
    public Image anotherChance;
    public Image congrat;
    public Image caring;
    public Image laodingBarOne, loadingBarTwo, loadingBarThree, loadingBarFour, loadingBarFive;
    public GateController gateController;
    bool isCoroutineLevelStarted = false;
    bool isCoroutineOverStarted = false;
    bool isSend = false;

    Vector2 lookDirection = new Vector2(1,0);

    public static string rootUrlLogin = "https://beta.gamifindo.com/api/login/2";
    public static string rootUrlScore = "https://beta.gamifindo.com/api/game/store-score";
    
    string[] listScenes = {"FirstScene", "SecondScene", "ThirdScene", "FourthScene", "FifthScene", "SixthScene", "SeventhScene", "EightScene", "NinthScene", "TenthScene"};
    string[] listBeforeScenes = {"BeforeFirstScene", "BeforeSecondScene", "BeforeThirdScene", "BeforeFourthScene", "BeforeFifthScene", "BeforeSixthScene", "BeforeSeventhScene", "BeforeEightScene", "BeforeNinthScene", "BeforeTenthScene", "FinalScene"};
    
    // Start is called before the first frame update
    void Start()
    {
        // DontDestroyOnLoad(gameObject);
        GetSceneName();
        rigidbody2D = GetComponent<Rigidbody2D>();
        this.startPosition = this.transform.position;
        // transform.position = GetStartPosition();
        // Debug.Log(GetCurrentLevel());
        
        
        currentHealth = maxHealth;
        currentSleepTime = startSleepTime;
        myMainCamera = Camera.main;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
        SetPlayerTime();

        
        // Debug.Log(anotherChancePoint);
        
        // Debug.Log(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        if(startTime > limitPlayerTime)
        {
            if(currentLevel < 6)
                {
                    SetSkipTime(startTime);
                    SetSkipLevelStatus(5);
                    if(!isCoroutineLevelStarted)
                    {
                        StartCoroutine(LevelCoroutine(popUpSleep)); 
                    }
                    
                }  
                else
                {
                    // SceneManager.LoadScene("GameOverScene");
                    if(anotherChancePoint == 1)
                    {
                        AnotherChance();
                        
                    }
                    else
                    {
                        SetGameOverStatus(4);
                        SetGameOverTime(startTime);
                        if(!isCoroutineOverStarted)
                        {
                            StartCoroutine(ChangeToGameOver());
                        }
                    }
                }
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = myMainCamera.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rigidbody2D.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            Vector2 move = new Vector2(direction.x, direction.y);

            if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }
                
            animator.SetFloat("Move X", lookDirection.x);
            animator.SetFloat("Move Y", lookDirection.y);
            animator.SetFloat("Speed", rigidbody2D.velocity.magnitude);

            if(touch.phase == TouchPhase.Ended)
            {
                rigidbody2D.velocity = Vector2.zero;
                animator.SetFloat("Move X", 0);
                animator.SetFloat("Move Y", 0);
                animator.SetFloat("Speed", rigidbody2D.velocity.magnitude);
            }
            
        }
        
        if (Input.GetMouseButton(0))
        {
            mousePosition = myMainCamera.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rigidbody2D.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

            Vector2 move = new Vector2(direction.x, direction.y);

            if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }
                
            animator.SetFloat("Move X", lookDirection.x);
            animator.SetFloat("Move Y", lookDirection.y);
            animator.SetFloat("Speed", rigidbody2D.velocity.magnitude);
        }
        else 
        {
            rigidbody2D.velocity = Vector2.zero;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", 0);
            animator.SetFloat("Speed", rigidbody2D.velocity.magnitude);
        }
        
        if(rigidbody2D.velocity == Vector2.zero)
        {
            currentSleepTime -= Time.deltaTime;
            if(currentSleepTime < 0)
            {
                if(currentLevel < 6)
                {
                    SetSkipTime(startTime);
                    SetSkipLevelStatus(3);
                    if(!isCoroutineLevelStarted)
                    {
                        StartCoroutine(LevelCoroutine(popUpSleep)); 
                    }
                }  
                else
                {
                    // SceneManager.LoadScene("GameOverScene");
                    if(anotherChancePoint != 0)
                    {
                        AnotherChance();
                        
                    }
                    else
                    {
                        SetGameOverStatus(2);
                        SetGameOverTime(startTime);
                        if(!isCoroutineOverStarted)
                        {
                            StartCoroutine(ChangeToGameOver());
                        }
                    }
                }
            }
            // Debug.Log(currentSleepTime);

        }
        else
        {
            currentSleepTime = startSleepTime;
        }

        if(rigidbody2D.velocity != Vector2.zero)
        {
            wastingTime += Time.deltaTime;
            
            if(wastingTime > 180f && (questPoint == 0))
            {
                if(currentLevel < 6)
                {
                    SetSkipTime(startTime);
                    SetSkipLevelStatus(4);
                    if(!isCoroutineLevelStarted)
                    {
                        StartCoroutine(LevelCoroutine(popUpWasting)); 
                    }
                    
                }  
                else
                {
                    // SceneManager.LoadScene("GameOverScene");
                    if(anotherChancePoint == 1)
                    {
                        AnotherChance();
                        
                    }
                    else
                    {
                        SetGameOverStatus(3);
                        SetGameOverTime(startTime);
                        if(!isCoroutineOverStarted)
                        {
                            StartCoroutine(ChangeToGameOver());
                        }
                    }
                }
            }
            // Debug.Log(wastingTime);

        }

        // if(currentHealth == 0)
        // {
        //     isDead();
        // }

        if(currentHealth == 0)
        {
            if(currentLevel < 6)
            {
                SetSkipTime(startTime);
                SetSkipLevelStatus(2);
                if(!isCoroutineLevelStarted)
                {
                    StartCoroutine(LevelCoroutine(popUpDead)); 
                }
                
            }  
            else
            {
                if(anotherChancePoint != 0)
                {
                    AnotherChance();    
                }
                else
                {
                    SetGameOverStatus(1);
                    SetGameOverTime(startTime);
                    if(!isCoroutineOverStarted)
                    {
                        StartCoroutine(ChangeToGameOver());
                    }
                    
                }
                
            }
                     
        } 
            
    }



    public void CollectKey(int amount)
    {
        keyPoint = amount;
        keyText.text = (int.Parse(keyText.text) - amount).ToString();
        // Debug.Log(keyPoint);
    }

    public void MinusCollectQuest(int amount)
    {
        questPoint -= amount;
    }

    public void CollectKeyCage(int amount)
    {
        keyCage += amount;
    }

    public void CollectQuest(int amount)
    {
        questPoint += amount;
        questText.text = (int.Parse(questText.text) - amount).ToString();
        // Debug.Log(questPoint);
    }

    public void CollectQuestPerLevel(int amount)
    {
        questPointPerLevel += amount;
    }

    public void PassKey(int amount)
    {
        passKeyPoint += amount;
        // Debug.Log(passKeyPoint);
    }

    public void PassQuest(int amount)
    {
        passQuestPoint += amount;
        // Debug.Log(passQuestPoint);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        powerBar.SetValue(currentHealth);
        // Debug.Log(currentHealth + "/" + maxHealth);
    }

    public void PassRoute(int amount)
    {
        passRoutePoint += amount;
        // Debug.Log("Pass Route");
    }

    public void SetPasswordForKey(int amount)
    {
        password = amount;
    }

    public void SetCaringSix(int amount)
    {
        caringSix = amount;
    }

    public void SetCaringEight(int amount)
    {
        caringEight = amount;
    }

    public void SetCaringTen(int amount)
    {
        caringTen = amount;
    }

    public int GetCaringSix()
    {
        return caringSix;
    }

    public int GetCaringEight()
    {
        return caringEight;
    }

    public int GetCaringTen()
    {
        return caringTen;
    }

    public int GetPasswordForKey()
    {
        return password;
    }

    public int GetKeyPoint()
    {
        return keyPoint;
    }

    public int GetKeyCage()
    {
        return keyCage;
    }

    public int GetQuestPoint()
    {
        return questPoint;
    }

    public int GetQuestPerLevel()
    {
        return questPointPerLevel;
    }

    public int GetKeySensor()
    {
        return passKeyPoint;
    }

    public int GetQuestSensor()
    {
        return passQuestPoint;
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetPlayerToken(string token)
    {
        playerToken = token;
    }

    public string GetPlayerToken()
    {
        return playerToken;
    }

    public void SetPlayerId(string id)
    {
        playerId = id;
    }

    public string GetPlayerId()
    {
        return playerId;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void SetPlayerUniv(string name)
    {
        playerUniv = name;
    }

    public void SetPlayerDateTest(string date)
    {
        playerDateTest = date;
    }

    public void SetPlayerTownTest(string name)
    {
        playerTownTest = name;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public string GetPlayerUniv()
    {
        return playerUniv;
    }

    public string GetPlayerDateTest()
    {
        return playerDateTest;
    }

    public string GetPlayerTownTest()
    {
        return playerTownTest;
    }

    public void SetKeyTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        keyTime = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public string GetKeyTime()
    {
        return keyTime;
    }

    public void SetTrophyTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        trophyTime = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public string GetTrophyTime()
    {
        return trophyTime;
    }

    public void SetGateTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        gateTime = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetSkipTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        skipTime = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetGameOverTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        gameOverTime = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public string GetGateTime()
    {
        return gateTime;
    }

    public string GetSkipTime()
    {
        return skipTime;
    }

    public string GetGameOverTime()
    {
        return gameOverTime;
    }

    public void SetPortalPoint(int amount)
    {
        portalPoint = amount;
    }

    public void SetGateSemuPoint(int amount)
    {
        gateSemuPoint = amount;
    }

    public void SetTrophySemuPoint(int amount)
    {
        trophySemuPoint = amount;
    }

    public int GetPortalPoint()
    {
        return portalPoint;
    }

    public int GetGateSemuPoint()
    {
        return gateSemuPoint;
    }

    public int GetTrophySemuPoint()
    {
        return trophySemuPoint;
    }

    public void SetCaringResult(int result)
    {
        caringResult = result;
    }

    public int GetCaringResult()
    {
        return caringResult;
    }

    public void SetGameOverStatus(int status)
    {
        gameOverStatus = status;
    }

    public int GetGameOverStatus()
    {
        return gameOverStatus;
    }

    public void SetSkipLevelStatus(int status)
    {
        skipLevelStatus = status;
    }

    public int GetSkipLevelStatus()
    {
        return skipLevelStatus;
    }

    public void SetEnterGateStatus(int status)
    {
        enterGateStatus = status;
    }

    public int GetEnterGateStatus()
    {
        return enterGateStatus;
    }

    public void SetTrophyCagePoint(int amount)
    {
        trophyCage = amount;
    }

    public int GetTrophyCagePoint()
    {
        return trophyCage;
    }

    public void SetTakeAnotherChance(string choose)
    {
        takeAnotherChance = choose;
    }

    public string GetTakeAnotherChance()
    {
        return takeAnotherChance;
    }

    public void SetFirstAbstract(int amount)
    {
        firstAbstract = amount;
    }

    public void SetSecondAbstract(int amount)
    {
        secondAbstract = amount;
    }

    public void SetThirdAbstract(int amount)
    {
        thirdAbstract = amount;
    }

    public int GetFirstAbstract()
    {
        return firstAbstract;
    }

    public int GetSecondAbstract()
    {
        return secondAbstract;
    }

    public int GetThirdAbstract()
    {
        return thirdAbstract;
    }

    public void IsSend()
    {
        isSend = true;
    }

    public void AnotherChancePoint()
    {
        currentHealth = maxHealth;
        anotherChancePoint = 0;
    
    }


    IEnumerator LevelCoroutine(Image popUp)
    {
        isCoroutineLevelStarted = true;

        popUp.gameObject.SetActive(true);

        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;

        // Debug.Log(index);
        yield return new WaitForSeconds(2);
        
        SendSkipData();
        

        // SceneManager.LoadScene(listBeforeScenes[index]);
    }



    public void AnotherChance()
    {
        anotherChance.gameObject.SetActive(true);
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        // anotherChancePoint -= 1;
    }

    public IEnumerator ChangeLevelCoroutine(int index)
    {

        // yield return null;
        isCoroutineLevelStarted = true;
        congrat.gameObject.SetActive(true);

        switch (currentLevel)
        {
            case 1:
                goalText.text = NextButton.levelOne;
                break;
            case 2:
                goalText.text = NextButton.levelTwo;
                break;
            case 3:
                goalText.text = NextButton.levelThree;
                break;
            case 4:
                goalText.text = NextButton.levelFour;
                break;
            case 5:
                goalText.text = NextButton.levelFive;
                break;
            case 6:
                goalText.text = NextButton.levelSix;
                break;
            case 7:
                goalText.text = NextButton.levelSeven;
                break;
            case 8:
                goalText.text = NextButton.levelEight;
                break;
            case 9:
                goalText.text = NextButton.levelNine;
                break;
            case 10:
                goalText.text = NextButton.levelTen;
                break;
            default:
                break;
        }

        if(index == 5)
        {
            congrat.gameObject.transform.GetChild(3).gameObject.SetActive(true);
            congrat.gameObject.transform.GetChild(4).gameObject.SetActive(true);
            congrat.gameObject.transform.GetChild(4).gameObject.GetComponent<Text>().text = GetQuestPoint().ToString();

        }
        else
        {
            congrat.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            congrat.gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(0.5f);
        loadingBarTwo.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        loadingBarThree.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        loadingBarFour.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        loadingBarFive.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        // AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(listBeforeScenes[index]);
        SceneManager.LoadScene(listBeforeScenes[index]);

        // asyncOperation.allowSceneActivation = false;

        // while (!asyncOperation.isDone)
        // {
        //     float progress = Mathf.Clamp01(asyncOperation.progress / .9f);

        //     loadingBar.value = progress;

        //     yield return null;
        // }

        // asyncOperation.allowSceneActivation = true;
        // yield return new WaitForSeconds(5);

        // SceneManager.LoadScene(listBeforeScenes[index]);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PopUpCaring()
    {
        caring.gameObject.SetActive(true);
    }

    public void PopUpRestart()
    {
        popUpRestart.gameObject.SetActive(true);
    }

    public void SendGameOverData()
    {
        switch (GetCurrentLevel())
            {
                case 1:
                    sendData = gateController.FirstLevelPost(this);
                    StartCoroutine(gateController.HttpPostGameOver(sendData, this, "Goal 1"));
                    break;
                case 2:
                    sendData = gateController.SecondLevelPost(this);
                    StartCoroutine(gateController.HttpPostGameOver(sendData, this, "Goal 2"));
                    break;
                case 3:
                    sendData = gateController.ThirdLevelPost(this);
                    StartCoroutine(gateController.HttpPostGameOver(sendData, this, "Goal 3"));
                    break;
                case 4:
                    sendData = gateController.FourthLevelPost(this);
                    StartCoroutine(gateController.HttpPostGameOver(sendData, this, "Goal 4"));
                    break;
                case 5:
                    sendData = gateController.FifthLevelPost(this);
                    Debug.Log(sendData);
                    StartCoroutine(gateController.HttpPostGameOver(sendData, this, "Goal 5"));
                    break;
                case 6:
                    sendData = gateController.SixthLevelPost(this);
                    StartCoroutine(gateController.HttpPostGameOver(sendData, this, "Goal 6"));
                    break;
                case 7:
                    sendData = gateController.SeventhLevelPost(this);
                    StartCoroutine(gateController.HttpPostGameOver(sendData, this, "Goal 7"));
                    break;
                case 8:
                    sendData = gateController.EightLevelPost(this);
                    StartCoroutine(gateController.HttpPostGameOver(sendData, this, "Goal 8"));
                    break;
                case 9:
                    sendData = gateController.NinthLevelPost(this);
                    StartCoroutine(gateController.HttpPostGameOver(sendData, this, "Goal 9"));
                    break;
                case 10:
                    sendData = gateController.TenthLevelPost(this);
                    StartCoroutine(gateController.HttpPostGameOver(sendData, this, "Goal 10"));
                    break;
                default:
                    break;
            }
    }

    public void SendSkipData()
    {
        switch (GetCurrentLevel())
            {
                case 1:
                    sendData = gateController.FirstLevelPost(this);
                    StartCoroutine(gateController.HttpPostSkip(sendData, this, "Goal 1"));
                    break;
                case 2:
                    sendData = gateController.SecondLevelPost(this);
                    StartCoroutine(gateController.HttpPostSkip(sendData, this, "Goal 2"));
                    break;
                case 3:
                    sendData = gateController.ThirdLevelPost(this);
                    StartCoroutine(gateController.HttpPostSkip(sendData, this, "Goal 3"));
                    break;
                case 4:
                    sendData = gateController.FourthLevelPost(this);
                    StartCoroutine(gateController.HttpPostSkip(sendData, this, "Goal 4"));
                    break;
                case 5:
                    sendData = gateController.FifthLevelPost(this);
                    StartCoroutine(gateController.HttpPostSkip(sendData, this, "Goal 5"));
                    break;
                case 6:
                    sendData = gateController.SixthLevelPost(this);
                    StartCoroutine(gateController.HttpPostSkip(sendData, this, "Goal 6"));
                    break;
                case 7:
                    sendData = gateController.SeventhLevelPost(this);
                    StartCoroutine(gateController.HttpPostSkip(sendData, this, "Goal 7"));
                    break;
                case 8:
                    sendData = gateController.EightLevelPost(this);
                    StartCoroutine(gateController.HttpPostSkip(sendData, this, "Goal 8"));
                    break;
                case 9:
                    sendData = gateController.NinthLevelPost(this);
                    StartCoroutine(gateController.HttpPostSkip(sendData, this, "Goal 9"));
                    break;
                case 10:
                    sendData = gateController.TenthLevelPost(this);
                    StartCoroutine(gateController.HttpPostSkip(sendData, this, "Goal 10"));
                    break;
                default:
                    break;
            }
    }

    public IEnumerator ChangeToGameOver()
    {
        isCoroutineOverStarted = true;
        
        yield return new WaitForSeconds(2);
        SendGameOverData();
        // SceneManager.LoadScene("GameOverScene");
    }

    public void GetSceneName()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "FirstScene":
                SetCurrentLevel(1);
                break;
            case "SecondScene":
                SetCurrentLevel(2);
                break;
            case "ThirdScene":
                SetCurrentLevel(3);
                break;
            case "FourthScene":
                SetCurrentLevel(4);
                break;
            case "FifthScene":
                SetCurrentLevel(5);
                break;
            case "SixthScene":
                SetCurrentLevel(6);
                break;
            case "SeventhScene":
                SetCurrentLevel(7);
                break;
            case "EightScene":
                SetCurrentLevel(8);
                break;
            case "NinthScene":
                SetCurrentLevel(9);
                break;
            case "TenthScene":
                SetCurrentLevel(10);
                break;
            default:
                break;
        }
    }

    public void SetPlayerTime()
    {
        if(GetCurrentLevel() == 1 || GetCurrentLevel() == 2)
        {
            limitPlayerTime = 180f;
        }
        else if(GetCurrentLevel() == 3)
        {
            limitPlayerTime = 240f;
        }
        else if(GetCurrentLevel() == 4 || GetCurrentLevel() == 5 || GetCurrentLevel() == 6)
        {
            limitPlayerTime = 300f;
        }
        else if(GetCurrentLevel() == 7)
        {
            limitPlayerTime = 480f;
        }
        else if(GetCurrentLevel() == 8)
        {
            limitPlayerTime = 600f;
        }
        else if(GetCurrentLevel() == 9)
        {
            limitPlayerTime = 720f;
        }
        else if(GetCurrentLevel() == 10)
        {
            limitPlayerTime = 900f;
        }
    }

}
