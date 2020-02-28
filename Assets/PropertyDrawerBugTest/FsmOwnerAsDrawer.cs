using System;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public class FsmOwnerAsDrawer
    {
        public FsmOwnerDefault gameObject;
        
        public FsmEvent myEvent;
        
        public FsmOwnerAsDrawer()
        {
            gameObject = new FsmOwnerDefault();
            myEvent = null;
        }
    }
}