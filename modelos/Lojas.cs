public class Lojas{

    public int Id { get; set; }
    public string? Nome { get; set; }

    public float Taxa { get; set; }

    public float Nota { get; set; }

    public string? Entrega { get; set; }

    public Lojas(int Id,string Nome, float Taxa, float Nota, string Entrega) {
        this.Id = Id;
        this.Nome = Nome;   
        this.Taxa = Taxa; 
        this.Nota = Nota;
        this.Entrega = Entrega;
    }

}