using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using PIMDesktopProjectDTO;

namespace PIMDesktopProjectDAO
{
    public class GenericUserDAO
    {
        public static GenericUserDTO GetUserById(string id)
        {
            var userCPF = NaturalPersonDAO.ListAll($" WHERE u.cd_usuario = '{id}'");
            var userCNPJ = LegalPersonDAO.ListAll($" WHERE u.cd_usuario = '{id}'");

            GenericUserDTO User = new GenericUserDTO
            {
                UserID = "null"
            };

            if (userCPF.Count > 0)
            {
                var temp = userCPF.FirstOrDefault();
                User.UserID = temp.UserID;
                User.Id = temp.NaturalPersonID;
                User.AddressID = temp.AddressID;
                User.Nome = temp.Nome;
                User.Doc = temp.CPF;
                User.Data = temp.DataNascimento;
                User.Senha = temp.Senha;
                User.Email = temp.Email;
                User.Rua = temp.Rua;
                User.CEP = temp.CEP;
                User.Bairro = temp.Bairro;
                User.Cidade = temp.Cidade;
                User.Estado = temp.Estado;
                User.Complemento = temp.Complemento;
                User.Numero = temp.Numero;
            }
            else
            {
                if (userCNPJ.Count > 0)
                {
                    var temp = userCNPJ.FirstOrDefault();
                    User.UserID = temp.UserID;
                    User.Id = temp.LegalPersonID;
                    User.AddressID = temp.AddressID;
                    User.Nome = temp.NomeFantasia;
                    User.Doc = temp.CNPJ;
                    User.Data = temp.DataFundacao;
                    User.Senha = temp.Senha;
                    User.Email = temp.Email;
                    User.Rua = temp.Rua;
                    User.CEP = temp.CEP;
                    User.Bairro = temp.Bairro;
                    User.Cidade = temp.Cidade;
                    User.Estado = temp.Estado;
                    User.Complemento = temp.Complemento;
                    User.Numero = temp.Numero;
                }
            }

            return User;
        }
    }
}
