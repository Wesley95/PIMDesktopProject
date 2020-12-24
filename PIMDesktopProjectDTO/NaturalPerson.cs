﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMDesktopProjectDTO
{
    public class NaturalPerson : UserDTO
    {
        public string NaturalPersonID { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public NaturalPerson()
        {

        }

        public NaturalPerson(string cpf, string pass)
        {
            CPF = cpf;
            Senha = pass;
        }

        public NaturalPerson(string cpf, string nome, DateTime dataNascimento, string senha, string codigo, string email, string palavraSecreta, string cep, string rua, string bairro,
            string cidade, string estado, string numero, string complemento)
        {
            CPF = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
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

        public static bool VerifyCPF(string CPF)
        {
            if (CPF != "11111111111" && CPF != "22222222222" &&
                CPF != "33333333333" && CPF != "44444444444" &&
                CPF != "55555555555" && CPF != "66666666666" &&
                CPF != "77777777777" && CPF != "88888888888" &&
                CPF != "99999999999" && CPF != "00000000000")
            {
                int somaTotal = 0;

                incrementarSoma(ref somaTotal, 10, CPF, 9);
                if ((11 - (somaTotal % 11)).Equals(int.Parse(CPF.Substring(9, 1))))
                {
                    somaTotal = 0;
                    incrementarSoma(ref somaTotal, 11, CPF, 10);

                    if ((11 - (somaTotal % 11)).Equals(int.Parse(CPF.Substring(10, 1))))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static void incrementarSoma(ref int soma, byte cont, string cpfChar, byte limiteIndex)
        {
            byte aux = cont;
            for (int l = 0; l < limiteIndex; l++)
            {
                soma += byte.Parse(cpfChar.Substring(l, 1)) * aux;
                aux--;
            }
        }

    }
}
