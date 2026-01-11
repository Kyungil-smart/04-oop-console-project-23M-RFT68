using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

public class PlayerCharacter : GameObject
{
    public ObservableProperty<int> Health = new ObservableProperty<int>(6);
    private string _healthGauge;

    public Tile[,] Field { get; set; }
    private Inventory _inventory;
    public bool IsActiveControl { get; private set; }

    public PlayerCharacter() => Init();

    public void Init()
    {
        // ◧
        Symbol = 'I';
        IsActiveControl = true;
        Health.AddListener(SetHealthGauge);
        _healthGauge = "■■■";
        _inventory = new Inventory(this);
    }

    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.W))
        {
            Move(Vector.Up);
        }

        if (InputManager.GetKey(ConsoleKey.S))
        {
            Move(Vector.Down);
        }

        if (InputManager.GetKey(ConsoleKey.A))
        {
            Move(Vector.Left);
        }

        if (InputManager.GetKey(ConsoleKey.D))
        {
            Move(Vector.Right);
        }

        if (InputManager.GetKey(ConsoleKey.Tab))
        {
            HandleControl();
        }

        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _inventory.SelectUp();
        }
        
        if (InputManager.GetKey(ConsoleKey.DownArrow))
        { 
            _inventory.SelectDown();
        }

        //  if (PlayerCharacter == monster || PlayerCharacter == spike)
        //  {
        //      Health.Value--;
        //  }
    }

    public void HandleControl()
    {
        _inventory.IsActive =  !_inventory.IsActive;
        IsActiveControl = !_inventory.IsActive;
        Debug.LogWarning($"{_inventory._itemMenu.CurrentIndex}");
    }

    private void Move(Vector direction)
    {
        if (Field == null || !IsActiveControl) return;

        Vector current = Position;
        Vector nextPos = Position + direction;
        
        // 1. 맵 밖은 아닌지?
        // 2. 벽인지?

        GameObject nextTileObject = Field[nextPos.Y, nextPos.X].OnTileObject;

        if (nextTileObject != null)
        {
            if (nextTileObject is IInteractable)
            {
                (nextTileObject as IInteractable). Interact(this);
            }
        }

        Field[Position.Y, Position.X].OnTileObject = null;
        Field[nextPos.Y, nextPos.X].OnTileObject = this;
        Position = nextPos;
        
        Debug.LogWarning($"플레이어 이동 : ({current.X}, {current.Y}) -> ({nextPos.X}, {nextPos.Y})");
    }

    public void Render()
    {
        DrawHealthGauge();
        _inventory.Render();
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    public void DrawHealthGauge()
    {
        Console.SetCursorPosition(8,15);
        _healthGauge.Print(ConsoleColor.Red);
    }

    public void SetHealthGauge(int health)
    {
        switch (health)
        {
            case 6:
                _healthGauge = "■■■";
                break;
            case 5:
                _healthGauge = "■■◧";
                break;
            case 4:
                _healthGauge = "■■□";
                break;
            case 3:
                _healthGauge = "■◧□";
                break;
            case 2:
                _healthGauge = "■□□";
                break;
            case 1:
                _healthGauge = "◧□□";
                break;
        }
    }

    public void Heal(int value)
    {
        Health.Value += value; 
    }
}