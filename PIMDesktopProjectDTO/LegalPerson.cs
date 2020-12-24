using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMDesktopProjectDTO
{
    public class LegalPerson : UserDTO
    {
        public string LegalPersonID { get; set; }
        public string CNPJ { get; set; }        
        public string NomeFantasia { get; set; }
        public DateTime DataFundacao { get; set; }

        public LegalPerson()
        {

        }

        public LegalPerson(string cnpj, string pass)
        {
            CNPJ = cnpj;
            Senha = pass;
        }

        public LegalPerson(string cnpj, string nomeFantasia, DateTime dataFundacao, string senha, string codigo, string email, string palavraSecreta, string cep, string rua, string bairro,
            string cidade, string estado, string numero, string complemento)
        {
            CNPJ = cnpj;            
            NomeFantasia = nomeFantasia;
            DataFundacao = dataFundacao;
            //Contato = contato;
            //ContatoSecundario = contatoSecundario;
            Senha = senha;
            Email = email;
            PalavraSecreta = palavraSecreta;
            CEP = cep;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
            Complemento = complemento;
        }

        public static bool VerifyCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
