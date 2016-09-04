using System;

namespace GuessingGameWindowsForm
{
    [Serializable]
    class BTNode
    {
        string message;
        BTNode noNode;
        BTNode yesNode;
        /**
         * Constructor for the nodes: This class holds an String representing 
         * an object if the noNode and yesNode are null and a question if the
         * yesNode and noNode point to a BTNode.
         */
        public BTNode(string nodeMessage)
        {
            message = nodeMessage;
            noNode = null;
            yesNode = null;
        }
             
        //Add the new questions as the current node and create new child nodes with the 
        //new animal User answer as the yes node and the old animal as the no node
        public void updateTree(string animal, string trait)
        {
            this.noNode = new BTNode(this.message);
            this.yesNode = new BTNode(animal);

            this.setMessage(trait);
        }


        public bool isQuestion()
        {
            if (noNode == null && yesNode == null)
                return false;
            else
                return true;
        }
        
        public void setMessage(string nodeMessage)
        {
            message = nodeMessage;
        }

        public string getMessage()
        {
            return message;
        }

        public void setNoNode(BTNode node)
        {
            noNode = node;
        }

        public BTNode getNoNode()
        {
            return noNode;
        }

        public void setYesNode(BTNode node)
        {
            yesNode = node;
        }
        public BTNode getYesNode()
        {
            return yesNode;
        }
    }
}
