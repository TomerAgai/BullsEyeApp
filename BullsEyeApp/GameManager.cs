using System.Windows.Forms;

namespace BullsEyeApp
{ 
    internal class GameManager
    {
        public static void RunGame()
        {
            SettingsForm settingsForm = new SettingsForm();
            GameForm gameForm;
            
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                gameForm = new GameForm(settingsForm);
                gameForm.ShowDialog();
            }
        }
    }
}