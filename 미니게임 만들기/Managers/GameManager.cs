using System;
using System.Diagnostics;

public class GameManager
{
    public static bool IsGameOver { get; set; }
    public const string GameName = "UnLucky of Issac";
    public const string GameCredit = "Credit";
    public const string DeveloperName = "고병희";
    public const string SupporterName = "김재성 강사님 & 최영민 강사님";
    private PlayerCharacter _player;
    // private Monster _monster;
    
    public void Run()
    {
        Init();

        while (!IsGameOver)
        {
            // 랜더링
            Console.Clear(); // 콘솔창 비우기
            SceneManager.Render();
            InputManager.GetUserInput(); // 키입력 받기

            if (InputManager.GetKey(ConsoleKey.Tab))
            {
                SceneManager.Change("Log");
            }
            // 데이터 처리
            SceneManager.Update();
        }
    }

    private void Init()
    {
        IsGameOver = false;
        SceneManager.OnChangeScene += InputManager.ResetKey;
        _player = new PlayerCharacter();
        
        SceneManager.AddScene("Title", new TitleScene());
        SceneManager.AddScene("Story", new StoryScene());
        SceneManager.AddScene("Stage", new StageScene(_player));
        SceneManager.AddScene("Log", new LogScene());
        SceneManager.AddScene("Credit", new CreditScene());
        
        SceneManager.Change("Title");

        Debug.Log("게임 데이터 초기화 완료");
    }
}
