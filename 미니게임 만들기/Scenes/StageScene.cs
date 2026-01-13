using System.Diagnostics;
using System.Numerics;

public class StageScene : Scene
{
    private Tile[,] _field = new Tile[9, 15];
    private PlayerCharacter _player;
    private Bullet _bullet;
    private Monster _monster;
    
    public StageScene(PlayerCharacter player) => Init(player);
    
    public void Init(PlayerCharacter player)
    {
        _player = player;

        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                 Vector pos = new Vector(x, y);
                 _field[y, x] = new Tile(pos);
            }
        }
    }

    public override void Enter()
    {
        _player.Field =  _field;
        // _monster.Field = _field;
        _player.Position = new Vector(4, 7);
        // _monster.Position = new Vector(1, 1);
        _field[_player.Position.Y, _player.Position.X].OnTileObject = _player;
        // _field[_monster.Position.Y, _monster.Position.X].OnTileObject = _monster;
        //_field[_player.Position.Y, _player.Position.X].OnTileObject = _bullet;
        
        _field[3,5].OnTileObject = new Potion() {Name = "Potion"};
        _field[2,10].OnTileObject =  new Potion() {Name = "Potion"};
        
        
        Debug.Log("스테이지 씬 진입");
    }

    public override void Update()
    {
        _player.Update();
        _bullet.Update();
        _monster.Update();
    }

    public override void Render()
    {
        PrintField();
        _player.Render();
    }

    public override void Exit()
    {
        _field[_player.Position.Y, _player.Position.X].OnTileObject = null;
        _player.Field = null;
    }

    private void PrintField()
    {
        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                _field[y, x].Print();
            }
            Console.WriteLine("");
        }
    }
}