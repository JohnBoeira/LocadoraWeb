using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.FuncionarioModule
{
    public class Funcionario : EntidadeBase<int>, IEquatable<Funcionario>
    {
        public Funcionario()
        {
        }

        public string Nome { get; }
        public string Usuario { get; }
        public string Senha { get; }
        public DateTime DataAdmissao { get; }
        public double Salario { get; }

        public Funcionario(string nome, string usuario, string senha, DateTime dataAdmissao, double salario)
        {
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            DataAdmissao = dataAdmissao;
            Salario = salario;
        }

       

        public override bool Equals(object obj)
        {
            return Equals(obj as Funcionario);
        }

        public bool Equals(Funcionario other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Nome.Equals(other.Nome) &&
                   Usuario.Equals(other.Usuario) &&
                   Senha.Equals(other.Senha) &&
                   DataAdmissao.Equals(other.DataAdmissao) &&
                   Salario.Equals(other.Salario);
        }

        public override int GetHashCode()
        {
            int hashCode = -1653155459;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Usuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Senha);
            hashCode = hashCode * -1521134295 + DataAdmissao.GetHashCode();
            hashCode = hashCode * -1521134295 + Salario.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
