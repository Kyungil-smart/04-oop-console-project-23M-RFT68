using System;

public class GameManager
{
    public static bool IsGameOver { get; set; }
    public const string GameName = "";
    private PlayerCharacter _Player;
    
    Public void Run()
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
        SceneManager.OnChangeScene 
        
        
    }





}
