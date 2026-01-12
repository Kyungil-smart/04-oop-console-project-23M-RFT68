public class Potion : Item, IInteractable
{
    public Potion() => Init();
    
    private void Init()
    {
        Symbol = 'H';
    }
    
    public override void Use()  // override가 재정의를 못하고 있음
    {
        base.Use();
        Owner.Heal(1);
        
        Inventory.Remove(this);
        Inventory = null;
        Owner = null;
        
        Debug.Log("포션 사용");
        // 효과~~
    }

    public void Interact(PlayerCharacter player)
    {
        // 상호작용?
        // 뭔지는 모르겠지만
        // 일단 뭔가는 해야함
        // => 플레이어가 가진 인벤토리에 자신을 추가

        player.AddItem(this);
    }
}

// virtual 상속
// abstract 추상클래스가 의미하는게 무엇인지
// Interface 까지 연계 해서 복습