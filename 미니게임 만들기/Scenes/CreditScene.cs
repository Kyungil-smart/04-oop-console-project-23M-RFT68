public class CreditScene : Scene
{
    private CreditList _credit;

    public CreditScene()
    {
        Init();
    }

    public void Init()
    {
        _credit = new CreditList();
        _credit.Add($"도움을 주신분 : ({GameManager.SupporterName})", Supporter);
        _credit.Add($"만든이 : ({GameManager.DeveloperName})" , Developer);
        _credit.Add("뒤로", GoToTitle);
    }

    public override void Enter()
    {
        _credit.Reset();
    }

    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _credit.SelectUp();
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _credit.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.Escape))
        {
            _credit.Select();
        }
    }

    public override void Render()
    {
        Console.SetCursorPosition(5, 1);
        GameManager.GameCredit.Print(ConsoleColor.DarkCyan);
        
        _credit.Render(8, 5);
    }

    public override void Exit()
    {
    }

    private void Supporter()
    {
    }

    private void Developer()
    {
    }

    public void GoToTitle()
    {
        SceneManager.Change("TitleScene");
    }
}