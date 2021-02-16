using System;

namespace CRUD
{
    public class Serie : EntidadeBase
    {
        //Atributos
        private Gender Gender { get; set; }
        private string Tittle { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Excluded { get; set; }

        //Métodos
        public Serie(int id, Gender gender, string tittle, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Tittle = tittle;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gender: "       + this.Gender + Environment.NewLine;
            retorno += "Tittle: "       + this.Tittle + Environment.NewLine;
            retorno += "Descrição: "    + this.Description + Environment.NewLine;
            retorno += "Ano: "          + this.Year + Environment.NewLine;
            retorno += "Excluído: "     + this.Excluded;

            return retorno;
        }
        public string GetTittle()
        {
            return this.Tittle;
        }
        public int GetId()
        {
            return this.Id;
        }
        public bool GetExcluded()
        {
            return this.Excluded;
        }
        public void Excluir()
        {
            this.Excluded = true;
        }
    }
}