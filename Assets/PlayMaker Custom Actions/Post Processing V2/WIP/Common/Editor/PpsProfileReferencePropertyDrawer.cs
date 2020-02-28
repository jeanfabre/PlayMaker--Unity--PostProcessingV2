// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using UnityEngine;
using UnityEditor;
using HutongGames.PlayMakerEditor;

namespace HutongGames.PlayMaker.PostProcessing.Actions
{
    [PropertyDrawer(typeof(PpsProfileReferenceProperty))]
    public class PpsProfileReferencePropertyDrawer : PlayMakerEditor.PropertyDrawer
    {
        public override object OnGUI(GUIContent label, object obj, bool isSceneObject, params object[] attributes)
        {
            PpsProfileReferenceProperty _class = obj as PpsProfileReferenceProperty;
            if (_class == null)
            {
                EditorGUILayout.HelpBox("PpsReferenceProperty = null", MessageType.Error);
                return null;
            }

            EditorGUI.indentLevel++;

            EditField("reference", _class.reference, attributes);

            EditorGUI.indentLevel++;
  

            PpsProfileReferenceProperty.PpsReferences _ref = _class.reference;

            if (_ref == PpsProfileReferenceProperty.PpsReferences.FromAsset)
            {
                EditField("profile", _class.profile, attributes);
            }
            
            if (_ref == PpsProfileReferenceProperty.PpsReferences.FromVolume)
            {
                EditField("gameObject", _class.gameObject, attributes);
            }

            EditorGUI.indentLevel--;

            EditField("profileNotFound", _class.profileNotFound, attributes);

            EditorGUI.indentLevel--;

            return obj;
        }
    }
}