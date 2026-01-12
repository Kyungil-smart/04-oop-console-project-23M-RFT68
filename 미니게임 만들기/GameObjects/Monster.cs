
public class Monster : GameObject
{
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
        if (BulletHit)
        {
            Health.Value --;
            if (Health.Value <= 0)
            {
                Monster.Die();
            }
        }
    }

    public void Die()
    {
        IsActiveControl = false;
        Monster.Remove(this);
    }




}