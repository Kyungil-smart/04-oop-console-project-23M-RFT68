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
        _credit.Add("도움을 주신분 : ");
        _credit.Add("만든이 : ");
        _credit.Add("뒤로",);
    }

    public override void Enter()
    {
        _titleMenu.Reset();
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
        GameManager.
        
    }





}