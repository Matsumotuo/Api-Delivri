public class Loja
{

  public int Id { get; set; }
  public string? Nome { get; set; }

  public float Taxa { get; set; }

  public float Nota { get; set; }

  public bool Entrega { get; set; }

  public List<Cardapio>? Cardapios { get; set; }

  /*{
      "id": 0,
      "nome": "string",
      "taxa": 0,
      "nota": 0,
      "entrega": true,
      "cardapios": [
      {
        "id": 0,
        "item": 0,
        "itemNome": "string",
        "preco": 0,
        "loja": [
          "string"
    ]
  }
]
}
  }*/

}