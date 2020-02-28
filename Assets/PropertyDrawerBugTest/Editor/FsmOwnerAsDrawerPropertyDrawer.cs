
using UnityEngine;
using UnityEditor;
using HutongGames.PlayMakerEditor;

namespace HutongGames.PlayMaker.Actions
{
    [PropertyDrawer(typeof(FsmOwnerAsDrawer))]
    public class FsmOwnerAsDrawerPropertyDrawer : PlayMakerEditor.PropertyDrawer
    {
        public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes)
        {

            FsmOwnerAsDrawer _class = obj as FsmOwnerAsDrawer;
            if (_class == null)
            {
                EditorGUILayout.HelpBox("FsmOwnerAsDrawer == null", MessageType.Error);
                return null;
            }
            
            EditField("gameObject", _class.gameObject, attributes);

            GUILayout.Label("Now comes the myEvent editField");
            EditField("myEvent", _class.myEvent, attributes);

            

            return obj;
        }
    }
}