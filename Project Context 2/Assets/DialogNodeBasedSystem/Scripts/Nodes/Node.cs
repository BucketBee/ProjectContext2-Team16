using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace cherrydev
{
    public class Node : ScriptableObject
    {
        [HideInInspector] public List<Node> connectedNodesList;
        [HideInInspector] public DialogNodeGraph nodeGraph;
        [HideInInspector] public Rect rect = new Rect();

        [HideInInspector] public bool isDragging;
        [HideInInspector] public bool isSelected;

        protected float standartHeight;

#if UNITY_EDITOR

        /// <summary>
        /// Base initialisation method
        /// </summary>
        /// <param _name="rect"></param>
        /// <param _name="nodeName"></param>
        /// <param _name="nodeGraph"></param>
        public virtual void Initialise(Rect rect, string nodeName, DialogNodeGraph nodeGraph)
        {
            name = nodeName;
            standartHeight = rect.height;
            this.rect = rect;
            this.nodeGraph = nodeGraph;
        }

        /// <summary>
        /// Base draw method
        /// </summary>
        /// <param _name="nodeStyle"></param>
        /// <param _name="lableStyle"></param>
        public virtual void Draw(GUIStyle nodeStyle, GUIStyle lableStyle)
        { }

        public virtual bool AddToParentConnectedNode(Node nodeToAdd)
        { return true; }

        public virtual bool AddToChildConnectedNode(Node nodeToAdd)
        { return true; }

        /// <summary>
        /// Process node events
        /// </summary>
        /// <param _name="currentEvent"></param>
        public void ProcessNodeEvents(Event currentEvent)
        {
            switch (currentEvent.type)
            {
                case EventType.MouseDown:
                    ProcessMouseDownEvent(currentEvent);
                    break;

                case EventType.MouseUp:
                    ProcessMouseUpEvent(currentEvent);
                    break;

                case EventType.MouseDrag:
                    ProcessMouseDragEvent(currentEvent);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Process node mouse down event
        /// </summary>
        /// <param _name="currentEvent"></param>
        private void ProcessMouseDownEvent(Event currentEvent)
        {
            if (currentEvent.button == 0)
            {
                ProcessLeftMouseDownEvent(currentEvent);
            }
            else if (currentEvent.button == 1)
            {
                ProcessRightMouseDownEvent(currentEvent);
            }
        }

        /// <summary>
        /// Process node left click event
        /// </summary>
        /// <param _name="currentEvent"></param>
        private void ProcessLeftMouseDownEvent(Event currentEvent)
        {
            OnNodeLeftClick();
        }

        /// <summary>
        /// Process node right click down event
        /// </summary>
        /// <param _name="currentEvent"></param>
        private void ProcessRightMouseDownEvent(Event currentEvent)
        {
            nodeGraph.SetNodeToDrawLineFromAndLinePosition(this, currentEvent.mousePosition);
        }

        /// <summary>
        /// Process node mouse up event
        /// </summary>
        /// <param _name="currentEvent"></param>
        private void ProcessMouseUpEvent(Event currentEvent)
        {
            if (currentEvent.button == 0)
            {
                ProcessLeftMouseUpEvent(currentEvent);
            }
        }

        /// <summary>
        /// Process node left click up event
        /// </summary>
        /// <param _name="currentEvent"></param>
        private void ProcessLeftMouseUpEvent(Event currentEvent)
        {
            isDragging = false;
        }

        /// <summary>
        /// Process node mouse drag event
        /// </summary>
        /// <param _name="currentEvent"></param>
        private void ProcessMouseDragEvent(Event currentEvent)
        {
            if (currentEvent.button == 0)
            {
                ProcessLeftMouseDragEvent(currentEvent);
            }
        }

        /// <summary>
        /// Process node left mouse drag event
        /// </summary>
        /// <param _name="currentEvent"></param>
        private void ProcessLeftMouseDragEvent(Event currentEvent)
        {
            isDragging = true;
            DragNode(currentEvent.delta);
            GUI.changed = true;
        }

        /// <summary>
        /// Select and unselect node
        /// </summary>
        public void OnNodeLeftClick()
        {
            Selection.activeObject = this;

            if (isSelected)
            {
                isSelected = false;
            }
            else
            {
                isSelected = true;
            }
        }

        /// <summary>
        /// Drag node
        /// </summary>
        /// <param _name="delta"></param>
        public void DragNode(Vector2 delta)
        {
            rect.position += delta;
            EditorUtility.SetDirty(this);
        }
#endif
    }
}