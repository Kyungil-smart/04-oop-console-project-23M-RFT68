

public static class InputManager
{
    private static ConsoleKey _current;

    private static readonly ConsoleKey[] _keys =
    {
        ConsoleKey.W,
        ConsoleKey.A,
        ConsoleKey.S,
        ConsoleKey.D,
        ConsoleKey.E,
        ConsoleKey.Spacebar,
        ConsoleKey.Escape
    };

    public static bool GetKey(ConsoleKey input)
    {
        return _current == input; // 키가 입력 되었다면 _Current에 해당키 반환
    }

    // GameManager에서만 호출
    public static void GetUserInput()
    {
        ConsoleKey input = Console.ReadKey(true).Key;
        _current = ConsoleKey.Clear;

        foreach (ConsoleKey key in _keys)
        {
            if (key == input)
            {
                _current = input;
                break;
            }
        }
    }

    public static void ResetKey()
    {
        _current = ConsoleKey.Clear;
    }
}