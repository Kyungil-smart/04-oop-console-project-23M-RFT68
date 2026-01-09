using System.Diagnostics;

public class LogScene : Scene
{
   public override void Update()
   {
      if (InputManager.GetKey(ConsoleKey.Enter))
      {
         SceneManager.ChangePrevScene();
      }
   }

   public override void Render()
   {
      Debug.Render();
   }

   public override void Exit() { }
   public override void Enter() { }
}