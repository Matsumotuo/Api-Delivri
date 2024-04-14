public class Pedido
{

    public int Id { get; set; }

    public string Detalhes { get; set; } 

    public int Quantidade { get; set; } 


    public Pedido(int Id,string detalhes, int quantidade)
    {
        this.Id = Id;
        this.Detalhes = detalhes;
        this.Quantidade = quantidade;
    }
}
