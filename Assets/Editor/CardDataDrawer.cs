using QuizNumbersLetters.Cards;
using QuizNumbersLetters.Cards.Data;
using UnityEditor;
using UnityEngine;

namespace QuizNumbersLetters.Editor
{
    [CustomPropertyDrawer(typeof(CardData))]
    public class CardDataDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalHeight = EditorGUIUtility.singleLineHeight;

            if (property.isExpanded)
            {
                totalHeight += EditorGUIUtility.singleLineHeight * 3;

                var shouldStartRotated = property.FindPropertyRelative("_shouldStartRotated");
                if (shouldStartRotated.boolValue)
                {
                    totalHeight += EditorGUIUtility.singleLineHeight;
                }

                totalHeight += EditorGUIUtility.standardVerticalSpacing * 4;
            }

            return totalHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.isExpanded = EditorGUI.Foldout(
                new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
                property.isExpanded,
                label
            );

            if (!property.isExpanded)
            {
                return;
            }

            EditorGUI.indentLevel++;

            var identifierProperty = property.FindPropertyRelative("_identifier");
            EditorGUI.PropertyField(
                new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight),
                identifierProperty
            );

            var spriteProperty = property.FindPropertyRelative("_sprite");
            EditorGUI.PropertyField(
                new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 2, position.width, EditorGUIUtility.singleLineHeight),
                spriteProperty
            );

            var shouldStartRotatedProperty = property.FindPropertyRelative("_shouldStartRotated");
            EditorGUI.PropertyField(
                new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 3, position.width, EditorGUIUtility.singleLineHeight),
                shouldStartRotatedProperty
            );

            if (shouldStartRotatedProperty.boolValue)
            {
                var degreesToRotateProperty = property.FindPropertyRelative("_degreesToRotate");
                EditorGUI.PropertyField(
                    new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 4, position.width, EditorGUIUtility.singleLineHeight),
                    degreesToRotateProperty
                );
            }

            EditorGUI.indentLevel--;
        }
    }
}
