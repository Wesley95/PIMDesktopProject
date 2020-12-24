using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PIMDesktopProjectDTO;
using PIMDesktopProjectBLL;

namespace PIMDesktopProject
{
    public partial class TelaDeCadastro : Form
    {
        readonly Color Selected = ColorTranslator.FromHtml("#FFCF6D");
        readonly Color Unselected = ColorTranslator.FromHtml("#EEEEEE");

        readonly int left = 159, top = 48;
        //159; 48

        public TelaDeCadastro()
        {
            InitializeComponent();

            btnCadastrarCPF.BackColor = btnLimparCNPJ.BackColor = btnRegister.BackColor = button1.BackColor = Selected;
            btnCadastrarCPF.ForeColor = btnLimparCNPJ.ForeColor = btnRegister.ForeColor = button1.ForeColor = Color.White;
            pnlTop.BackColor = Selected;

            //tsPerson.BackColor = tsEnterpriseSignup.BackColor = Color.White;
            tsPerson.ForeColor = Selected;
            tsEnterpriseSignup.ForeColor = Unselected;
            pnlEnterprise.Visible = false;
            pnlPerson.Visible = true;
            pnlPerson.Left = left;
            pnlPerson.Top = top;

            dtpDateCNPJ.MaxDate = DateTime.Now;
            txtFundacaoData.Text = DateSelected(dtpDateCNPJ);

            dtpDataNascimentoCPF.MaxDate = DateTime.Now;
            txtDataNascimento.Text = DateSelected(dtpDataNascimentoCPF);
        }

        private void tsPerson_Click(object sender, EventArgs e)
        {
            if (tsPerson.ForeColor == Unselected)
            {
                pnlEnterprise.Visible = false;
                pnlPerson.Visible = true;
                tsPerson.ForeColor = Selected;
                tsEnterpriseSignup.ForeColor = Unselected;
            }
        }

        /// <summary>
        /// Botão responsável por capturar os valores dos campos de cadastro de empresa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Endereço
            string Error = string.Empty;
            string[] date = txtFundacaoData.Text.Split('/');

            LegalPerson user = new LegalPerson
            (
                txtCNPJ.Text,
                txtNameEmpresa.Text,
                DateTime.Parse($"{date[2]} - {date[1]} - {date[0]}"),
                txtSenhaCNJP.Text,
                " ",//CODIGO
                txtEmailCNPJ.Text,
                " ",//PALAVRASECRETA
                txtCEPcnpj.Text,
                txtRuaCNPJ.Text,
                txtBairroCNPJ.Text,
                txtCidadeCNPJ.Text,
                txtEstadoCNPJ.Text,
                txtNumeroCNPJ.Text,
                txtComplementoCNPJ.Text
            );


            List<Contacts> Contatos = new List<Contacts>
            {
                new Contacts
                {
                    Contact = txtContatoCNPJ.Text.Length > 0 ? txtContatoCNPJ.Text:""
                },
                new Contacts
                {
                      Contact = txtContatoSecundarioCNPJ.Text.Length > 0 ? txtContatoSecundarioCNPJ.Text:""
                }
            };

            List<TextVerifyDTO> textVerify = new List<TextVerifyDTO>
            {
                new TextVerifyDTO(user.NomeFantasia,"Nome Fantasia", 3, 25),
                //new TextVerify(user.DataFundacao.Date.ToString(),"Data de Fundação", 8, 8),
                new TextVerifyDTO(user.CNPJ,"CNPJ", 14, 14),
                new TextVerifyDTO(user.Senha,"Senha", 5, 10),
                new TextVerifyDTO(user.Email,"Email", 5, 10),
                new TextVerifyDTO(Contatos[0].Contact,"Contato", 10, 11),
                new TextVerifyDTO(user.CEP,"CEP", 8, 8),
                new TextVerifyDTO(user.Rua,"Rua", 3, 100),
                new TextVerifyDTO(user.Bairro,"Bairro", 3, 100),
                new TextVerifyDTO(user.Numero,"Número", 1, 10),
                new TextVerifyDTO(user.Estado,"Estado", 3, 25),
                new TextVerifyDTO(user.Cidade,"Cidade", 3, 40)
            };

            foreach (string erro in NullOrEmpty(textVerify))
            {
                Error += erro + "\n";
            }

            if (!LegalPerson.VerifyCNPJ(user.CNPJ)) Error += "CNPJ inválido.";


            if (string.IsNullOrWhiteSpace(txtConfirmarSenhaCNPJ.Text))
            {
                Error += "A senha deve ser confirmada no campo 'Confirmar Senha'.\n";
            }
            else
            {
                if (user.Senha != txtConfirmarSenhaCNPJ.Text)
                {
                    Error += "As senha não coincidem nos campos de 'Senha' e 'Confirmar Senha'.\n";
                }
            }

            if (!string.IsNullOrWhiteSpace(Contatos[1].Contact) || !string.IsNullOrEmpty(Contatos[1].Contact))
            {
                if (Contatos[1].Contact.Length >= 10)
                {
                    if (Contatos[0].Contact == Contatos[1].Contact)
                    {
                        Error += "Os contatos confirmados não devem ser iguais.\n";
                    }
                }
                else
                {
                    Error += "O contato secundário deve ter no mínimo 10 números.\n";

                }
            }

            if (LegalPersonBLL.HasCNPJ(user.CNPJ))
            {
                Error += "O CNPJ digitado já consta cadastrado no sistema.\n";
            }

            if (LegalPersonBLL.HasEmail(user.Email))
            {
                Error += "O e-mail digitado já consta cadastrado no sistema.\n";
            }

            if (string.IsNullOrEmpty(Error) || string.IsNullOrWhiteSpace(Error))
            {
                user.Contatos = Contatos;

                if (LegalPersonBLL.RegisterUser(user))
                {
                    MessageBox.Show("O novo usuário foi adicionado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro e não foi possível realizar o cadastro no sistema. Contate o Administrador para maiores informações.");
                }
            }
            else MessageBox.Show(Error);
        }


        /// <summary>
        /// Responsável por gerar uma lista de quais campos estão nulos ou com menor quantidade necessária de caractéres.
        /// </summary>
        /// <param name="texts"></param>
        /// <returns></returns>
        public static List<string> NullOrEmpty(List<TextVerifyDTO> texts)
        {
            List<string> Erros = new List<string>();

            foreach (TextVerifyDTO txt in texts)
            {
                if (string.IsNullOrEmpty(txt.Text) || string.IsNullOrWhiteSpace(txt.Text))
                {
                    Erros.Add("O campo '" + txt.Campo + "' não pode ser nulo.");
                }
                else
                {
                    if (txt.Sizemax == txt.Sizemin)
                    {
                        if (txt.Text.Length != txt.Sizemin)
                        {
                            Erros.Add("O campo '" + txt.Campo + "' deve conter o mínimo e máximo de " + txt.Sizemin + "' caractéres.");
                        }
                    }
                    else
                    {
                        if (txt.Text.Length < txt.Sizemin)
                        {
                            Erros.Add("O campo '" + txt.Campo + "' deve conter o mínimo de " + txt.Sizemin + "' caractéres.");
                        }
                    }

                }
            }

            return Erros;
        }

        private void dtpDateCNPJ_ValueChanged(object sender, EventArgs e)
        {
            txtFundacaoData.Text = DateSelected(dtpDateCNPJ);
        }

        private void txtContatoCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void dtpDataNascimentoCPF_ValueChanged(object sender, EventArgs e)
        {
            txtDataNascimento.Text = DateSelected(dtpDataNascimentoCPF);
        }

        private void tsEnterpriseSignup_Click(object sender, EventArgs e)
        {
            if (tsEnterpriseSignup.ForeColor == Unselected)
            {
                pnlPerson.Visible = false;
                pnlEnterprise.Visible = true;
                pnlEnterprise.Left = left;
                pnlEnterprise.Top = top;
                tsEnterpriseSignup.ForeColor = Selected;
                tsPerson.ForeColor = Unselected;
            }
        }
        public static string DateSelected(DateTimePicker dtpicker)
        {
            string[] date = dtpicker.Value.Date.ToString().Substring(0, 10).Split('/');
            return $"{date[0]}/{date[1]}/{date[2]}";
        }

        public static void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnCadastrarCPF_Click(object sender, EventArgs e)
        {
            //Endereço
            string Error = string.Empty;
            string[] date = txtDataNascimento.Text.Split('/');

            NaturalPerson user = new NaturalPerson
            (
                txtCPF.Text,
                txtNomeCPF.Text.ToUpper(),
                DateTime.Parse($"{date[2]} - {date[1]} - {date[0]}"),
                txtSenhaCPF.Text,
                " ",//CODIGO
                txtEmailCPF.Text.ToUpper(),
                " ",//PALAVRASECRETA
                txtCEPCPF.Text,
                txtRuaCPF.Text.ToUpper(),
                txtBairroCPF.Text.ToUpper(),
                txtCidadeCPF.Text.ToUpper(),
                txtEstadoCPF.Text.ToUpper(),
                txtNumeroCPF.Text,
                txtComplementoCPF.Text.ToUpper()
            );


            List<Contacts> Contatos = new List<Contacts>
            {
                new Contacts
                {
                    Contact = txtContatoCPF.Text.Length > 0 ? txtContatoCPF.Text:""
                },
                new Contacts
                {
                      Contact = txtContatoSecundarioCPF.Text.Length > 0 ? txtContatoSecundarioCPF.Text:""
                }
            };

            List<TextVerifyDTO> textVerify = new List<TextVerifyDTO>
            {
                new TextVerifyDTO(user.Nome,"Nome", 3, 25),
                //new TextVerify(user.DataFundacao.Date.ToString(),"Data de Fundação", 8, 8),
                new TextVerifyDTO(user.CPF,"CPF", 11, 11),
                new TextVerifyDTO(user.Senha,"Senha", 5, 10),
                new TextVerifyDTO(user.Email,"Email", 5, 10),
                new TextVerifyDTO(Contatos[0].Contact,"Contato", 10, 11),
                new TextVerifyDTO(user.CEP,"CEP", 8, 8),
                new TextVerifyDTO(user.Rua,"Rua", 3, 100),
                new TextVerifyDTO(user.Bairro,"Bairro", 3, 100),
                new TextVerifyDTO(user.Numero,"Número", 1, 10),
                new TextVerifyDTO(user.Estado,"Estado", 3, 25),
                new TextVerifyDTO(user.Cidade,"Cidade", 3, 40)
            };

            foreach (string erro in NullOrEmpty(textVerify))
            {
                Error += erro + "\n";
            }

            if (!NaturalPerson.VerifyCPF(user.CPF)) Error += "CPF inválido.";


            if (string.IsNullOrWhiteSpace(txtConfirmarSenhaCPF.Text))
            {
                Error += "A senha deve ser confirmada no campo 'Confirmar Senha'.\n";
            }
            else
            {
                if (user.Senha != txtConfirmarSenhaCPF.Text)
                {
                    Error += "As senha não coincidem nos campos de 'Senha' e 'Confirmar Senha'.\n";
                }
            }

            if (!string.IsNullOrWhiteSpace(Contatos[1].Contact) || !string.IsNullOrEmpty(Contatos[1].Contact))
            {
                if (Contatos[1].Contact.Length >= 10)
                {
                    if (Contatos[0].Contact == Contatos[1].Contact)
                    {
                        Error += "Os contatos confirmados não devem ser iguais.\n";
                    }
                }
                else
                {
                    Error += "O contato secundário deve ter no mínimo 10 números.\n";

                }
            }

            if (NaturalPersonBLL.HasCPF(user.CPF))
            {
                Error += "O CPF digitado já consta cadastrado no sistema.\n";
            }

            if (NaturalPersonBLL.HasEmail(user.Email))
            {
                Error += "O e-mail digitado já consta cadastrado no sistema.\n";
            }

            if (string.IsNullOrEmpty(Error) || string.IsNullOrWhiteSpace(Error))
            {
                user.Contatos = Contatos;
                user.Admin = rdbAdmCPF.Checked;

                if (NaturalPersonBLL.RegisterUser(user))
                {
                    MessageBox.Show("O novo usuário foi adicionado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro e não foi possível realizar o cadastro no sistema. Contate o Administrador para maiores informações.");
                }
            }
            else MessageBox.Show(Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Limpar os dados já descritos?", "Apagar Informações do Usuário", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                rdbAdmCPF.Checked = true;
                txtNomeCPF.Text = txtCPF.Text = txtSenhaCPF.Text = txtConfirmarSenhaCPF.Text = txtEmailCPF.Text = txtContatoCPF.Text =
                    txtContatoSecundarioCPF.Text = txtCEPCPF.Text = txtRuaCPF.Text = txtComplementoCPF.Text = txtNumeroCPF.Text =
                    txtEstadoCPF.Text = txtCidadeCPF.Text = txtBairroCPF.Text = string.Empty;
            }
        }
        
        private void btnLimparCNPJ_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Limpar os dados já descritos?", "Apagar Informações do Usuário", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtNameEmpresa.Text = txtCNPJ.Text = txtSenhaCNJP.Text = txtConfirmarSenhaCNPJ.Text = txtEmailCNPJ.Text = txtContatoCNPJ.Text =
                txtContatoSecundarioCNPJ.Text = txtCEPcnpj.Text = txtRuaCNPJ.Text = txtComplementoCNPJ.Text = txtNumeroCNPJ.Text =
                txtEstadoCNPJ.Text = txtCidadeCNPJ.Text = txtBairroCNPJ.Text = string.Empty;
            }
        }        
    }
}
