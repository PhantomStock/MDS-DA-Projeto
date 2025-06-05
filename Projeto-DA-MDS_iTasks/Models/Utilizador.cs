using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iTasks
{
    // este ficheiro contém a definição da classe Utilizador, que representa um utilizador no sistema de gestão de tarefas.
    public class Utilizador
    {
        [Key] public int Id { get; set; }
        public string Nome { get; set; }

        [MaxLength(100)][Index(IsUnique = true)] public string Username { get; set; }
        public string Password { get; set; }

        // construtor padrão vazio
        public Utilizador() { }

        //contrutor que recebe os parâmetros necessários para criar um Utilizador (vai desaparecer no futuro)
        public Utilizador(string nome, string username, string password)
        {
            this.Nome = nome;
            this.Username = username;
            this.Password = password;

        }
    }
}