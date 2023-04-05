﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;

namespace RPG.Dialogue.Editor
{ 
    public class DialogueEditor : EditorWindow
    {
        
        Dialogue selectedDialogue = null;
        [NonSerialized]
        GUIStyle nodeStyle;
        [NonSerialized]
        GUIStyle playerNodeStyle;
        [NonSerialized]
        DialogueNode draggingNode = null;
        [NonSerialized]
        private Vector2 draggingOffset;
        [NonSerialized]
        DialogueNode creatingNode = null;
        [NonSerialized]
        DialogueNode deletingNode = null;
        [NonSerialized]
        DialogueNode linkingParentNode = null;
        Vector2 scrollPosition;
        [NonSerialized]
        bool draggingCanvas = false;
        [NonSerialized]
        Vector2 draggingCanvasOffset;

        private const float canvasSize = 4000f;
        const float backgroundSize = 50f;

        [MenuItem("Window/Dialogue Editor")]
        public static void ShowEditorWindow()
        {
            GetWindow(typeof(DialogueEditor), false, "Dialogue Editor");
        }

        [OnOpenAsset(1)]
        public static bool OnOpenAsset(int instanceID, int line)
        {
            if (EditorUtility.InstanceIDToObject(instanceID) is Dialogue dialogue) //si es tipo dialogue el q abrimos se abre la window
            {
                ShowEditorWindow();
                return true;
            }

            return false;
        }

        private void OnEnable()
        {
            Selection.selectionChanged += OnSelectionChange; //we are addiong the function to a list to call it when selectionchanged

            nodeStyle = new GUIStyle();
            nodeStyle.normal.background = EditorGUIUtility.Load("node0") as Texture2D;
            nodeStyle.normal.textColor = Color.white;
            nodeStyle.padding = new RectOffset(20, 20, 20, 20);
            nodeStyle.border = new RectOffset(12, 12, 12, 12);

            playerNodeStyle = new GUIStyle();
            playerNodeStyle.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
            playerNodeStyle.normal.textColor = Color.white;
            playerNodeStyle.padding = new RectOffset(20, 20, 20, 20);
            playerNodeStyle.border = new RectOffset(12, 12, 12, 12);
        }

        private void OnSelectionChange()
        {
            Dialogue newDialogue = Selection.activeObject as Dialogue;
            if(newDialogue != null)
            {                   
                selectedDialogue = newDialogue;
                Repaint();
            }
        }

        //callback methods by name; update, start, onenable
        //annotation type; menuitem, onopenasset
        //events; inventory.inventoryupdated += redraw

        private void OnGUI()
        {


            if(selectedDialogue == null)
            {
                EditorGUILayout.LabelField("No dialogue selected");
            }
            else
            {
                ProcessEvents();

                scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
                Debug.Log(scrollPosition);

                Rect canvas = GUILayoutUtility.GetRect(canvasSize, canvasSize); //CREAMOS EL CANVAS
                Texture2D backgroundTex = Resources.Load("background") as Texture2D;
                Rect textCoords = new Rect(0, 0, canvasSize/ backgroundSize, canvasSize / backgroundSize);
                GUI.DrawTextureWithTexCoords(canvas, backgroundTex, textCoords);

                foreach (DialogueNode node in selectedDialogue.GetAllNodes())
                {
                   
                    DrawConnections(node);
                }
                foreach (DialogueNode node in selectedDialogue.GetAllNodes())
                {
                    DrawNode(node);
                   
                }

                EditorGUILayout.EndScrollView();

                if (creatingNode != null)
                {
                   
                    selectedDialogue.CreateNode(creatingNode);
                    creatingNode = null;
                }
                if(deletingNode != null)
                {
                   
                    selectedDialogue.DeleteNode(deletingNode);
                    deletingNode = null;
                }
            }

            
        }

        
        private void ProcessEvents()
        {
            EditorGUI.BeginChangeCheck();
            if (Event.current.type == EventType.MouseDown && draggingNode == null)
            {
                draggingNode = GetNodeAtPoint(Event.current.mousePosition + scrollPosition);
                if(draggingNode != null)
                {
                    draggingOffset = draggingNode.GetRect().position - Event.current.mousePosition;
                    Selection.activeObject = draggingNode;
                }
                else
                {
                    draggingCanvas = true;
                    draggingCanvasOffset = Event.current.mousePosition + scrollPosition;
                    Selection.activeObject = selectedDialogue;
                }
            }
            else if (Event.current.type == EventType.MouseDrag && draggingNode != null)
            {
                
                draggingNode.SetPosition(Event.current.mousePosition + draggingOffset);
               
                GUI.changed = true; //like repaint()

            }
            else if (Event.current.type == EventType.MouseDrag && draggingCanvas)
            {
                scrollPosition = draggingCanvasOffset - Event.current.mousePosition;

                GUI.changed = true;
            }

            else if(Event.current.type == EventType.MouseUp && draggingNode != null)
            {
                draggingNode = null;
            }
            else if (Event.current.type == EventType.MouseUp && draggingCanvas)
            {
                draggingCanvas = false;
            }

        }


        private void DrawNode(DialogueNode node)
        {
            GUIStyle style = nodeStyle;
            if(node.IsPlayerSpeaking())
            {
                style = playerNodeStyle;
            }
            GUILayout.BeginArea(node.GetRect(), style);
            EditorGUI.BeginChangeCheck();
            node.SetText(EditorGUILayout.TextField(node.GetText()));
            
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("x"))
            {
                deletingNode = node;
            }

            DrawLinkButtons(node);

            if (GUILayout.Button("+"))
            {
                creatingNode = node;

            }


            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        private void DrawLinkButtons(DialogueNode node)
        {
            if (linkingParentNode == null)
            {
                if (GUILayout.Button("link"))
                {
                    linkingParentNode = node;
                }
            }
            else if(linkingParentNode == node)
            {
                if (GUILayout.Button("cancel"))
                {
                    linkingParentNode = null;
                }
            }
            else if(linkingParentNode.GetChildren().Contains(node.name))
            {
                if (GUILayout.Button("unlink"))
                {
                    linkingParentNode.RemoveChild(node.name);
                    linkingParentNode = null;
                }

            }
            else
            {
                if (GUILayout.Button("child"))
                {
                    linkingParentNode.AddChild(node.name);
                    linkingParentNode = null;
                }
            }
        }

        private void DrawConnections(DialogueNode node)
        {
            Vector3 startPosition = new Vector2(node.GetRect().xMax, node.GetRect().center.y);
            
            foreach (var childNode in selectedDialogue.GetAllChildren(node))
            {
                Vector3 endPosition = new Vector2(childNode.GetRect().xMin, childNode.GetRect().center.y);
                Vector3 controlPointOffset = endPosition - startPosition;
                controlPointOffset.y = 0;
                controlPointOffset.x *= 0.8f;
                Handles.DrawBezier(startPosition, endPosition, 
                    startPosition + controlPointOffset, 
                    endPosition - controlPointOffset, 
                    Color.white, null, 4f);
            }
        }


        private DialogueNode GetNodeAtPoint(Vector2 point)
        {
            DialogueNode foundNode = null;
            foreach (var node in selectedDialogue.GetAllNodes())
            {
                if(node.GetRect().Contains(point))
                {
                    foundNode = node;
                }              
                
            }
            return foundNode;
        }
    }

}