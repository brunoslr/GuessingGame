namespace GuessingGameWindowsForm
{
    class BTTree
    {
        BTNode rootNode;
        public BTTree(string question, string yesGuess, string noGuess)
        {
            rootNode = new BTNode(question);
            rootNode.setYesNode(new BTNode(yesGuess));
            rootNode.setNoNode(new BTNode(noGuess));
        }

        public BTNode getRootNode()
        {
            return rootNode;
        }


    }
}