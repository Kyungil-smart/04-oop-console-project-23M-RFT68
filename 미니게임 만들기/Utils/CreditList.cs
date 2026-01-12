public class CreditList
{
    private List<(string text, Action action)> _credits;
    private int _currentIndex;
    public int CurrentIndex { get => _currentIndex; }
    private Ractangle _outLine;
    private int _maxLength;

    public CreditList(params (string, Action)[] creditTexts)
    {
        if (creditTexts.Length == 0)
        {
            _credits = new List<(string, Action)>();
        }
        else
        {
            _credits = creditTexts.ToList();
        }

        for (int i = 0; i < _credits.Count; i++)
        {
            int textWidth = _credits[i].text.GetTextWidth();

            if (_maxLength < textWidth)
            {
                _maxLength = textWidth;
            }
        }
        _outLine = new Ractangle(width: _maxLength + 4, height: _credits.Count + 2);
    }

    public void Reset()
    {
        _currentIndex = 0;
    }

    public void Select()
    {
        if (_credits.Count == 0) return;
        
        _credits[_currentIndex].action?.Invoke();

        if (_currentIndex == 0) _currentIndex = 0;
        else if (_currentIndex >= _credits.Count) _currentIndex = _credits.Count - 1;
    }
    
    public void Add(string text, Action action)
    {
        _credits.Add((text, action));

        int textWidth = text.GetTextWidth();
        if (_maxLength < textWidth)
        {
            _maxLength = textWidth;
        }

        _outLine.Width = _maxLength + 4;
        _outLine.Height++;
    }

    public void Remove()
    {
        _credits.RemoveAt(_currentIndex);

        int max = 0;

        foreach ((string text, Action action) in _credits)
        {
            int  textWidth = text.GetTextWidth();
            
            if (max < textWidth) max = textWidth;
        }

        if (_maxLength != max) _maxLength = max;
        
        _outLine.Width = _maxLength + 4;
        _outLine.Height--;
    }

    public void SelectUp()
    {
        _currentIndex--;
        if (_currentIndex < 0)
            _currentIndex = 0;
    }

    public void SelectDown()
    {
        _currentIndex++;

        if (_currentIndex >= _credits.Count)
            _currentIndex = _credits.Count - 1;
    }

    public void Render(int x, int y)
    {
        _outLine.X = x;
        _outLine.Y = y;
        _outLine.Draw();

        for (int i = 0; i < _credits.Count; i++)
        {
            y++;
            Console.SetCursorPosition(x + 1, y);

            if (i == _currentIndex)
            {
                "->".Print(ConsoleColor.White);
                _credits[i].text.Print(ConsoleColor.White);
                continue;
            }
            else
            {
                Console.Write("  ");
                _credits[i].text.Print();
            }
        }
    }
}