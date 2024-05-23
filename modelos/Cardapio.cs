public class Cardapio{

     //relacionamento m para m 
    public int Id { get; set; }

    public int Item { get; set; }

    public String? ItemNome { get; set; }

    public float Preco { get; set; }

    public List<Loja>? Lojas { get; set; }

   /* public Cardapio (int Item, String ItemNome, float Preco){
        this.Item = Item;
        this.ItemNome = ItemNome;
        this.Preco = Preco;
        List<Lojas> loja = new List<Lojas> ();
    }*/
}