using UnityEngine;

public class StateMachine : MonoBehaviour
{
   public State currentState { get; private set; }

   public void Initialize(State startingState)
   {
      currentState = startingState;
      currentState.Enter();
   }

   // 用來切換狀態的方法
   public void ChangeState(State newState)
   {
      // 先呼叫當前狀態的 Exit 方法
      currentState.Exit();

      // 更新當前狀態為新狀態
      currentState = newState;
        
      // 呼叫新狀態的 Enter 方法
      newState.Enter();
   }
   
   // 在 Unity 的 Update 中，持續呼叫當前狀態的 Update 方法
   private void Update()
   {
      if (currentState != null)
      {
         currentState.Update();
      }
   }
}
