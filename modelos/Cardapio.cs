using System.Collections.ObjectModel;

public class Cardapio{

    public int Id { get; set; }

    public int Item { get; set; }

    public String? ItemNome { get; set; }

    public float Preco { get; set; }

    public List<Pedido>Pedidos { get; set; }

    public Cardapio (int Item, String ItemNome, float Preco){
        this.Item = Item;
        this.ItemNome = ItemNome;
        this.Preco = Preco;
        Pedidos = new List<Pedido>();
    }
}