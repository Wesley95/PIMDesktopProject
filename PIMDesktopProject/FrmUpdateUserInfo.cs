using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIMDesktopProjectBLL;
using PIMDesktopProjectDTO;

namespace PIMDesktopProject
{
    public partial class FrmUpdateUserInfo : Form
    {
        int x = 46, y = 228;//46; 228
        bool isCPF = true;
        Color SelectedButton = ColorTranslator.FromHtml("#FFCF6D"),
        SelectedButtonText = Color.White,
        UnselectedButtonText = ColorTranslator.FromHtml("#EEEEEE"),
        UnselectedButton = Color.White;

        public FrmUpdateUserInfo()
        {
            InitializeComponent();
            pnlInfo.Visible = true;
            pnlInfo.Location = new Point(x, y);

            pnlContacts.Visible = pnlAddress.Visible = false;
            btnInfo.BackColor = SelectedButton;
            btnInfo.ForeColor = SelectedButtonText;
            btnContact.BackColor = btnAddress.BackColor = UnselectedButton;
            btnContact.ForeColor = btnAddress.ForeColor = UnselectedButtonText;

            btnFind.BackColor = btnClean.BackColor = pnlTop.BackColor = btnRefresh.BackColor = SelectedButton;
            btnFind.ForeColor = btnClean.ForeColor = btnRefresh.ForeColor = UnselectedButton;

            var yesterday = DateTime.Now;

            dateTimePicker1.MaxDate = yesterday;
            dateTimePicker1.Value = yesterday.AddDays(-1);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string doc = textBox1.Text,
            Error = string.Empty;
            string[] date;

            if (doc.Length == 11)//TAMANHO DO CPF
            {
                if (NaturalPerson.VerifyCPF(doc))
                {
                    isCPF = true;
                    if (NaturalPersonBLL.HasCPF(doc))
                    {
                        var person = NaturalPersonBLL.GetUserByCPF(doc);
                        person.Contatos = UserBLL.ListContacts(person.UserID);

                        date = person.DataNascimento.Date.ToString().Substring(0, 10).Split('/');

                        lblDate.Text = "Data de Nasc.:";
                        lblDOC.Text = "CPF:";
                        lblNome.Text = "Nome:";
                        dateTimePicker1.Value = person.DataNascimento;


                        txtName.Text = person.Nome;
                        txtDOC.Text = person.CPF;
                        txtEmail.Text = person.Email;
                        txtBirthDate.Text = $"{date[0]}/{date[1]}/{date[2]}";
                        txtContact.Text = person.Contatos[0].Contact;
                        lblFirstContact.Text = person.Contatos[0].ID;
                        lblFirstContact.Visible = false;
                        txtContactSecundary.Text = person.Contatos[1].Contact;
                        lblSecondaryContact.Text = person.Contatos[1].ID;
                        lblSecondaryContact.Visible = false;
                        txtCEP.Text = person.CEP;
                        txtDistrict.Text = person.Bairro;
                        txtStreet.Text = person.Rua;
                        txtNumber.Text = person.Numero;
                        txtTown.Text = person.Cidade;
                        txtEstado.Text = person.Estado;
                        txtComplement.Text = person.Complemento;

                        btnRefresh.Enabled = true;

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
                            person.Contatos = UserBLL.ListContacts(person.UserID);

                            date = person.DataFundacao.Date.ToString().Substring(0, 10).Split('/');

                            lblDate.Text = "Data de Fund.:";
                            lblDOC.Text = "CNPJ:";
                            lblNome.Text = "Nome Fantasia:";
                            dateTimePicker1.Value = person.DataFundacao;

                            txtName.Text = person.NomeFantasia;
                            txtDOC.Text = person.CNPJ;
                            txtEmail.Text = person.Email;
                            txtBirthDate.Text = $"{date[0]}/{date[1]}/{date[2]}";
                            txtContact.Text = person.Contatos[0].Contact;
                            lblFirstContact.Text = person.Contatos[0].ID;
                            lblFirstContact.Visible = false;
                            txtContactSecundary.Text = person.Contatos[1].Contact;
                            lblSecondaryContact.Text = person.Contatos[1].ID;
                            lblSecondaryContact.Visible = false;
                            txtCEP.Text = person.CEP;
                            txtDistrict.Text = person.Bairro;
                            txtStreet.Text = person.Rua;
                            txtNumber.Text = person.Numero;
                            txtTown.Text = person.Cidade;
                            txtEstado.Text = person.Estado;
                            txtComplement.Text = person.Complemento;

                            btnRefresh.Enabled = true;
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TelaDeCadastro.OnlyNumbers(sender, e);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtBirthDate.Text = TelaDeCadastro.DateSelected(dateTimePicker1);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<TextVerifyDTO> textVerify = new List<TextVerifyDTO>();

            string[] date = txtBirthDate.Text.Split('/');
            string Error = string.Empty;

            List<Contacts> Contatos = new List<Contacts>
            {
                new Contacts
                {
                    Contact = txtContact.Text.Length > 0 ? txtContact.Text:"",
                    ID = lblFirstContact.Text.Length > 0 ? lblFirstContact.Text:""
                },
                new Contacts
                {
                      Contact = txtContactSecundary.Text.Length > 0 ? txtContactSecundary.Text:"",
                      ID = lblSecondaryContact.Text.Length > 0 ? lblSecondaryContact.Text:""
                }
            };

            if (isCPF)
            {
                var user = new NaturalPerson
                (
                    txtDOC.Text,
                    txtName.Text.ToUpper(),
                    DateTime.Parse($"{date[2]} - {date[1]} - {date[0]}"),
                    "",
                    " ",//CODIGO
                    txtEmail.Text.ToUpper(),
                    " ",//PALAVRASECRETA
                    txtCEP.Text,
                    txtStreet.Text.ToUpper(),
                    txtDistrict.Text.ToUpper(),
                    txtTown.Text.ToUpper(),
                    txtEstado.Text.ToUpper(),
                    txtNumber.Text,
                    txtComplement.Text.ToUpper()
                );

                textVerify.Add(new TextVerifyDTO(user.Nome, "Nome", 3, 25));
                textVerify.Add(new TextVerifyDTO(user.Email, "Email", 5, 10));
                textVerify.Add(new TextVerifyDTO(Contatos[0].Contact, "Contato", 10, 11));
                textVerify.Add(new TextVerifyDTO(user.CEP, "CEP", 8, 8));
                textVerify.Add(new TextVerifyDTO(user.Rua, "Rua", 3, 100));
                textVerify.Add(new TextVerifyDTO(user.Bairro, "Bairro", 3, 100));
                textVerify.Add(new TextVerifyDTO(user.Numero, "Número", 1, 10));
                textVerify.Add(new TextVerifyDTO(user.Estado, "Estado", 3, 25));
                textVerify.Add(new TextVerifyDTO(user.Cidade, "Cidade", 3, 40));

                user.Contatos = Contatos;

                foreach (string erro in TelaDeCadastro.NullOrEmpty(textVerify))
                {
                    Error += erro + "\n";
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

                if (string.IsNullOrEmpty(Error) || string.IsNullOrWhiteSpace(Error))
                {
                    if (isCPF)
                    {
                        if (NaturalPersonBLL.UpdateUser(user))
                        {
                            MessageBox.Show("O usuário foi atualizado com sucesso.");
                            btnClean_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro e não foi possível realizar a atualização do usuário. Contate o Administrador para maiores informações.");
                            btnClean_Click(sender, e);
                        }
                    }
                }
                else MessageBox.Show(Error);
            }
            else
            {
                var user = new LegalPerson
                (
                    txtDOC.Text,
                    txtName.Text.ToUpper(),
                    DateTime.Parse($"{date[2]} - {date[1]} - {date[0]}"),
                    "",
                    " ",//CODIGO
                    txtEmail.Text.ToUpper(),
                    " ",//PALAVRASECRETA
                    txtCEP.Text,
                    txtStreet.Text.ToUpper(),
                    txtDistrict.Text.ToUpper(),
                    txtTown.Text.ToUpper(),
                    txtEstado.Text.ToUpper(),
                    txtNumber.Text,
                    txtComplement.Text.ToUpper()
                );

                textVerify.Add(new TextVerifyDTO(user.NomeFantasia, "Nome Fantasia", 3, 25));
                textVerify.Add(new TextVerifyDTO(user.Email, "Email", 5, 10));
                textVerify.Add(new TextVerifyDTO(Contatos[0].Contact, "Contato", 10, 11));
                textVerify.Add(new TextVerifyDTO(user.CEP, "CEP", 8, 8));
                textVerify.Add(new TextVerifyDTO(user.Rua, "Rua", 3, 100));
                textVerify.Add(new TextVerifyDTO(user.Bairro, "Bairro", 3, 100));
                textVerify.Add(new TextVerifyDTO(user.Numero, "Número", 1, 10));
                textVerify.Add(new TextVerifyDTO(user.Estado, "Estado", 3, 25));
                textVerify.Add(new TextVerifyDTO(user.Cidade, "Cidade", 3, 40));

                user.Contatos = Contatos;

                foreach (string erro in TelaDeCadastro.NullOrEmpty(textVerify))
                {
                    Error += erro + "\n";
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

                if (string.IsNullOrEmpty(Error) || string.IsNullOrWhiteSpace(Error))
                {
                    if (LegalPersonBLL.UpdateUser(user))
                    {
                        MessageBox.Show("O usuário foi atualizado com sucesso.");
                        btnClean_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro e não foi possível realizar a atualização do usuário. Contate o Administrador para maiores informações.");
                        btnClean_Click(sender, e);
                    }
                }
                else MessageBox.Show(Error);
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtDOC.Text = txtName.Text = txtEmail.Text = txtCEP.Text = txtStreet.Text = txtDistrict.Text =
                txtTown.Text = txtEstado.Text = txtNumber.Text = txtComplement.Text =
                lblFirstContact.Text = lblSecondaryContact.Text = txtDOC.Text =
                txtContact.Text = txtContactSecundary.Text = "";
            btnRefresh.Enabled = false;
            var yesterday = DateTime.Now;

            dateTimePicker1.Value = yesterday.AddDays(-1);
        }

        private void CleanButtonTab(Button btnClean1, Button btnClean2, Button btnActive,
            Panel pnlClean1, Panel pnlClean2, Panel pnlActive)
        {
            btnClean1.BackColor = btnClean2.BackColor = UnselectedButton;
            btnClean1.ForeColor = btnClean2.ForeColor = UnselectedButtonText;
            btnActive.BackColor = SelectedButton;
            btnActive.ForeColor = SelectedButtonText;
            pnlClean1.Visible = pnlClean2.Visible = false;
            pnlActive.Visible = true;
            pnlActive.Location = new Point(x, y);
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            CleanButtonTab(btnContact, btnInfo, btnAddress, pnlContacts, pnlInfo, pnlAddress);
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            CleanButtonTab(btnInfo, btnAddress, btnContact, pnlInfo, pnlAddress, pnlContacts);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            CleanButtonTab(btnAddress, btnContact, btnInfo, pnlAddress, pnlContacts, pnlInfo);
        }
    }
}
