public class Usuario{

    public Usuario(){ Enderecos = new List<Endereco> (){ }; }
    public int Id { get; set;}

    public string? NomeUser { get; set;}

    public float UserAvalicao { get; set;}

    public List<Endereco> Enderecos { get; set;}

}