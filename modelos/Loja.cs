public class Loja{

    public Loja(){ Cardapios = new List<Cardapio>(){}; } // heranca ok
    public int Id { get; set; }
    public string? Nome { get; set; }

    public float Taxa { get; set; }

    public float Nota { get; set; }

    public bool Entrega { get; set; }

    public List<Cardapio> Cardapios{ get; set; }    

    /*public Lojas(string Nome, float Taxa, float Nota, bool Entrega) {
        this.Nome = Nome;   
        this.Taxa = Taxa; 
        this.Nota = Nota;
        this.Entrega = Entrega;
    }*/

}