

namespace HutongGames.PlayMaker.Actions
{
  
    public class FsmOwnerAsDrawerAction : FsmStateAction
    {
        public FsmOwnerAsDrawer Test;

        public override void Reset()
        {
            Test = new FsmOwnerAsDrawer();
        }
    }
}