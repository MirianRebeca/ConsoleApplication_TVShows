using System;

namespace DIO.Series
{   
    public class Serie : EntidadeBase //Serie herda de EntidaBase tendo então o Id
    {
        //Atributos, genero é um enum
        private string Titulo {get; set; }
        private Genero Genero {get; set; }
        private string Descricao {get; set; }
        private int Ano {get; set; }
        private bool Excluido {get; set; }

        //Métodos
        // Metodo Construtor
        public Serie(int id, string titulo, Genero genero, string descricao, int ano)
        {
        this.Id = id;
        this.Titulo = titulo;
        this.Genero = genero;
        this.Descricao = descricao;
        this.Ano = ano;
        this.Excluido = false;
        }
        //Metodo sobreescrever ToString para quando usar usa-lo executar a método abaixo
        public override string ToString()
        {
           // Environment.NewLine : para nova linha  de acordo com  sistema operacional
            string retorno = "";
            retorno += "Titulo: " + this.Titulo  + Environment.NewLine;
            retorno += "Genero: " + this.Genero  + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao  + Environment.NewLine;
            retorno += "Ano de início: " + this.Ano;
            retorno += "\nExcluido: " + this.Excluido;
            return retorno;
        }
        //Métodos de encapsulamento(serão usados para a listagem)
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            Excluido = true;
        }
    }
}