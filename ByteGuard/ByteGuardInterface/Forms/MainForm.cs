using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.ByteGuardInterface.UserControls.MyAccount;
using ByteGuard.ByteGuardInterface.UserControls.MyLibrary;
using ByteGuard.ByteGuardInterface.UserControls.MyPrograms;
using ByteGuard.Properties;

namespace ByteGuard.ByteGuardInterface.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Stores the MainForm as a global variable so it can be accessed from other forms.
            Variables.Forms.Main = this;

            // Stores the MainForm theme container so it can be accessed from other forms.
            Variables.Containers.Main = ThemeContainer;
        }

        public int MyProgramsCount
        {
            get { return ListBoxMyPrograms.Items.Count; }
        }

        public int MyProgramSelectedIndex
        {
            get
            {
                int index = 0;
                if (ListBoxMyPrograms.InvokeRequired)
                {
                    ListBoxMyPrograms.Invoke((MethodInvoker) delegate { index = ListBoxMyPrograms.SelectedIndex; });
                }
                else
                {
                    index = ListBoxMyPrograms.SelectedIndex;
                }

                return index;
            }
        }

        public int MyLibrarySelectedIndex
        {
            get
            {
                int index = 0;
                if (ListBoxMyLibrary.InvokeRequired)
                {
                    ListBoxMyLibrary.Invoke((MethodInvoker) delegate { index = ListBoxMyLibrary.SelectedIndex; });
                }
                else
                {
                    index = ListBoxMyLibrary.SelectedIndex;
                }

                return index;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Sets the form icon.
            Icon = Resources.ByteGuardIcon;

            // Selects the 'Store' tab.
            TabControlMain.SelectedIndex = 3;

            Variables.UserControls.MyLibraryDefault = new MyLibraryDefault();
            Variables.UserControls.MyProgramsDefault = new MyProgramsDefault();
            Variables.UserControls.MyAccountDefault = new MyAccountDefault();

            // Adds the PopulatePrograms() function to the MyProgramsDefault .Load event.
            Variables.UserControls.MyProgramsDefault.Load += (closedSender, closedE) => PopulatePrograms(false);

            // Adds the MyProgramsDefault user control to the MyPrograms panel.
            PanelMyLibrary.Controls.Add(Variables.UserControls.MyLibraryDefault);
            PanelMyPrograms.Controls.Add(Variables.UserControls.MyProgramsDefault);
            PanelMyAccount.Controls.Add(Variables.UserControls.MyAccountDefault);
        }

        /// <summary>
        ///     Adds the users programs to the listbox located on the MainForm.
        /// </summary>
        /// <param name="isDeleted">If true, the function is called after a program has been deleted.</param>
        public void PopulatePrograms(bool isDeleted)
        {
            // Method variables.
            int selectedIndex = 0;

            // Checks if the function is being invoked.
            if (ListBoxMyPrograms.InvokeRequired)
            {
                // Method is being called from a different thread than the one it was created on.
                ListBoxMyPrograms.Invoke((MethodInvoker) delegate
                {
                    // Saves the current .SelectedIndex to return to it after. (If a file has been edited for example)
                    if (ListBoxMyPrograms.SelectedIndex != -1 && !isDeleted)
                        selectedIndex = ListBoxMyPrograms.SelectedIndex;

                    // Clears the MyPrograms listbox.
                    ListBoxMyPrograms.Items.Clear();

                    // Adds all the users programs to the MyPrograms listbox.
                    foreach (Variables.ByteGuardProgram byteguardProgram in Variables.MyPrograms.ToList())
                        ListBoxMyPrograms.Items.Add(byteguardProgram.IsAdmin
                            ? String.Format("[A] {0}", byteguardProgram.ProgramName)
                            : byteguardProgram.ProgramName);

                    // Checks if the user has any programs, if so, selects the first program and enables the controls for editing.
                    if (ListBoxMyPrograms.Items.Count > 0)
                    {
                        // Selects the first program in the listbox.
                        ListBoxMyPrograms.SelectedIndex = 0; // TODO: Remove this.

                        // Enables the 'Edit Program' button.
                        //Globals.Variables.UserControls.MyProgramsDefault.SetButtonState(true);
                    }

                    // Sets the .SelectedIndex to the previous .SelectedIndex.
                    if (ListBoxMyPrograms.SelectedIndex != -1) // TODO: Remove this.
                        ListBoxMyPrograms.SelectedIndex = selectedIndex;
                });
            }
            else
            {
                // Method is being called from the same thread it was created on.
                // Saves the current .SelectedIndex to return to it after. (If a file has been edited for example)
                if (ListBoxMyPrograms.SelectedIndex != -1)
                    selectedIndex = ListBoxMyPrograms.SelectedIndex;

                // Clears the MyPrograms listbox.
                ListBoxMyPrograms.Items.Clear();

                // Adds all the users programs to the MyPrograms listbox.
                foreach (Variables.ByteGuardProgram byteguardProgram in Variables.MyPrograms.ToList())
                    ListBoxMyPrograms.Items.Add(byteguardProgram.IsAdmin
                        ? String.Format("[A] {0}", byteguardProgram.ProgramName)
                        : byteguardProgram.ProgramName);

                // Checks if the user has any programs, if so, selects the first program and enables the controls for editing.
                if (ListBoxMyPrograms.Items.Count > 0)
                {
                    // Selects the first program in the listbox.
                    ListBoxMyPrograms.SelectedIndex = 0; // TODO: Remove this.

                    // Enables the 'Edit Program' button.
                    //Globals.Variables.UserControls.MyProgramsDefault.SetButtonState(true);
                }

                // Sets the .SelectedIndex to the previous .SelectedIndex.
                if (ListBoxMyPrograms.SelectedIndex != -1) // TODO: Remove this.
                    ListBoxMyPrograms.SelectedIndex = selectedIndex;
            }
        }

        public void PopulateLibrary()
        {
            // Method variables.
            int selectedIndex = 0;

            // Method is being called from a different thread than the one it was created on.
            ListBoxMyLibrary.Invoke((MethodInvoker) delegate
            {
                // Saves the current .SelectedIndex to return to it after. (If a file has been edited for example)
                if (ListBoxMyPrograms.SelectedIndex != -1)
                    selectedIndex = ListBoxMyPrograms.SelectedIndex;

                // Clears the MyPrograms listbox.
                ListBoxMyLibrary.Items.Clear();

                // Adds all the users programs to the MyPrograms listbox.
                foreach (Variables.ByteGuardProgram byteguardProgram in Variables.MyLibrary)
                    ListBoxMyLibrary.Items.Add(byteguardProgram.ProgramName);

                // Checks if the user has any programs, if so, selects the first program and enables the controls for editing.
                if (ListBoxMyLibrary.Items.Count > 0)
                {
                    // Selects the first program in the listbox.
                    ListBoxMyLibrary.SelectedIndex = 0; // TODO: Remove this.
                }

                // Sets the .SelectedIndex to the previous .SelectedIndex.
                if (ListBoxMyPrograms.SelectedIndex != -1) // TODO: Remove this.
                    ListBoxMyPrograms.SelectedIndex = selectedIndex;
            });
        }

        private void ListBoxMyPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Checks if the ManageProgram form is the current control and removes it if so.
            if (PanelMyPrograms.Controls[0] != Variables.UserControls.MyProgramsDefault)
            {
                // Removes the current user control.
                PanelMyPrograms.Controls.RemoveAt(0);

                // Adds the MyProgramsDefault user control to the MyPrograms panel.
                PanelMyPrograms.Controls.Add(Variables.UserControls.MyProgramsDefault);

                // Displays the selected program.
                Variables.UserControls.MyProgramsDefault.SelectProgram(ListBoxMyPrograms.SelectedIndex);

                Variables.Containers.Main.SetStatus("Create a new program or manage an existing one.", 3);
            }
            else
            {
                Variables.UserControls.MyProgramsDefault.SelectProgram(ListBoxMyPrograms.SelectedIndex);
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonRedeemProgram.Visible = false;

            switch (TabControlMain.SelectedIndex)
            {
                // MyAccount
                case 0:
                    // TODO: Multi-thread somehow.
                    Thread downloadAndDisplay =
                        new Thread(Variables.UserControls.MyAccountDefault.DownloadAndDisplayCurrentUser);
                    downloadAndDisplay.Start();
                    break;

                // MyPrograms
                case 1:
                    break;

                // MyLibrary
                case 2:
                    Variables.Containers.Main.SetStatus(
                        "View programs you have previously purchased or redeem a new license.", 3);
                    ButtonRedeemProgram.Visible = true;
                    break;

                // Store
                case 3:
                    Variables.Containers.Main.SetStatus(
                        "Store is not yet implemented, please visit: http://byteguardsoftware.co.uk/store", 3);
                    break;
            }
        }

        private void ListBoxMyLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            Variables.UserControls.MyLibraryDefault.SelectProgram(ListBoxMyLibrary.SelectedIndex);
        }

        private void ButtonRedeemProgram_Click(object sender, EventArgs e)
        {
            
        }
    }
}