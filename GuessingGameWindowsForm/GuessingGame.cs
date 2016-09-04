using System;
using System.Windows.Forms;



namespace GuessingGameWindowsForm
{

    enum GameState { StartingGame, GuessingQuestion, GuessingAnimal, GettingNewAnimal, GettingNewTrait, ComputerWins };

    public partial class GuessingGame : Form
    {       

        GameState gameState = GameState.StartingGame;
        static BTTree tree;
        static BTNode currentNode;
        string animal = string.Empty;
        string trait = string.Empty;
         

        public GuessingGame()
        {
            InitializeComponent();
        }
        
        private void GuessingGame_Load(object sender, EventArgs e)
        {

            //Initializes the tree with the question lives in water and the options shark(yes) and monkey(no)
            tree = new BTTree("lives in water", "shark", "monkey");
            currentNode = tree.getRootNode();
            updateFieldsVisibility();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {

            if (gameState == GameState.GettingNewAnimal )
            {
                btnOkayGettingNewAnimal();
                return;

            }
            if (gameState == GameState.GettingNewTrait)
            {
                btnOkayNewTraitAndUpdateBTTree();
                return;
            }

            if (gameState == GameState.ComputerWins)
            {
                btnOkayComputerWins();
                return;
            }
            
            updateGameStatus();
            
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            //Computer wins in case player press yes on a animal node
            if (gameState == GameState.GuessingAnimal)
            {
                gameLabel.Text = "I win again!";
                gameState = GameState.ComputerWins;
                updateFieldsVisibility();
            }

            else
            {
                currentNode = currentNode.getYesNode();
                updateGameStatus();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (gameState == GameState.GuessingAnimal)
            {
                gameLabel.Text = "What was the animal you thought about?";
                gameState = GameState.GettingNewAnimal;
                updateFieldsVisibility();

            }

            else
            {
                currentNode = currentNode.getNoNode();
                updateGameStatus();
            }
        }

        private void btnOkayGettingNewAnimal()
        {
            animal = textBox.Text.ToString();
            textBox.Clear();

            gameLabel.Text = "A " + animal + " ________ but a " + currentNode.getMessage() + " does not\n"
                + "(Fill it with an animal trait, like 'lives in water').";

            gameState = GameState.GettingNewTrait;
            updateFieldsVisibility();

        }

        private void btnOkayNewTraitAndUpdateBTTree()
        {
            //Update BTTree with new nodes
            trait = textBox.Text.ToString();
            currentNode.updateTree(animal, trait);

            //Reset and Restart the game with new information
            animal = string.Empty;
            trait = string.Empty;
            textBox.Clear();
            gameLabel.Text = "Think about an animal...";
            currentNode = tree.getRootNode();
            gameState = GameState.StartingGame;
            updateFieldsVisibility();

        }

        private void btnOkayComputerWins()
        {
 
            //Reset and Restart the game with new information
            gameLabel.Text = "Think about an animal...";
            currentNode = tree.getRootNode();
            gameState = GameState.StartingGame;
            updateFieldsVisibility();

        }

        private void updateFieldsVisibility()
        {
            switch (gameState)
            {
                case GameState.StartingGame:
                    btnNo.Visible = false;
                    btnYes.Visible = false;
                    btnCancel.Visible = true;
                    btnOkay.Visible = true;
                    textBox.Visible = false;
                    break;

                case GameState.GuessingQuestion:
                case GameState.GuessingAnimal:
                    btnNo.Visible = true;
                    btnYes.Visible = true;
                    btnCancel.Visible = false;
                    btnOkay.Visible = false;
                    textBox.Visible = false;
                    break;

                case GameState.GettingNewAnimal:
                case GameState.GettingNewTrait:
                    btnNo.Visible = false;
                    btnYes.Visible = false;
                    btnCancel.Visible = false;
                    btnOkay.Visible = true;
                    textBox.Visible = true;
                    textBox.Focus();
                    break;

                case GameState.ComputerWins:
                    btnNo.Visible = false;
                    btnYes.Visible = false;
                    btnCancel.Visible = false;
                    btnOkay.Visible = true;
                    textBox.Visible = false;
                    break;

                default:
                    btnNo.Visible = false;
                    btnYes.Visible = false;
                    btnCancel.Visible = true;
                    btnOkay.Visible = true;
                    break;

            }
        }

        private void updateGameStatus()
        {
            if (currentNode.isQuestion())
            {
                gameLabel.Text = "Does the animal that you thought about " + currentNode.getMessage() +"?";
                gameState = GameState.GuessingQuestion;
                updateFieldsVisibility();
            }
            else
            {
                gameLabel.Text = "Is the animal you thought about a " + currentNode.getMessage() + "?";
                gameState = GameState.GuessingAnimal;
                updateFieldsVisibility();
            }
        }   

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
