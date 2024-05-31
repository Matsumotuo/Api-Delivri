public class Endereco{
    
    public int Id { get; set; }

    public string? Rua { get; set;}

    public int Numero { get; set;}

    public int CEP { get; set;}

    public string? Complemento { get; set;}

    public List<Usuario>? Usuarios { get; set; }


}