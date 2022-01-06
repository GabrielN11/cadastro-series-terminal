namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        public int Genero { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int Temporadas {get; set;}

        public int Ano { get; set; }

        public bool Excluido {get;set;}

        public Serie(int id, int genero, string titulo, string descricao, int temporadas, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Temporadas = temporadas;
            this.Ano = ano;
            this.Excluido = false;
        }

        public string getTitulo(){
            return this.Titulo;
        }

        public int getId(){
            return this.Id;
        }

        public void Excluir(){
            this.Excluido = true;
        }

        public bool Status(){
            return this.Excluido;
        }

        public override string ToString (){
            string genero = "";
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                if(i == this.Genero) genero = Enum.GetName(typeof(Genero), i);
            }
            string info = "";
            info += "Genero: " + genero + '.' + Environment.NewLine;
            info += "Título: " + this.Titulo + '.' + Environment.NewLine;
            info += "Descrição: " + this.Descricao + '.' + Environment.NewLine;
            info += "Quantidade de temporadas: " + this.Temporadas + '.' + Environment.NewLine;
            info += "Ano de lançamento: " + this.Ano + '.' + Environment.NewLine;

            return info;
        }
    }
}