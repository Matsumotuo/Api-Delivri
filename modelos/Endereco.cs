public class Endereco{
    
    public Endereco(){ Usuarios = new List<Usuario>(){ }; }

    public int Id { get; set; }

    public string? Rua { get; set;}

    public string? Numero { get; set;}

    public int CEP { get; set;}

    public List<Usuario> Usuarios { get; set; }


}