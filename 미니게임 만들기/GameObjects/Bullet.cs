
public class Bullet : GameObject
{
    
    public Tile[,] Field { get; set; }
    
    public Bullet() => Init();

    private void Init()
    {
        Symbol = '*';
    }


    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.LeftArrow))
        {
            Shoot(BulletVector.Left);
        }

        if (InputManager.GetKey(ConsoleKey.RightArrow))
        {
            Shoot(BulletVector.Right);
        }

        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            Shoot(BulletVector.Up);
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            Shoot(BulletVector.Down);
        }
    }

    private void Shoot(BulletVector direction)
    {
        if (Field == null) return;
        
        BulletVector current = bPosition;
        BulletVector nextPos = bPosition + direction;

        GameObject nextTileObject = Field[nextPos.Y, nextPos.X].OnTileObject;

        if (nextTileObject != null)
        {
            if (nextTileObject is IInteractable2)
            {
                (nextTileObject as IInteractable2).Interact(this);
            }
        }

        Field[Position.Y, Position.X].OnTileObject = null;
        Field[nextPos.Y, nextPos.X].OnTileObject = this;
        bPosition = nextPos;
    }

    
}