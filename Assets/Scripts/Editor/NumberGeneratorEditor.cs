using com.ozave.numbergenerator.enums;
using com.ozave.numbergenerator.generator;
using System;
using UnityEditor;
using UnityEngine;

namespace com.ozave.numbergenerator.editor
{
    [CustomEditor(typeof(NumberGenerator))]
    public class NumberGeneratorEditor : Editor
    {
        #region Fields

        private NumberGenerator NumberGenerator;
        private GenericMenu menu;
        private NumberOptions selected = NumberOptions.CONSTANT;

        #endregion

        private void OnEnable()
        {
            NumberGenerator = target as NumberGenerator;
            selected = NumberGenerator.Selected;

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawDefaultInspector();

            GUILayout.BeginHorizontal();

            menu = new GenericMenu();
            AddItem(menu, "Constant", NumberOptions.CONSTANT);
            AddItem(menu, "Random Number between Two Constant", NumberOptions.CONSTANT_BETWEEN_TWO_NUMBER);

            CreateNumberField(NumberGenerator.Selected);

            if(EditorGUILayout.DropdownButton(new GUIContent() { text="" }, FocusType.Keyboard, GUILayout.MaxWidth(20f)))
            {
                menu.ShowAsContext();
            }

            GUILayout.EndHorizontal();
        }

        private void AddItem(GenericMenu menu, string name, NumberOptions type)
        {
            if(menu != null)
                menu.AddItem(new GUIContent() { text = name }, selected.Equals(type), OnMenuSelected, type);
        }

        private void OnMenuSelected(object type)
        {
            selected = NumberGenerator.Selected = (NumberOptions)type;
            CreateNumberField(NumberGenerator.Selected);
        }

        private void CreateNumberField(NumberOptions selected)
        {
            try
            {
                switch (selected)
                {
                    case NumberOptions.CONSTANT:
                        NumberGenerator.Number = EditorGUILayout.FloatField("", NumberGenerator.Number, GUILayout.ExpandWidth(true));
                        EditorUtility.SetDirty(target);
                        break;
                    case NumberOptions.CONSTANT_BETWEEN_TWO_NUMBER:
                        NumberGenerator.Number = GetRandomNumber();
                        EditorUtility.SetDirty(target);
                        break;
                }
            }catch(Exception e)
            {
                Debug.LogWarning(e);
            }
            
        }

        private float GetRandomNumber()
        {
            //GUILayout.BeginHorizontal();

            NumberGenerator.number1 = EditorGUILayout.FloatField("", NumberGenerator.number1, GUILayout.ExpandWidth(true), GUILayout.MinWidth(10f));
            NumberGenerator.number2 = EditorGUILayout.FloatField("", NumberGenerator.number2, GUILayout.ExpandWidth(true), GUILayout.MinWidth(10f));

            //GUILayout.EndHorizontal();

            if(NumberGenerator.number1 > NumberGenerator.Number)
                return UnityEngine.Random.Range(NumberGenerator.number2, NumberGenerator.number1 + 1);

            return UnityEngine.Random.Range(NumberGenerator.number1, NumberGenerator.number2 + 1);
        }
    } 
}
