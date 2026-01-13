
public class Monster : GameObject
{
    Random rand = new Random();
    public ObservableProperty<int> Health =  new ObservableProperty<int>((4));
    private string _healthGauge;

    public Tile[,] Field { get; set; }
    public bool IsActiveControl  { get; private set;}

    public Monster() => Init();

    public void Init()
    {
        Symbol = 'M';
        IsActiveControl = true; 
        Health.AddListener(SetHealthGauge);
        _healthGauge = "■■■■";
    }

    public void Update()
    {
        // if (BulletHit)
        // {
        //     Health.Value --;
        //     if (Health.Value <= 0)
        //     {
        //         Monster.Die();
        //     }
        // }

        // 살아있는동안 랜덤으로 움직이는 메서드
        if (IsActiveControl)
        {
            switch (rand.Next(0,4))
            {
                case 4:
                    Move(Vector.Up);
                    break;
                case 3:
                    Move(Vector.Down);
                    break;
                case 2:
                    Move(Vector.Left);
                    break;
                case 1:
                    Move(Vector.Right);
                    break;
            }
        }
    }

    // public void Die()
    // {
    //     IsActiveControl = false;
    //     Monster.Remove(this);
    // }

    private void Move(Vector direction)
    {
        if (Field == null || !IsActiveControl) return;

        Vector current = Position;
        Vector nextPos = Position + direction;
            
        GameObject nextTileObject = Field[nextPos.Y, nextPos.X].OnTileObject;

        if (nextTileObject != null)
        {
            if (nextTileObject is IInteractable3)
            {
                (nextTileObject as IInteractable3). Interact(this);
            }
        }

        Field[Position.Y, Position.X].OnTileObject = null;
        Field[nextPos.Y, nextPos.X].OnTileObject = this;
    }

    public void Render()
    {
    }

    public void SetHealthGauge(int health)
    {
        switch (health)
        {
            case 4:
                _healthGauge = "■■■■";
                break;
            case 3:
                _healthGauge = "■■■□";
                break;
            case 2:
                _healthGauge = "■■□□";
                break;
            case 1:
                _healthGauge = "■□□□";
                break;
        }
    }
}