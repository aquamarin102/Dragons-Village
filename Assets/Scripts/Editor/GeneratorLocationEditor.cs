using Scripts.Location_Generator;
using UnityEditor;
using UnityEngine;


namespace Scripts.Editor
{

[CustomEditor(typeof(GeneratorLocationView))]
    public class GeneratorLocationEditor : UnityEditor.Editor
    {
        private GeneratorLocationController _generatorLocationController;

        private void OnEnable()
        {
            var generatorLocationView = (GeneratorLocationView)target;
            _generatorLocationController = new GeneratorLocationController(generatorLocationView);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var tileMap = serializedObject.FindProperty("_tilemapGround");
            EditorGUILayout.PropertyField(tileMap);
            
            if (GUI.Button(new Rect(10, 0, 60, 50), "Generate"))
            {
                _generatorLocationController.Awake();
            }

            if (GUI.Button(new Rect(10, 55, 60, 50), "Clear"))
            {
                _generatorLocationController.ClearTileMap();
            }
            
            GUILayout.Space(100);
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}