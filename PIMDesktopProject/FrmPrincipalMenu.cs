using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIMDesktopProject
{
    public partial class FrmPrincipalMenu : Form
    {
        Point lastPoint;
        Color selected = ColorTranslator.FromHtml("#FFCF6D"),
            Unselected = ColorTranslator.FromHtml("#606060");
        public NotifyIcon ico = new NotifyIcon();

        public FrmPrincipalMenu()
        {
            InitializeComponent();
            /*COLOR*/
            leftPanel.BackColor = tsmChangePass.BackColor = tsmRegisterUser.BackColor =
                tsmUpdateUser.BackColor = tsQuit.BackColor = menuStrip1.BackColor =
                menuStrip2.BackColor = ColorTranslator.FromHtml("black");
            btnMinimize.BackColor = selected;

            topPanel.BackColor = ColorTranslator.FromHtml("#EBB03B");

            /*-------------*/

            ChangePanelForm<TelaDeCadastro>(tsmRegisterUser);

            ico.Text = "Gerenciamento de Usuários";
            ico.Icon = Icon;//Ícone padrão do programa
            ico.MouseClick += ico_MouseClick;//Passando o método ico_MouseClick como método para o click sobre o icone
        }

        private void tsmChangePass_Click(object sender, EventArgs e)
        {
            ChangePanelForm<FrmChangePassword>(tsmChangePass);
        }
        private void tsmUpdateUser_Click(object sender, EventArgs e)
        {
            ChangePanelForm<FrmUpdateUserInfo>(tsmUpdateUser);
        }

        private void tsmRegisterUser_Click(object sender, EventArgs e)
        {
            ChangePanelForm<TelaDeCadastro>(tsmRegisterUser);
        }
        private void ChangePanelForm<T>(ToolStripItem tsi) where T : Form, new()
        {
            if (tsi.ForeColor != selected)
            {
                try
                {
                    foreach (ToolStripItem ts in menuStrip1.Items)
                    {
                        ts.ForeColor = Unselected;
                    }

                    foreach (Control control in panelContent.Controls)
                    {
                        control.Visible = false;
                    }

                    var frm = Application.OpenForms[typeof(T).Name] as T;

                    if (frm == null) frm = new T();

                    frm.TopLevel = false;
                    panelContent.Controls.Add(frm);
                    panelContent.AutoScroll = false;

                    frm.StartPosition = FormStartPosition.Manual;
                    frm.Top = 0;
                    frm.Left = 0;

                    frm.Show();

                    tsi.ForeColor = selected;
                }
                catch { }
            }
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ico_MouseClick(object sender, EventArgs e)
        {
            //Caso haja click, o formulário volta ao seu tamanho normal
            ClientSize = new Size(1055, 637);
            Show();
            WindowState = FormWindowState.Normal;
            Left = (Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2);
            Top = (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2);

            TopMost = true;
            Focus();

            BringToFront();

            TopMost = false;
        }

        private void FrmPrincipalMenu_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                //O Ícone da bandeja fica visível
                ico.Visible = true;
                Hide();
            }
            //Caso o formulário volte ao normal...
            else if (FormWindowState.Normal == WindowState)
            {
                //O íncone fica invisível.
                ico.Visible = false;
                ShowInTaskbar = true;
            }
        }

        private void tsQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o sistema?", "Fechar o Sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
