using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PIMDesktopProjectDTO;
using PIMDesktopProjectBLL;
using System.Drawing;

namespace PIMDesktopProject
{
    public partial class FrmChangePassword : Form
    {
        bool isCPF = true;
        Color principal = ColorTranslator.FromHtml("black");
        public FrmChangePassword()
        {
            InitializeComponent();
            btnChangePass.BackColor = btnClean.BackColor = btnFind.BackColor = btnGeneratePass.BackColor =
                pnlTop.BackColor = ColorTranslator.FromHtml("#FFCF6D");
        }

        private void btnGeneratePass_Click(object sender, EventArgs e)
        {
            txtGeneratedPass.Text = HelperBLL.Code(10);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string doc = txtDocFind.Text,
            Error = string.Empty;

            if (doc.Length == 11)//TAMANHO DO CPF
            {
                if (NaturalPerson.VerifyCPF(doc))
                {
                    isCPF = true;
                    if (NaturalPersonBLL.HasCPF(doc))
                    {
                        var person = NaturalPersonBLL.GetUserByCPF(doc);

                        txtName.Text = person.Nome;
                        txtDoc.Text = person.CPF;
                        txtPass.Text = txtConfirmPass.Text = txtGeneratedPass.Text = string.Empty;

                        btnChangePass.Enabled = true;
                    }
                    else
                    {
                        Error += "CPF não encontrado na base de dados.";
                    }
                }
                else
                {
                    Error += "CPF Inválido.";
                }
            }
            else
            {
                if (doc.Length == 14)//TAMANHO DO CNPJ
                {
                    if (LegalPerson.VerifyCNPJ(doc))
                    {
                        isCPF = false;
                        if (LegalPersonBLL.HasCNPJ(doc))
                        {
                            var person = LegalPersonBLL.GetUserByCNPJ(doc);

                            txtName.Text = person.NomeFantasia;
                            txtDoc.Text = person.CNPJ;
                            txtPass.Text = txtConfirmPass.Text = txtGeneratedPass.Text = string.Empty;

                            btnChangePass.Enabled = true;
                        }
                        else
                        {
                            Error += "CNPJ não encontrado na base de dados.";
                        }
                    }
                    else
                    {
                        Error += "CNPJ Inválido.";
                    }
                }
                else
                {
                    //NÃO É NEM CPF NEM CNPJ
                    Error += "Não é um CPF ou CNPJ válido.";
                }
            }

            if (!(string.IsNullOrEmpty(Error)) && !(string.IsNullOrWhiteSpace(Error)))
            {
                MessageBox.Show(Error);
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            List<TextVerifyDTO> textVerify = new List<TextVerifyDTO>();

            string Error = string.Empty;

            if (isCPF)
            {
                var user = new NaturalPerson
                (
                    txtDoc.Text,
                    txtPass.Text
                );

                textVerify.Add(new TextVerifyDTO(user.Senha, "Senha", 5, 10));

                foreach (string erro in TelaDeCadastro.NullOrEmpty(textVerify))
                {
                    Error += erro + "\n";
                }

                if (txtPass.Text.Length >= 5 && txtPass.Text != txtConfirmPass.Text)
                    Error += "A senha confirmada está divergente da digitada no campo 'Senha'.\n";

                if (string.IsNullOrEmpty(Error) || string.IsNullOrWhiteSpace(Error))
                {
                    if (NaturalPersonBLL.UpdatePass(user))
                    {
                        MessageBox.Show("A senha foi alterada com sucesso.", "Senha Alterada");
                        btnClean_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro e a senha não foi alterada. Entrar em contato com o Administrador caso o erro persista.", "Senha não alterada");
                        btnClean_Click(sender, e);
                    }
                }
                else MessageBox.Show(Error);
            }
            else
            {
                var user = new LegalPerson
                (
                    txtDoc.Text,
                    txtPass.Text
                );

                textVerify.Add(new TextVerifyDTO(user.Senha, "Senha", 5, 10));

                foreach (string erro in TelaDeCadastro.NullOrEmpty(textVerify))
                {
                    Error += erro + "\n";
                }

                if (txtPass.Text.Length >= 5 && txtPass.Text != txtConfirmPass.Text)
                    Error += "A senha confirmada está divergente da digitada no campo 'Senha'.\n";

                if (string.IsNullOrEmpty(Error) || string.IsNullOrWhiteSpace(Error))
                {
                    if (LegalPersonBLL.UpdatePass(user))
                    {
                        MessageBox.Show("A senha foi alterada com sucesso.", "Senha Alterada");
                        btnClean_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro e a senha não foi alterada. Entrar em contato com o Administrador caso o erro persista.", "Senha não alterada");
                        btnClean_Click(sender, e);
                    }
                }
                else MessageBox.Show(Error);
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtConfirmPass.Text = txtDoc.Text = txtGeneratedPass.Text = txtName.Text = txtPass.Text = "";
            btnChangePass.Enabled = false;
        }
    }
}
