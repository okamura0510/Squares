using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Squares
{
    /// <summary>
    /// エディタで閲覧可能(変更不可)にする属性。エディタで値を確認したいけど変更はさせたくない用途に使用。
    /// </summary>
    public class ReadOnlyAttribute : PropertyAttribute { }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.PropertyField(position, property, label);
            EditorGUI.EndDisabledGroup();
        }
    }
#endif
}