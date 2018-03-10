using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SmoothSineMovement))]
public class SineMovementEditor : Editor {

    SmoothSineMovement m_target;

    public override void OnInspectorGUI()
    {
        m_target = (SmoothSineMovement) target;

        DrawDefaultInspector();
        DrawMovementInspector();
    }

    void DrawMovementInspector()
    {
        GUILayout.Space(5);
        GUILayout.Label("Sine-Curve Based Movements", EditorStyles.boldLabel);

        for(int i = 0; i < m_target.movements.Count; i++)
        {
            DrawColumn(i);
        }

        if (GUILayout.Button("Add movement", GUILayout.Height(18))) {
            Undo.RecordObject(m_target, "Add Movement");
            m_target.movements.Add(new SineMovement { axis=Axis.NONE, amplitude=0.01F, frequency=1F, x=0, absolute=false, infinite=false, min=-10000 });
            EditorUtility.SetDirty(m_target);
        }
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();

        /*
        if (GUILayout.Button("Reload GameObject (Ingame)", GUILayout.Height(18)))
        {
            m_target.dirty = true;
            EditorUtility.SetDirty(m_target);
        }
        */
    }

    void DrawColumn(int i)
    {
        if (i < 0 || i >= m_target.movements.Count)
            return;

        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        GUILayout.BeginHorizontal();
        
        EditorGUI.BeginChangeCheck();
        
        Axis axis = (Axis)EditorGUILayout.EnumPopup("Axis", m_target.movements[i].axis);
        
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        float min = EditorGUILayout.FloatField("Min. Amplitude", m_target.movements[i].min);

        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        float amplitude = EditorGUILayout.FloatField("Max. Amplitude", m_target.movements[i].amplitude);

        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        float frequency = EditorGUILayout.FloatField("Frequency", m_target.movements[i].frequency);

        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        float x = EditorGUILayout.FloatField("X Modifier", m_target.movements[i].x);

        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        bool absolute = EditorGUILayout.Toggle("Absolute", m_target.movements[i].absolute);

        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        bool infinite = EditorGUILayout.Toggle("No Negatives", m_target.movements[i].infinite);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(m_target, "Modify Movement");

            m_target.movements[i].axis = axis;
            m_target.movements[i].amplitude = amplitude;
            m_target.movements[i].frequency = frequency;
            m_target.movements[i].x = x;
            m_target.movements[i].absolute = absolute;
            m_target.movements[i].infinite = infinite;
            m_target.movements[i].min = min;

            if (!(m_target.movements[i].axis.Equals(Axis.NONE) && axis.Equals(Axis.NONE)))
            {
                m_target.dirty = true;
            }

            EditorUtility.SetDirty(m_target);
        }

        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Delete", GUILayout.Height(16)))
        {
            Undo.RecordObject(m_target, "Delete Movement");
            m_target.movements.RemoveAt(i);
            m_target.dirty = true;
            EditorUtility.SetDirty(m_target);
        }
        if (GUILayout.Button("Copy", GUILayout.Height(16)))
        {
            Undo.RecordObject(m_target, "Copy Movement");
            m_target.movements.Add(new SineMovement { axis = axis, amplitude = amplitude, frequency = frequency, x = x, absolute = absolute, infinite = infinite, min = min });
            m_target.dirty = true;
            EditorUtility.SetDirty(m_target);
        }

        GUILayout.EndHorizontal();

        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
    }
}
